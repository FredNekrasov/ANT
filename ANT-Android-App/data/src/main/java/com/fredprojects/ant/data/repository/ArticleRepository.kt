package com.fredprojects.ant.data.repository

import com.fredprojects.ant.data.local.*
import com.fredprojects.ant.data.mappers.toEntity
import com.fredprojects.ant.data.mappers.toModel
import com.fredprojects.ant.data.remote.dto.ArticleResponse
import com.fredprojects.ant.domain.models.Article
import com.fredprojects.ant.domain.repository.IArticleRepository
import com.fredprojects.ant.domain.utils.ActionStatus
import com.fredprojects.ant.domain.utils.ActionStatus.*
import com.fredprojects.ant.domain.utils.ConnectionStatus.*
import io.ktor.client.HttpClient
import io.ktor.client.call.body
import io.ktor.client.plugins.ClientRequestException
import io.ktor.client.plugins.HttpRequestTimeoutException
import io.ktor.client.request.get
import io.ktor.serialization.JsonConvertException
import kotlinx.coroutines.flow.*
import java.time.LocalDate

/**
 * This class implements IArticleRepository interface
 * @param articleDao is an ArticleDao class. It is used to get data from the database and add data to the database
 * @param articleStatusDao is an ArticleStatusDao class. It is used to manage article status data from the database
 * @param client is a HttpClient. It is used to get data from the server
 * @see IArticleRepository
 */
class ArticleRepository(
    private val articleDao: ArticleDao,
    private val articleStatusDao: ArticleStatusDao,
    private val client: HttpClient
) : IArticleRepository {
    /**
     * Get list of articles from the database and return it as a flow if there is no internet connection.
     * If there is internet connection, get list of articles from the server and return it as a flow
     *
     * @param catalogId The ID of the catalog to retrieve the list of articles from.
     * @param pageNumber The number of the page to retrieve the list of articles from.
     *
     * @see IArticleRepository.getList
     * @return a flow of ActionStatus
     */
    override fun getList(catalogId: Int, pageNumber: Int) : Flow<ActionStatus<Article>> = flow {
        val articleList = articleDao.getAllArticles().map { it.toModel() }
        if(!hasNewArticles(catalogId)) {
            emit(Success(articleList))
            return@flow
        }
        emit(Loading(articleList))
        val response = client.get("/v1/Сhapter/$catalogId?pageNumber=$pageNumber").body<ArticleResponse?>()
        when {
            response == null -> emit(Error(articleList, NO_DATA))
            articleList.size == response.totalRecords -> emit(Success(articleList))
            else -> {
                refreshData(response, catalogId)
                emit(Success(response.data.map { it.toModel() }))
            }
        }
    }.catch { ex ->
        val articleList = articleDao.getAllArticles().map { it.toModel() }
        when(ex) {
            is HttpRequestTimeoutException -> emit(Error(articleList, CONNECTION_ERROR))
            is ClientRequestException -> emit(Error(articleList, NO_INTERNET))
            is JsonConvertException -> emit(Error(articleList, SERIALIZATION_ERROR))
            else -> emit(Error(articleList, UNKNOWN))
        }
    }
    /**
     * refreshData function is used to refresh the data in the database
     * @param response is an ArticleResponse class that is received from the server
     * @param catalogId is an ID of the catalog
     * @see ArticleResponse
     */
    private suspend inline fun refreshData(response: ArticleResponse, catalogId: Int) {
        response.data.forEach {
            articleDao.deleteArticle(it.id)
            articleDao.upsertArticle(it.toEntity())
        }
        val articleStatus = articleStatusDao.getAllArticleStatus().firstOrNull { it.catalogId == catalogId.toLong() } ?: ArticleStatusEntity(0L, response.totalRecords.toLong(), catalogId.toLong(), LocalDate.now().toString())
        articleStatusDao.upsertArticleStatus(articleStatus.copy(currentDate = LocalDate.now().toString()))
    }
    /**
     * hasNewArticles function is used to check if there are new articles in the server
     * @return Boolean
     */
    private suspend fun hasNewArticles(catalogId: Int): Boolean {
        val lastArticleStatus = articleStatusDao.getAllArticleStatus().firstOrNull { it.catalogId == catalogId.toLong() } ?: return true
        return !lastArticleStatus.currentDate.contentEquals(LocalDate.now().toString())
    }
}
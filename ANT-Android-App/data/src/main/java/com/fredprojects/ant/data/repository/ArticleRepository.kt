package com.fredprojects.ant.data.repository

import com.fredprojects.ant.data.local.ArticleDao
import com.fredprojects.ant.data.mappers.toEntity
import com.fredprojects.ant.data.mappers.toModel
import com.fredprojects.ant.data.remote.dto.ArticleDto
import com.fredprojects.ant.domain.models.Article
import com.fredprojects.ant.domain.repository.IArticleRepository
import com.fredprojects.ant.domain.utils.ActionStatus
import com.fredprojects.ant.domain.utils.ActionStatus.*
import com.fredprojects.ant.domain.utils.ConnectionStatus.*
import io.ktor.client.HttpClient
import io.ktor.client.call.body
import io.ktor.client.plugins.*
import io.ktor.client.request.get
import io.ktor.serialization.JsonConvertException
import kotlinx.coroutines.flow.*

/**
 * This class implements IArticleRepository interface
 * @param dao is an ArticleDao class. It is used to get data from the database and add data to the database
 * @param client is a HttpClient. It is used to get data from the server
 * @see IArticleRepository
 */
class ArticleRepository(
    private val dao: ArticleDao,
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
        val articleList = dao.getAllArticles().map { it.toModel() }
        emit(Loading(articleList))
        val articleDtoList = client.get("/api/v1/Сhapter/$catalogId?pageNumber=$pageNumber&pageSize=25").body<List<ArticleDto>?>()
        if(!articleDtoList.isNullOrEmpty()) {
            articleDtoList.forEach {
                dao.deleteArticle(it.id)
                dao.upsertArticle(it.toEntity())
            }
            emit(Success(articleDtoList.map { it.toModel() }))
        } else emit(Error(articleList, NO_DATA))
    }.catch { ex ->
        val articleList = dao.getAllArticles().map { it.toModel() }
        when(ex) {
            is HttpRequestTimeoutException -> emit(Error(articleList, CONNECTION_ERROR))
            is ClientRequestException -> emit(Error(articleList, NO_INTERNET))
            is JsonConvertException -> emit(Error(articleList, SERIALIZATION_ERROR))
            else -> emit(Error(articleList, UNKNOWN))
        }
    }
}
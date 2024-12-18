package com.fredprojects.ant.presentation.screens.viewModels

import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.fredprojects.ant.domain.repository.IArticleRepository
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.flow.*
import kotlinx.coroutines.launch

class MainVM(
    private val repository: IArticleRepository
) : ViewModel() {
    private val articlesMSF = MutableStateFlow(MainArticleState())
    val articlesSF = articlesMSF.asStateFlow()
    private fun getArticles(catalogId: Int, pageNumber: Int = 1) {
        viewModelScope.launch {
            repository.getList(catalogId, pageNumber).flowOn(Dispatchers.IO).collectLatest {
                val newState = articlesSF.value.copy(list = it.list, status = it.status)
                articlesMSF.emit(newState)
            }
        }
    }
    init { getArticles(1) }
}
open class ArticleVM(
    private val repository: IArticleRepository
) : ViewModel() {
    private val articlesMSF = MutableStateFlow(PagedArticleState())
    val articlesSF = articlesMSF.asStateFlow()
    open fun getArticles(catalogId: Int, pageNumber: Int = 1) {
        viewModelScope.launch {
            repository.getList(catalogId, pageNumber).flowOn(Dispatchers.IO).collectLatest {
                val newState = if(it.list.size < 50)  articlesSF.value.copy(map = mapOf(pageNumber to it.list), status = it.status)
                else articlesSF.value.copy(map = mapOf(pageNumber to it.list), status = it.status, hasNextData = true)
                articlesMSF.emit(newState)
            }
        }
    }
}
class ParishLifeVM(repository: IArticleRepository) : ArticleVM(repository) {
    fun getParishLifeArticles(pageNumber: Int = 1) {
        super.getArticles(2, pageNumber)
    }
    init { getArticles(2) }
}
class YouthClubVM(repository: IArticleRepository) : ArticleVM(repository) {
    fun getYouthClubArticles(pageNumber: Int = 1) {
        super.getArticles(5, pageNumber)
    }
    init { getArticles(5) }
}
class AdvicesVM(repository: IArticleRepository) : ArticleVM(repository) {
    fun getAdviceArticles(pageNumber: Int = 1) {
        super.getArticles(7, pageNumber)
    }
    init { getArticles(7) }
}
class HistoryVM(repository: IArticleRepository) : ArticleVM(repository) {
    fun getHistoryArticles(pageNumber: Int = 1) {
        super.getArticles(8, pageNumber)
    }
    init { getArticles(8) }
}
class StoriesVM(repository: IArticleRepository) : ArticleVM(repository) {
    fun getStoryArticles(pageNumber: Int = 1) {
        super.getArticles(13, pageNumber)
    }
    init { getArticles(13) }
}
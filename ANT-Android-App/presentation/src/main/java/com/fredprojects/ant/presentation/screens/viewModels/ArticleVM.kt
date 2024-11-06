package com.fredprojects.ant.presentation.screens.viewModels

import android.app.Application
import android.content.Intent
import android.net.Uri
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.fredprojects.ant.domain.repository.IArticleRepository
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.flow.*
import kotlinx.coroutines.launch

class ArticleVM(
    private val repository: IArticleRepository,
    private val context: Application
) : ViewModel() {
    private val articlesMSF = MutableStateFlow(ArticleState())
    val articlesSF = articlesMSF.asStateFlow()
    fun getArticles(catalogId: Int, pageNumber: Int) {
        viewModelScope.launch {
            repository.getList(catalogId, pageNumber).flowOn(Dispatchers.IO).collectLatest {
                articlesMSF.emit(articlesSF.value.copy(list = it.list, status = it.status))
            }
        }
    }
    fun openApp(url: String) = context.startActivity(Intent(Intent.ACTION_VIEW, Uri.parse(url)))
}
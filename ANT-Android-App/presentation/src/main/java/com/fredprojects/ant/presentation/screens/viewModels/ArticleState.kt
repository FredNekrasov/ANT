package com.fredprojects.ant.presentation.screens.viewModels

import androidx.compose.runtime.Stable
import com.fredprojects.ant.domain.models.Article
import com.fredprojects.ant.domain.utils.ConnectionStatus

@Stable
data class MainArticleState(
    val list: List<Article> = emptyList(),
    val status: ConnectionStatus = ConnectionStatus.LOADING
)
@Stable
data class PagedArticleState(
    val map: Map<Int, List<Article>> = emptyMap(),
    val status: ConnectionStatus = ConnectionStatus.LOADING,
    val hasNextData: Boolean = false
)
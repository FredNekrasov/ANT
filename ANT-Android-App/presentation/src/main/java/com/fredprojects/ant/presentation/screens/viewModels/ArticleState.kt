package com.fredprojects.ant.presentation.screens.viewModels

import androidx.compose.runtime.Stable
import com.fredprojects.ant.domain.models.Article
import com.fredprojects.ant.domain.utils.ConnectionStatus

@Stable
data class ArticleState(
    val list: List<Article> = emptyList(),
    val status: ConnectionStatus = ConnectionStatus.LOADING
)
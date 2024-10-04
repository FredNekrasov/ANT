package com.fredprojects.ant.presentation.screens.onePages

import androidx.compose.foundation.layout.*
import androidx.compose.foundation.rememberScrollState
import androidx.compose.foundation.verticalScroll
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import coil.compose.AsyncImage
import com.fredprojects.ant.presentation.core.ANTStrings
import com.fredprojects.ant.presentation.screens.viewModels.ArticleState

@Composable
fun Schedule(state: ArticleState) {
    Column(Modifier.fillMaxSize().verticalScroll(rememberScrollState())) {
        state.list.forEach {
            if(it.articleType != ANTStrings.SCHEDULE) return@forEach
            AsyncImage(model = it.title, contentDescription = it.title, modifier = Modifier.fillMaxWidth())
            AsyncImage(model = it.description, contentDescription = it.description, modifier = Modifier.fillMaxWidth())
        }
    }
}
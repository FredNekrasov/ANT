package com.fredprojects.ant.presentation.screens.onePages

import androidx.compose.foundation.layout.*
import androidx.compose.foundation.rememberScrollState
import androidx.compose.foundation.verticalScroll
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp
import com.fredprojects.ant.presentation.core.*
import com.fredprojects.ant.presentation.core.components.ImageSlider
import com.fredprojects.ant.presentation.screens.viewModels.ArticleState

@Composable
fun MainScreen(state: ArticleState) {
    Column(Modifier.fillMaxSize().verticalScroll(rememberScrollState()).padding(8.dp)) {
        state.list.forEach {
            if(it.articleType != ANTStrings.MAIN) return@forEach
            FredTitle(it.articleType)
            Spacer(Modifier.height(4.dp))
            if(it.date.isNotBlank()) FredText(it.date, modifier = Modifier.fillMaxWidth())
            Spacer(Modifier.height(8.dp))
            FredTitle(it.title)
            Spacer(Modifier.height(4.dp))
            ImageSlider(article = it, Modifier.fillMaxWidth())
            Spacer(Modifier.height(8.dp))
            FredText(it.description)
        }
    }
}
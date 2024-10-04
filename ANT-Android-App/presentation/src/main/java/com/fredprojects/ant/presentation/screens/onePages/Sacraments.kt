package com.fredprojects.ant.presentation.screens.onePages

import androidx.compose.foundation.layout.*
import androidx.compose.foundation.rememberScrollState
import androidx.compose.foundation.verticalScroll
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.unit.dp
import com.fredprojects.ant.presentation.core.*
import com.fredprojects.ant.presentation.screens.viewModels.ArticleState

@Composable
fun Sacraments(state: ArticleState) {
    Column(Modifier.fillMaxSize().verticalScroll(rememberScrollState()).padding(8.dp), Arrangement.Center) {
        state.list.forEach {
            if(it.articleType != ANTStrings.SACRAMENTS) return@forEach
            FredTitle(text = it.title)
            Spacer(modifier = Modifier.height(8.dp))
            FredText(text = it.description, modifier = Modifier.fillMaxWidth(), TextAlign.Center)
        }
    }
}
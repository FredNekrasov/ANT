package com.fredprojects.ant.presentation.screens.onePages

import androidx.compose.foundation.layout.*
import androidx.compose.foundation.rememberScrollState
import androidx.compose.foundation.verticalScroll
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp
import com.fredprojects.ant.presentation.core.*
import com.fredprojects.ant.presentation.core.components.ImageSlider
import com.fredprojects.ant.presentation.screens.viewModels.ArticleState

@Composable
fun Volunteerism(state: ArticleState) {
    Column(
        modifier = Modifier.fillMaxSize().verticalScroll(rememberScrollState()).padding(8.dp),
        horizontalAlignment = Alignment.CenterHorizontally
    ) {
        state.list.forEach {
            if(it.articleType != ANTStrings.VOLUNTEERISM) return@forEach
            FredTitle(it.articleType)
            Spacer(Modifier.height(8.dp))
            FredTitle(it.title)
            Spacer(Modifier.height(4.dp))
            FredText(it.description)
            Spacer(Modifier.height(8.dp))
            ImageSlider(it, Modifier.fillMaxWidth())
        }
    }
}
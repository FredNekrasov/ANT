package com.fredprojects.ant.presentation.screens.onePages

import androidx.compose.foundation.layout.*
import androidx.compose.foundation.rememberScrollState
import androidx.compose.foundation.verticalScroll
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp
import com.fredprojects.ant.presentation.core.ANTStrings
import com.fredprojects.ant.presentation.core.components.ListItemDetails
import com.fredprojects.ant.presentation.screens.viewModels.ArticleState

@Composable
fun Priesthood(state: ArticleState) {
    Column(Modifier.fillMaxSize().verticalScroll(rememberScrollState()).padding(8.dp)) {
        state.list.forEach {
            if(it.articleType != ANTStrings.PRIESTHOOD) return@forEach
            ListItemDetails(it, Modifier.fillMaxWidth())
        }
    }
}
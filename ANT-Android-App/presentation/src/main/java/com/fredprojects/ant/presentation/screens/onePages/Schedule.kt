package com.fredprojects.ant.presentation.screens.onePages

import androidx.compose.foundation.layout.*
import androidx.compose.foundation.rememberScrollState
import androidx.compose.foundation.verticalScroll
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp
import androidx.compose.ui.util.fastForEach
import coil.compose.AsyncImage
import com.fredprojects.ant.presentation.core.ANTStrings
import com.fredprojects.ant.presentation.screens.viewModels.MainArticleState

@Composable
fun Schedule(
    state: MainArticleState,
    modifier: Modifier = Modifier
) {
    Column(modifier.verticalScroll(rememberScrollState()).padding(8.dp)) {
        state.list.fastForEach {
            if(it.articleType != ANTStrings.SCHEDULE) return@fastForEach
            AsyncImage(model = it.title, contentDescription = it.title, modifier = Modifier.fillMaxWidth())
            AsyncImage(model = it.description, contentDescription = it.description, modifier = Modifier.fillMaxWidth())
        }
    }
}
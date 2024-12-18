package com.fredprojects.ant.presentation.screens.onePages

import androidx.compose.foundation.layout.*
import androidx.compose.foundation.rememberScrollState
import androidx.compose.foundation.verticalScroll
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp
import androidx.compose.ui.util.fastForEach
import com.fredprojects.ant.presentation.core.*
import com.fredprojects.ant.presentation.core.components.ImageSlider
import com.fredprojects.ant.presentation.screens.viewModels.MainArticleState

@Composable
fun Priesthood(
    state: MainArticleState,
    modifier: Modifier = Modifier
) {
    Column(modifier.padding(8.dp)) {
        state.list.fastForEach {
            if(it.articleType != ANTStrings.PRIESTHOOD) return@fastForEach
            FredTitle(it.articleType)
            Spacer(Modifier.height(4.dp))
            FredTitle(it.title)
            Spacer(Modifier.height(4.dp))
            FredText(it.description, Modifier.fillMaxHeight(0.6f).verticalScroll(rememberScrollState()))
            Spacer(Modifier.height(4.dp))
            ImageSlider(it, Modifier.fillMaxWidth())
        }
    }
}
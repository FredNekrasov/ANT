package com.fredprojects.ant.presentation.screens

import androidx.compose.runtime.Composable
import com.fredprojects.ant.presentation.core.ANTStrings
import com.fredprojects.ant.presentation.core.components.ContentList
import com.fredprojects.ant.presentation.screens.viewModels.ArticleState

@Composable
fun ParishLife(state: ArticleState) {
    ContentList(state) { it.articleType == ANTStrings.PARISH_LIFE }
}
@Composable
fun YouthClub(state: ArticleState) {
    ContentList(state) { it.articleType == ANTStrings.YOUTH_CLUB }
}
@Composable
fun Advices(state: ArticleState) {
    ContentList(state) { it.articleType == ANTStrings.ADVICES }
}
@Composable
fun History(state: ArticleState) {
    ContentList(state) { it.articleType == ANTStrings.HISTORY }
}
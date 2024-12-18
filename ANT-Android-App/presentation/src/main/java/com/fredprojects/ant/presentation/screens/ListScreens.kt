package com.fredprojects.ant.presentation.screens

import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import com.fredprojects.ant.presentation.core.components.ContentList
import com.fredprojects.ant.presentation.screens.viewModels.PagedArticleState

@Composable
fun ParishLife(
    state: PagedArticleState,
    getArticles: (Int) -> Unit,
    modifier: Modifier = Modifier
) {
    ContentList(state, getArticles, modifier)
}
@Composable
fun YouthClub(
    state: PagedArticleState,
    getArticles: (Int) -> Unit,
    modifier: Modifier = Modifier
) {
    ContentList(state, getArticles, modifier)
}
@Composable
fun Advices(
    state: PagedArticleState,
    getArticles: (Int) -> Unit,
    modifier: Modifier = Modifier
) {
    ContentList(state, getArticles, modifier)
}
@Composable
fun History(
    state: PagedArticleState,
    getArticles: (Int) -> Unit,
    modifier: Modifier = Modifier
) {
    ContentList(state, getArticles, modifier)
}
@Composable
fun Stories(
    state: PagedArticleState,
    getArticles: (Int) -> Unit,
    modifier: Modifier = Modifier
) {
    ContentList(state, getArticles, modifier)
}
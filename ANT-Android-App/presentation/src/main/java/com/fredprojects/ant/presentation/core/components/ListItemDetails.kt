package com.fredprojects.ant.presentation.core.components

import androidx.compose.foundation.layout.*
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp
import com.fredprojects.ant.domain.models.Article
import com.fredprojects.ant.presentation.core.FredText
import com.fredprojects.ant.presentation.core.FredTitle

/**
 *   Shows the details of an [Article]. The details include: type, title, date, image, and description.
 *   @param article is the article to be shown in the details
 *   @param modifier is the modifier for the layout
 */
@Composable
internal fun ListItemDetails(
    article: Article,
    modifier: Modifier = Modifier
) {
    Column(modifier, Arrangement.Center, Alignment.CenterHorizontally) {
        FredTitle(article.articleType)
        Spacer(Modifier.height(8.dp))
        FredTitle(article.title)
        Spacer(Modifier.height(4.dp))
        if(article.date.isNotBlank()) FredText(article.date, modifier = Modifier.wrapContentSize().align(Alignment.End))
        Spacer(Modifier.height(4.dp))
        ImageSlider(article = article, Modifier.fillMaxWidth())
        Spacer(Modifier.height(8.dp))
        FredText(article.description)
    }
}
package com.fredprojects.ant.presentation.core.components

import androidx.compose.foundation.border
import androidx.compose.foundation.layout.*
import androidx.compose.foundation.lazy.LazyRow
import androidx.compose.foundation.lazy.items
import androidx.compose.material3.MaterialTheme
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp
import androidx.core.net.toUri
import coil.compose.AsyncImage
import com.fredprojects.ant.domain.models.Article

/**
 *   Composable function that displays list of images
 *   @param article object of [Article]. Contains list of images
 *   @param modifier
 */
@Composable
internal fun ImageSlider(
    article: Article,
    modifier: Modifier = Modifier
) {
    LazyRow(modifier, horizontalArrangement = Arrangement.SpaceEvenly, verticalAlignment = Alignment.CenterVertically) {
        items(article.content, key = { it }) { photo ->
            AsyncImage(
                model = photo.toUri(),
                contentDescription = article.title,
                Modifier.fillMaxWidth(0.3f).fillMaxHeight(0.3f).border(2.dp, MaterialTheme.colorScheme.background)
            )
        }
    }
}
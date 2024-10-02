package com.fredprojects.ant.presentation.core

import androidx.compose.foundation.border
import androidx.compose.foundation.layout.*
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.outlined.Menu
import androidx.compose.material3.*
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.vector.ImageVector
import androidx.compose.ui.text.font.FontFamily
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.text.style.TextOverflow
import androidx.compose.ui.unit.dp
import androidx.core.net.toUri
import coil.compose.AsyncImage

@Composable
fun FredText(text: String, modifier: Modifier = Modifier, textAlign: TextAlign = TextAlign.Justify) {
    Text(
        text,
        modifier,
        fontFamily = FontFamily.Serif,
        textAlign = textAlign
    )
}
@Composable
fun FredTitle(text: String) {
    Text(
        text,
        Modifier.fillMaxWidth(),
        fontWeight = FontWeight.SemiBold,
        fontFamily = FontFamily.Serif,
        textAlign = TextAlign.Center
    )
}
@Composable
fun FredTButton(onClick: Action, text: String, modifier: Modifier = Modifier) {
    TextButton(onClick, modifier) {
        FredText(text, Modifier.wrapContentSize())
    }
}
@Composable
fun FredIconButton(onClick: Action, icon: ImageVector, description: String, modifier: Modifier = Modifier) {
    IconButton(onClick, modifier) {
        Icon(icon, description)
    }
}
@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun FredTopAppBar(openDrawer: Action) {
    TopAppBar(
        title = { FredText(ANTStrings.MAIN_TITLE) },
        Modifier.fillMaxWidth(),
        navigationIcon = { FredIconButton(openDrawer, Icons.Outlined.Menu, ANTStrings.MENU) }
    )
}
@Composable
fun FredNavigationDrawerItem(text: String, selected: Boolean, onClick: Action) {
    NavigationDrawerItem(
        label = { FredText(text) },
        selected,
        onClick,
        Modifier.fillMaxWidth(),
        shape = MaterialTheme.shapes.small,
        colors = NavigationDrawerItemDefaults.colors()
    )
}
@Composable
fun FredFloatingActionButton(onClick: Action, icon: ImageVector) {
    FloatingActionButton(
        onClick = onClick,
        modifier = Modifier.border(1.dp, MaterialTheme.colorScheme.primary, MaterialTheme.shapes.medium),
        shape = MaterialTheme.shapes.medium
    ) {
        Icon(icon, ANTStrings.SCHEDULE)
    }
}
@Composable
fun FredCard(onClick: Action, uri: String?, title: String, date: String, modifier: Modifier = Modifier) {
    Card(
        onClick,
        modifier.border(2.dp, MaterialTheme.colorScheme.primary, MaterialTheme.shapes.medium).padding(8.dp),
        shape = MaterialTheme.shapes.small,
        colors = CardDefaults.outlinedCardColors()
    ) {
        if(!uri.isNullOrBlank()) AsyncImage(model = uri.toUri(), contentDescription = title, modifier = Modifier.fillMaxWidth().fillMaxHeight(0.3f))
        Spacer(Modifier.height(4.dp))
        Text(title, Modifier.align(Alignment.CenterHorizontally).padding(horizontal = 4.dp), fontFamily = FontFamily.Serif, textAlign = TextAlign.Center, overflow = TextOverflow.Ellipsis, maxLines = 1)
        Spacer(Modifier.height(4.dp))
        FredText(date, modifier = Modifier.align(Alignment.End))
    }
}
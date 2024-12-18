package com.fredprojects.ant.presentation.screens.onePages

import androidx.compose.foundation.layout.*
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.MailOutline
import androidx.compose.material.icons.filled.Phone
import androidx.compose.material3.HorizontalDivider
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.platform.LocalUriHandler
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.unit.dp
import androidx.compose.ui.util.fastForEach
import com.fredprojects.ant.presentation.core.*
import com.fredprojects.ant.presentation.screens.viewModels.MainArticleState

@Composable
fun Sacraments(
    state: MainArticleState,
    modifier: Modifier = Modifier
) {
    val uriHandler = LocalUriHandler.current
    Column(modifier.padding(8.dp), Arrangement.Center) {
        state.list.fastForEach {
            if(it.articleType != ANTStrings.SACRAMENTS) return@fastForEach
            FredTitle(text = it.title)
            Spacer(modifier = Modifier.height(8.dp))
            FredText(text = it.description, modifier = Modifier.fillMaxWidth(), textAlign = TextAlign.Center)
        }
        Spacer(modifier = Modifier.height(8.dp))
        HorizontalDivider()
        Spacer(modifier = Modifier.height(8.dp))
        state.list.fastForEach { it ->
            if(it.articleType != ANTStrings.CONTACTS) return@fastForEach
            FredTitle(it.title)
            Spacer(modifier = Modifier.height(8.dp))
            ContactsCard(contentList = it.content) { uriHandler.openUri(it) }
        }
    }
}
/**
 * Contacts card with buttons for phone, telegram, vk, email
 * @param contentList list of the contact information
 * @param openSomeApp action for opening app like telegram, vk, gmail and phone
 */
@Composable
private inline fun ContactsCard(contentList: List<String>, crossinline openSomeApp: (String) -> Unit) {
    Row(Modifier.fillMaxWidth().wrapContentHeight(), Arrangement.SpaceEvenly, Alignment.CenterVertically) {
        FredIconButton({ openSomeApp(contentList.getNotNull(2)) }, Icons.Default.Phone)
        FredTButton({ openSomeApp(contentList.getNotNull(0)) }, ANTStrings.TELEGRAM)
        FredTButton({ openSomeApp(contentList.getNotNull(1)) }, ANTStrings.VK)
        FredIconButton({ openSomeApp(contentList.getNotNull(3)) }, Icons.Default.MailOutline)
    }
}
package com.fredprojects.ant.navigation

import androidx.compose.foundation.layout.Box
import androidx.compose.material3.CircularProgressIndicator
import androidx.compose.material3.LinearProgressIndicator
import androidx.compose.runtime.*
import androidx.compose.runtime.snapshots.SnapshotStateList
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.platform.LocalContext
import androidx.navigation.NavHostController
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import com.fredprojects.ant.presentation.core.*
import com.fredprojects.ant.presentation.screens.*
import com.fredprojects.ant.presentation.screens.onePages.*
import com.fredprojects.ant.presentation.screens.viewModels.ArticleVM
import kotlinx.coroutines.flow.collectLatest
import org.koin.androidx.compose.koinViewModel
import org.koin.core.qualifier.qualifier

@Composable
fun ANTNavHost(
    controller: NavHostController,
    openApp: (String) -> Unit,
    modifier: Modifier = Modifier,
    articleVM: ArticleVM = koinViewModel<ArticleVM>(qualifier<ArticleVM>()),
    navItems: SnapshotStateList<String> = ANTStrings.screens
) {
    val state = articleVM.articlesSF.collectAsState().value
    val context = LocalContext.current
    NavHost(navController = controller, startDestination = navItems[0]) {
        composable(navItems[0]) { MainScreen(state) }
        composable(navItems[1]) { ParishLife(state) }
        composable(navItems[2]) { Schedule(state) }
        composable(navItems[3]) { Box(modifier) { CircularProgressIndicator(Modifier.align(Alignment.Center)) } }
        composable(navItems[4]) { YouthClub(state) }
        composable(navItems[5]) { Priesthood(state) }
        composable(navItems[6]) { Advices(state) }
        composable(navItems[7]) { History(state) }
        composable(navItems[8]) { Sacraments(state) }
        composable(navItems[9]) { Contacts(state, openApp) }
        composable(navItems[10]) { Box(modifier) { LinearProgressIndicator(Modifier.align(Alignment.Center)) } }
        composable(navItems[11]) { Volunteerism(state) }
    }
    LaunchedEffect(state.status) {
        articleVM.articlesSF.collectLatest {
            if(it.status.isError()) context.displayMessage(it.status.getMessage())
        }
    }
}
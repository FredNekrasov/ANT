package com.fredprojects.ant.navigation

import androidx.compose.foundation.layout.Box
import androidx.compose.material3.CircularProgressIndicator
import androidx.compose.material3.LinearProgressIndicator
import androidx.compose.runtime.Composable
import androidx.compose.runtime.collectAsState
import androidx.compose.runtime.snapshots.SnapshotStateList
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.navigation.NavHostController
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import com.fredprojects.ant.presentation.core.ANTStrings
import com.fredprojects.ant.presentation.core.Action
import com.fredprojects.ant.presentation.screens.*
import com.fredprojects.ant.presentation.screens.onePages.*
import com.fredprojects.ant.presentation.screens.viewModels.ArticleVM

@Composable
fun ANTNavHost(
    controller: NavHostController,
    articleVM: ArticleVM,
    closeDialog: Action,
    modifier: Modifier = Modifier,
    navItems: SnapshotStateList<String> = ANTStrings.screens
) {
    val state = articleVM.articlesSF.collectAsState().value
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
        composable(navItems[9]) { Contacts(state, closeDialog, articleVM::openApp) }
        composable(navItems[10]) { Box(modifier) { LinearProgressIndicator(Modifier.align(Alignment.Center)) } }
        composable(navItems[11]) { Volunteerism(state) }
    }
}
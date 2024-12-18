package com.fredprojects.ant.navigation

import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Box
import androidx.compose.material3.CircularProgressIndicator
import androidx.compose.material3.MaterialTheme
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
import com.fredprojects.ant.presentation.screens.viewModels.*
import kotlinx.coroutines.flow.collectLatest
import org.koin.androidx.compose.koinViewModel
import org.koin.core.qualifier.qualifier

@Composable
fun ANTNavHost(
    controller: NavHostController,
    modifier: Modifier = Modifier,
    navItems: SnapshotStateList<String> = ANTStrings.screens
) {
    val mainVM: MainVM = koinViewModel(qualifier<MainVM>())
    val parishLifeVM: ParishLifeVM = koinViewModel(qualifier<ParishLifeVM>())
    val youthClubVM: YouthClubVM = koinViewModel(qualifier<YouthClubVM>())
    val advicesVM: AdvicesVM = koinViewModel(qualifier<AdvicesVM>())
    val historyVM: HistoryVM = koinViewModel(qualifier<HistoryVM>())
    val storiesVM: StoriesVM = koinViewModel(qualifier<StoriesVM>())
    val mainArticleState = mainVM.articlesSF.collectAsState().value
    val parishLifeState = parishLifeVM.articlesSF.collectAsState().value
    val youthClubState = youthClubVM.articlesSF.collectAsState().value
    val advicesState = advicesVM.articlesSF.collectAsState().value
    val historyState = historyVM.articlesSF.collectAsState().value
    val storiesState = storiesVM.articlesSF.collectAsState().value
    val context = LocalContext.current
    NavHost(navController = controller, startDestination = navItems[0]) {
        composable(navItems[0]) { MainScreen(mainArticleState, modifier) }
        composable(navItems[1]) { ParishLife(parishLifeState, parishLifeVM::getParishLifeArticles, modifier) }
        composable(navItems[2]) { Schedule(mainArticleState, modifier) }
        composable(navItems[3]) { ANTProgressIndicator(modifier) }
        composable(navItems[4]) { YouthClub(youthClubState, youthClubVM::getYouthClubArticles, modifier) }
        composable(navItems[5]) { Priesthood(mainArticleState, modifier) }
        composable(navItems[6]) { Advices(advicesState, advicesVM::getAdviceArticles, modifier) }
        composable(navItems[7]) { History(historyState, historyVM::getHistoryArticles, modifier) }
        composable(navItems[8]) { Sacraments(mainArticleState, modifier) }
        composable(navItems[9]) { ANTProgressIndicator(modifier) }
        composable(navItems[10]) { Volunteerism(mainArticleState, modifier) }
        composable(navItems[11]) { Stories(storiesState, storiesVM::getStoryArticles, modifier) }
    }
    var isLoading by remember { mutableStateOf(false) }
    LaunchedEffect(mainArticleState.status) {
        mainVM.articlesSF.collectLatest { state ->
            if(state.status.isError()) context.displayMessage(state.status.getMessage())
            isLoading = state.status.isLoading()
        }
    }
    if(isLoading) ANTProgressIndicator(modifier)
}
@Composable
private fun ANTProgressIndicator(modifier: Modifier) {
    Box(modifier.background(MaterialTheme.colorScheme.background)) { CircularProgressIndicator(Modifier.align(Alignment.Center)) }
}
package com.fredprojects.ant

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.enableEdgeToEdge
import androidx.compose.runtime.LaunchedEffect
import com.fredprojects.ant.navigation.MainEntryPoint
import com.fredprojects.ant.presentation.core.*
import com.fredprojects.ant.presentation.screens.viewModels.ArticleVM
import com.fredprojects.ant.ui.theme.ANTTheme
import kotlinx.coroutines.flow.collectLatest
import org.koin.androidx.compose.koinViewModel

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContent {
            ANTTheme {
                val articleVM = koinViewModel<ArticleVM>()
                MainEntryPoint(articleVM)
                LaunchedEffect(Unit) {
                    articleVM.articlesSF.collectLatest {
                        if(it.status.isError()) displayMessage(it.status.getMessage())
                    }
                }
            }
        }
    }
}
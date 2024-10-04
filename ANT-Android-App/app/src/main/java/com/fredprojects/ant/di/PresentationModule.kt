package com.fredprojects.ant.di

import com.fredprojects.ant.presentation.screens.viewModels.ArticleVM
import org.koin.core.module.dsl.viewModel
import org.koin.dsl.module

val presentationModule = module {
    viewModel { ArticleVM(get(), get()) }
}
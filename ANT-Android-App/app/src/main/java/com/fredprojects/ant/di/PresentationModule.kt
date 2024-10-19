package com.fredprojects.ant.di

import com.fredprojects.ant.domain.repository.IArticleRepository
import com.fredprojects.ant.presentation.screens.viewModels.ArticleVM
import org.koin.core.module.dsl.viewModel
import org.koin.core.qualifier.qualifier
import org.koin.dsl.module

val presentationModule = module {
    viewModel(qualifier = qualifier<ArticleVM>()) {
        ArticleVM(
            get(qualifier<IArticleRepository>()),
            get()
        )
    }
}
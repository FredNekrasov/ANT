package com.fredprojects.ant.di

import com.fredprojects.ant.domain.repository.IArticleRepository
import com.fredprojects.ant.presentation.screens.viewModels.*
import org.koin.core.module.dsl.viewModel
import org.koin.core.qualifier.qualifier
import org.koin.dsl.module

val presentationModule get() = module {
    viewModel(qualifier<MainVM>()) {
        MainVM(get(qualifier<IArticleRepository>()))
    }
    viewModel(qualifier<ParishLifeVM>()) {
        ParishLifeVM(get(qualifier<IArticleRepository>()))
    }
    viewModel(qualifier<YouthClubVM>()) {
        YouthClubVM(get(qualifier<IArticleRepository>()))
    }
    viewModel(qualifier<AdvicesVM>()) {
        AdvicesVM(get(qualifier<IArticleRepository>()))
    }
    viewModel(qualifier<HistoryVM>()) {
        HistoryVM(get(qualifier<IArticleRepository>()))
    }
    viewModel(qualifier<StoriesVM>()) {
        StoriesVM(get(qualifier<IArticleRepository>()))
    }
}
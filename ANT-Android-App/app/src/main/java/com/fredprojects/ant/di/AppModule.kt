package com.fredprojects.ant.di

import com.fredprojects.ant.data.di.dataModule
import org.koin.dsl.module

val appModule get() = module {
    includes(dataModule, presentationModule)
}
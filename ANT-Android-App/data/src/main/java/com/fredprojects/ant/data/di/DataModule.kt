package com.fredprojects.ant.data.di

import app.cash.sqldelight.driver.android.AndroidSqliteDriver
import com.fredprojects.ant.data.local.ANTDatabase
import com.fredprojects.ant.data.local.ArticleDao
import com.fredprojects.ant.data.repository.ArticleRepository
import com.fredprojects.ant.domain.repository.IArticleRepository
import io.ktor.client.HttpClient
import io.ktor.client.engine.okhttp.OkHttp
import io.ktor.client.plugins.contentnegotiation.ContentNegotiation
import io.ktor.client.plugins.defaultRequest
import io.ktor.client.plugins.logging.LogLevel
import io.ktor.client.plugins.logging.Logging
import io.ktor.serialization.kotlinx.json.json
import kotlinx.serialization.json.Json
import org.koin.dsl.module

val dataModule = module {
    factory { AndroidSqliteDriver(ANTDatabase.Schema, get(), "ANTDatabase.db") }
    single { ANTDatabase.invoke(get()) }
    single { ArticleDao(get()) }
    single<HttpClient>(createdAtStart = true) {
        HttpClient(OkHttp) {
            expectSuccess = true
            install(Logging) { level = LogLevel.ALL }
            install(ContentNegotiation) {
                json(
                    Json {
                        prettyPrint = true
                        isLenient = true
                    }
                )
            }
            defaultRequest { url("http://ip:port/api/") }
        }
    }
    single<IArticleRepository> { ArticleRepository(get(), get()) }
}
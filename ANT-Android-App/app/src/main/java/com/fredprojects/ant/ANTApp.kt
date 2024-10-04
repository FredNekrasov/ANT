package com.fredprojects.ant

import android.app.Application
import com.fredprojects.ant.di.appModule
import org.koin.android.ext.koin.androidContext
import org.koin.android.ext.koin.androidLogger
import org.koin.core.context.startKoin
import org.koin.core.context.stopKoin

/**
 *   Application class.
 *   Initializes Koin for dependency injection.
 *   @see appModule
 */
class ANTApp : Application() {
    override fun onCreate() {
        super.onCreate()
        startKoin {
            androidContext(this@ANTApp)
            androidLogger()
            modules(appModule)
        }
    }
    override fun onTerminate() {
        super.onTerminate()
        stopKoin()
    }
}
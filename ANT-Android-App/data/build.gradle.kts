plugins {
    alias(libs.plugins.android.library)
    alias(libs.plugins.kotlin.android)
    alias(libs.plugins.kotlin.serialization)
    alias(libs.plugins.sqldelight)
}

android {
    namespace = "com.fredprojects.ant.data"
    compileSdk = 35

    defaultConfig {
        minSdk = 26

        testInstrumentationRunner = "androidx.test.runner.AndroidJUnitRunner"
        consumerProguardFiles("consumer-rules.pro")
    }

    buildTypes {
        release {
            isMinifyEnabled = false
            proguardFiles(getDefaultProguardFile("proguard-android-optimize.txt"), "proguard-rules.pro")
        }
    }
    compileOptions {
        sourceCompatibility = JavaVersion.VERSION_17
        targetCompatibility = JavaVersion.VERSION_17
    }
    kotlinOptions {
        jvmTarget = "17"
    }
}
sqldelight {
    databases {
        create("ANTDatabase") {
            packageName = "com.fredprojects.ant.data.local"
        }
    }
}
dependencies {
    implementation(project(":domain"))
    implementation(libs.koin.core)
    implementation(libs.bundles.network)
    implementation(libs.bundles.database)
    testImplementation(libs.junit)
    androidTestImplementation(libs.androidx.junit)
}
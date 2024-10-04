plugins {
    alias(libs.plugins.android.library)
    alias(libs.plugins.kotlin.android)
    alias(libs.plugins.kotlin.compose)
}

android {
    namespace = "com.fredprojects.ant.presentation"
    compileSdk = 34

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
composeCompiler {
    stabilityConfigurationFile = layout.buildDirectory.file("composeStabilityConfig.json")
    reportsDestination = layout.buildDirectory.dir("composeCompiler")
    metricsDestination = layout.buildDirectory.dir("composeMetrics")
}
dependencies {
    implementation(project(":domain"))
    implementation(platform(libs.androidx.compose.bom))
    implementation(libs.bundles.presentation)
    testImplementation(libs.junit)
    androidTestImplementation(libs.androidx.junit)
}
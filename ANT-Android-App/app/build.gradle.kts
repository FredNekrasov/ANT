plugins {
    alias(libs.plugins.android.application)
    alias(libs.plugins.kotlin.android)
    alias(libs.plugins.kotlin.compose)
    alias(libs.plugins.kotlin.serialization)
}

android {
    namespace = "com.fredprojects.ant"
    compileSdk = 35

    defaultConfig {
        applicationId = "com.fredprojects.ant"
        minSdk = 26
        targetSdk = 35
        versionCode = 1
        versionName = "1.0"

        testInstrumentationRunner = "androidx.test.runner.AndroidJUnitRunner"
        vectorDrawables {
            useSupportLibrary = true
        }
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
    buildFeatures {
        compose = true
    }
    packaging {
        resources {
            excludes += "/META-INF/{AL2.0,LGPL2.1}"
        }
    }
}
composeCompiler {
    stabilityConfigurationFiles.add(rootProject.layout.projectDirectory.file("composeStabilityConfig.conf"))
    reportsDestination = layout.buildDirectory.dir("composeCompiler")
    metricsDestination = layout.buildDirectory.dir("composeMetrics")
}
dependencies {
    implementation(project(":domain"))
    implementation(project(":data"))
    implementation(project(":presentation"))

    implementation(libs.bundles.koin)
    implementation(libs.bundles.navigation)
    implementation(platform(libs.androidx.compose.bom))
    implementation(libs.bundles.app)
    // test
    testImplementation(libs.bundles.test)
    androidTestImplementation(platform(libs.androidx.compose.bom))
    androidTestImplementation(libs.bundles.android.test)
    debugImplementation(libs.androidx.ui.tooling)
    debugImplementation(libs.androidx.ui.test.manifest)
}
package com.fredprojects.ant

import android.content.Intent
import android.net.Uri
import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.enableEdgeToEdge
import com.fredprojects.ant.navigation.MainEntryPoint
import com.fredprojects.ant.ui.theme.ANTTheme

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContent {
            ANTTheme {
                MainEntryPoint { url -> startActivity(Intent(Intent.ACTION_VIEW, Uri.parse(url))) }
            }
        }
    }
}
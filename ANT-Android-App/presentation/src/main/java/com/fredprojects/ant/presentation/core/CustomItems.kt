package com.fredprojects.ant.presentation.core

import android.content.Context
import android.widget.Toast
import com.fredprojects.ant.domain.utils.ConnectionStatus
import com.fredprojects.ant.domain.utils.ConnectionStatus.*

fun Context.displayMessage(
    message: String, duration: Int = Toast.LENGTH_SHORT
): Unit = Toast.makeText(this, message, duration).show()
fun ConnectionStatus.getMessage(): String = when(this) {
    CONNECTION_ERROR -> ANTStrings.CONNECTION_ERROR
    NO_INTERNET -> ANTStrings.NO_INTERNET
    NO_DATA -> ANTStrings.NO_DATA
    SERIALIZATION_ERROR -> ANTStrings.SERIALIZATION_ERROR
    UNKNOWN -> ANTStrings.UNKNOWN
    else -> ""
}
fun ConnectionStatus.isError(): Boolean = (this != SUCCESS) && (this != LOADING)
fun ConnectionStatus.isLoading(): Boolean = this == LOADING
fun List<String>.getNotNull(index: Int): String = this.getOrNull(index) ?: ""
// creating aliases for convenience and simplification
typealias Action = () -> Unit
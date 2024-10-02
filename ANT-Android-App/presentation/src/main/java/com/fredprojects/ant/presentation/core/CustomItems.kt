package com.fredprojects.ant.presentation.core

import android.content.Context
import android.widget.Toast
import com.fredprojects.ant.domain.utils.ConnectionStatus
import com.fredprojects.ant.domain.utils.ConnectionStatus.*

fun Context.displayMessage(
    message: String, duration: Int = Toast.LENGTH_SHORT
) = Toast.makeText(this, message, duration).show()
fun ConnectionStatus.getMessage() = when(this) {
    CONNECTION_ERROR -> ANTStrings.CONNECTION_ERROR
    NO_INTERNET -> ANTStrings.NO_INTERNET
    NO_DATA -> ANTStrings.NO_DATA
    SERIALIZATION_ERROR -> ANTStrings.SERIALIZATION_ERROR
    UNKNOWN -> ANTStrings.UNKNOWN
    else -> ""
}
fun ConnectionStatus.isError() = (this != SUCCESS) && (this != LOADING)
fun List<String>.getNotNull(index: Int): String = this.getOrNull(index).toString()
// creating aliases for convenience and simplification
typealias SAction = (String) -> Unit
typealias Action = () -> Unit
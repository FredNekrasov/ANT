package com.fredprojects.ant.domain.utils

/**
 * Enum class for connection status
 *
 * @property LOADING when data is being received from server
 * @property SUCCESS when data is received from server
 * @property CONNECTION_ERROR when server is not responding correctly
 * @property NO_INTERNET when there is no internet connection
 * @property NO_DATA when no data is received from server
 * @property SERIALIZATION_ERROR when data is not serialized correctly
 * @property UNKNOWN when unknown error happened
 **/
enum class ConnectionStatus {
    LOADING, SUCCESS, CONNECTION_ERROR, NO_INTERNET, NO_DATA, SERIALIZATION_ERROR, UNKNOWN
}
package com.fredprojects.ant.domain.utils

/**
 * Represents the status of an action.
 *
 * @param M The type of the list of items being passed around.
 * @property list The list of items associated with this status.
 * @property status The status of the action.
 */
sealed class ActionStatus<M>(val list: List<M>, val status: ConnectionStatus) {
    class Loading<M>(list: List<M>) : ActionStatus<M>(list, ConnectionStatus.LOADING)
    class Success<M>(list: List<M>) : ActionStatus<M>(list, ConnectionStatus.SUCCESS)
    class Error<M>(list: List<M>, status : ConnectionStatus) : ActionStatus<M>(list, status)
}
package com.fredprojects.ant.domain.repository

import com.fredprojects.ant.domain.models.Article
import com.fredprojects.ant.domain.utils.ActionStatus
import kotlinx.coroutines.flow.Flow

/**
 * This interface defines the contract for a repository that manages a list of articles.
 * It provides a method `getList()` that returns a flow of `ActionStatus<Article>`.
 **/
interface IArticleRepository {
    /**
     * Retrieves the list of articles as a flow of `ActionStatus<Article>`.
     *
     * The flow represents a sequence of values that can be observed over time.
     * Each value in the flow represents the status of retrieving the list of articles.
     * The status can be one of the following:
     * - `Loading`: Indicates that the retrieval process is in progress.
     * - `Success`: Indicates that the retrieval process was successful and the list of articles is available.
     * - `Error`: Indicates that an error occurred during the retrieval process.
     *
     * The flow allows the caller to react to changes in the status of retrieving the list of articles.
     *
     * @param catalogId The ID of the catalog to retrieve the list of articles from the server.
     * @param pageNumber The page number to retrieve the list of articles from the server.
     *
     * @return A flow of `ActionStatus<Article>`.
     **/
    fun getList(catalogId: Int, pageNumber: Int) : Flow<ActionStatus<Article>>
}
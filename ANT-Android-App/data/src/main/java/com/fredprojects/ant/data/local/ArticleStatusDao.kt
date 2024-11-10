package com.fredprojects.ant.data.local

import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.withContext

/**
 * ArticleStatusDao is used for working with the database
 * @param db is an ANTDatabase class
 */
class ArticleStatusDao(
    private val db: ANTDatabase
) {
    /**
     * Get all article status from the database
     * @return List of articles
     */
    suspend fun getAllArticleStatus(): List<ArticleStatusEntity> = withContext(Dispatchers.IO) {
        db.articleStatusQueries.getAllArticleStatusData().executeAsList()
    }
    /**
     * Upsert article in the database
     * @param articleStatus is an ArticleStatus class that will be inserted in the database if it doesn't exist or updated otherwise
     */
    suspend fun upsertArticle(articleStatus: ArticleStatusEntity) = withContext(Dispatchers.IO) {
        db.articleStatusQueries.upsertArticleStatus(articleStatus)
    }
    /**
     * Delete article from the database
     * @param id is an ID of the article that will be deleted
     */
    suspend fun deleteArticle(id: Long) = withContext(Dispatchers.IO) {
        db.articleStatusQueries.deleteArticleStatus(id)
    }
}
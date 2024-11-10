package com.fredprojects.ant.data.local

import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.withContext

/**
 * ArticleDao is used for working with the database
 * @param db is an ANTDatabase class
 */
class ArticleDao(
    private val db: ANTDatabase
) {
    /**
     * Get all articles from the database
     * @return List of articles
     */
    suspend fun getAllArticles(): List<ArticleEntity> = withContext(Dispatchers.IO) {
        db.articleQueries.getAllArticles().executeAsList()
    }
    /**
     * Upsert article in the database
     * @param article is an Article class that will be inserted in the database if it doesn't exist or updated otherwise
     */
    suspend fun upsertArticle(article: ArticleEntity) = withContext(Dispatchers.IO) {
        db.articleQueries.upsertArticle(article)
    }
    /**
     * Delete article from the database
     * @param id is an ID of the article that will be deleted
     */
    suspend fun deleteArticle(id: Long) = withContext(Dispatchers.IO) {
        db.articleQueries.deleteArticle(id)
    }
}

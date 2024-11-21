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
     * Get count all articles from the database
     * @return Long
     */
    suspend fun getCountAllArticles(): Long = withContext(Dispatchers.IO) {
        db.articleQueries.getCountAllArticles().executeAsOne()
    }
    /**
     * Get articles by catalog from the database
     * @param catalogId is an ID of the catalog
     * @return List of articles
     */
    suspend fun getArticlesByCatalog(catalogId: Int): List<ArticleEntity> = withContext(Dispatchers.IO) {
        val catalog = db.articleQueries.getAllArticleTypes().executeAsList()[catalogId]
        db.articleQueries.getArticlesByCatalog(catalog).executeAsList()
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

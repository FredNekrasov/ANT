package com.fredprojects.ant.data.local

import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.withContext

class ArticleDao(
    private val db: ANTDatabase
) {
    suspend fun getAllArticles() = withContext(Dispatchers.IO) {
        db.articleDaoQueries.getAllArticles().executeAsList()
    }
    suspend fun upsertArticle(article: ArticleEntity) = withContext(Dispatchers.IO) {
        db.articleDaoQueries.upsertArticle(article)
    }
    suspend fun deleteArticle(id: Long) = withContext(Dispatchers.IO) {
        db.articleDaoQueries.deleteArticle(id)
    }
}

package com.fredprojects.ant.data.remote.dto

/**
 * ArticleResponse would be received from the server
 * @param pageNumber is a number of the page
 * @param pageSize is a size of the page
 * @param totalRecords is a total number of records
 * @param data is a list of articles
 */
data class ArticleResponse(
    val pageNumber: Int,
    val pageSize: Int,
    val totalRecords: Int,
    val data: List<ArticleDto>
)
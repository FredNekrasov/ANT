package com.fredprojects.ant.domain.models

/**
 * Data class for Article model used in domain layer of the application
 *  @param title article title
 *  @param description article description
 *  @param date date or banner of the article
 *  @param articleType type of the article
 *  @param content is in the form of a list of lines with links to images or contact information
 *  @param id id of the article
 */
data class Article(
    val title: String,
    val description: String,
    val date: String,
    val articleType: String,
    val content: List<String>,
    val id: Long = 0
)
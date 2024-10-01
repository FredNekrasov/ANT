package com.fredprojects.ant.data.remote.dto

import kotlinx.serialization.Serializable

/**
 *  The data transfer object for articles received from the server
 *  @param id is a unique id of the article
 *  @param catalog is a type of the article (see [CatalogDto])
 *  @param title is a title of the article
 *  @param description is a description of the article
 *  @param dateOrBanner is a date or a banner of the article
 *  @param content is a list of strings representing the content of the article
 */
@Serializable
data class ArticleDto(
    val id: Long,
    val catalog: CatalogDto,
    val title: String,
    val description: String,
    val dateOrBanner: String,
    val content: List<String>
)
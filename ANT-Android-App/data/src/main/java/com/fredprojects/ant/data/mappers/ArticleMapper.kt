package com.fredprojects.ant.data.mappers

import com.fredprojects.ant.data.local.ArticleEntity
import com.fredprojects.ant.data.remote.dto.ArticleDto
import com.fredprojects.ant.domain.models.Article
import kotlinx.serialization.json.Json

/**
 *  Mapper for mapping ArticleDto to Article and vice versa
 *  @return Article
 */
fun ArticleDto.toModel() = Article(
    title = title,
    description = description,
    date = dateOrBanner,
    articleType = catalog.name,
    content = content,
    id = id
)
/**
 *  Mapper for mapping ArticleDto to ArticleEntity and vice versa
 *  @return ArticleEntity
 */
fun ArticleDto.toEntity(catalogId: Int, pageNumber: Int) = ArticleEntity(
    id = id,
    title = title,
    description = description,
    date = dateOrBanner,
    articleType = catalog.name,
    pageNumber = pageNumber.toLong(),
    catalogId = catalogId.toLong(),
    content = Json.encodeToString(content)
)
/**
 *  Mapper for mapping ArticleEntity to Article and vice versa
 *  @return Article
 */
fun ArticleEntity.toModel() = Article(
    title = title,
    description = description,
    date = date,
    articleType = articleType,
    content = Json.decodeFromString<List<String>>(content),
    id = id
)
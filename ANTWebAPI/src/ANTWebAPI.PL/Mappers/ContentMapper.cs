﻿using ANTWebAPI.BLL.Models;
using ANTWebAPI.PL.DTOs;

namespace ANTWebAPI.PL.mappers;

/*
 * Content mapper defines extension methods to map ContentDTO into the Content model and vice versa
 */
public static class ContentMapper
{
    public static ContentDTO ToDto(this Content content) => new()
    {
        Id = content.Id,
        ArticleId = content.ArticleId,
        Data = content.Data
    };
    public static Content ToModel(this ContentDTO contentDto) => new()
    {
        Id = contentDto.Id,
        ArticleId = contentDto.ArticleId,
        Data = contentDto.Data
    };
}

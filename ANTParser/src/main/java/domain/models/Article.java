package domain.models;

public record Article(
    Catalog catalog,
    String title,
    String description,
    String dateOrBanner,
    Long id
) {}

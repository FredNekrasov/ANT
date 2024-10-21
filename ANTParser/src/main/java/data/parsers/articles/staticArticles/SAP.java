package data.parsers.articles.staticArticles;

import data.parsers.articles.staticArticles.impl.*;

public record SAP(
    MainPageParser mainPageParser,
    PriesthoodParser priesthoodParser,
    ScheduleParser scheduleParser,
    SacramentParser sacramentParser,
    ContactParser contactParser,
    VolunteerismParser volunteerismParser
) {}// static article parsers

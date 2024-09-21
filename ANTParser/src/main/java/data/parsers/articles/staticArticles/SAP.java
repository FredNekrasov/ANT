package data.parsers.articles.staticArticles;

import data.parsers.articles.staticArticles.impl.*;
import jakarta.inject.Inject;

public record SAP(
    MainPageParser mainPageParser,
    PriesthoodParser priesthoodParser,
    ScheduleParser scheduleParser,
    SacramentParser sacramentParser,
    ContactParser contactParser,
    VolunteerismParser volunteerismParser
) {// static article parsers
    @Inject public SAP {}
}

package data.parsers.articles.dynamicArticles;

import data.parsers.articles.dynamicArticles.impl.*;
import jakarta.inject.Inject;

public record DAP(
	Advices advices,
    History history,
    ParishLife parishLife,
    YouthClub youthClub
) {// dynamic article parsers
	@Inject public DAP {}
}
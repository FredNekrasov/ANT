package data.parsers.articles.dynamicArticles;

import data.parsers.articles.dynamicArticles.impl.*;

public record DAP(
	Advices advices,
    History history,
    ParishLife parishLife,
    YouthClub youthClub
) {}// dynamic article parsers
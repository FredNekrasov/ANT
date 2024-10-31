package data.parsers.articles.dynamicArticles;

import data.parsers.articles.dynamicArticles.impl.*;

public record DAP(
	Advice advice,
    History history,
    ParishLife parishLife,
    YouthClub youthClub
) {}// dynamic article parsers
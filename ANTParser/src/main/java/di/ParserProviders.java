package di;

import dagger.Module;
import dagger.Provides;
import data.parsers.Parsers;
import data.parsers.articles.ArticleParsers;
import data.parsers.articles.dynamicArticles.DAP;
import data.parsers.articles.dynamicArticles.impl.*;
import data.parsers.articles.staticArticles.SAP;
import data.parsers.articles.staticArticles.impl.*;
import data.parsers.catalogs.CatalogParser;

@Module
public class ParserProviders {
	@Provides
	public DAP provideDAP(Advices advices, History history, ParishLife parishLife, YouthClub youthClub) {
		return new DAP(advices, history, parishLife, youthClub);
	}
	@Provides
	public SAP provideSAP(
		MainPageParser mainPage,
		PriesthoodParser priesthood,
		ScheduleParser schedule,
		SacramentParser sacrament,
		ContactParser contactParser,
		VolunteerismParser volunteerism
	) {
		return new SAP(mainPage, priesthood, schedule, sacrament, contactParser, volunteerism);
	}
	@Provides
	public ArticleParsers provideArticleParsers(DAP dap, SAP sap) {
		return new ArticleParsers(dap, sap);
	}
	@Provides
	public Parsers provideParsers(ArticleParsers articleParsers, CatalogParser catalogParser) {
		return new Parsers(catalogParser, articleParsers);
	}
}

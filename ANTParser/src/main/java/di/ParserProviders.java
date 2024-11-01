package di;

import dagger.Module;
import dagger.Provides;
import data.parsers.Parsers;
import data.parsers.articles.dynamicArticles.DAP;
import data.parsers.articles.dynamicArticles.impl.*;
import data.parsers.articles.staticArticles.SAP;
import data.parsers.articles.staticArticles.impl.*;
import data.parsers.catalogs.CatalogParser;

@Module
public class ParserProviders {
	@Provides
	public DAP provideDAP(PAS PAS, HYC HYC, ParishLife parishLife) {
		return new DAP(PAS, HYC, parishLife);
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
	public Parsers provideParsers(DAP dap, SAP sap, CatalogParser catalogParser) {
		return new Parsers(catalogParser, dap, sap);
	}
}

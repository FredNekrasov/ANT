package di;

import dagger.Module;
import dagger.Provides;
import data.parsers.Parsers;
import presentation.commands.*;

@Module
public class MenuProvider {
	@Provides
	public Menu provideMenu(
		CatalogCommands catalogCommands,
		ArticleCommands articleCommands,
		ContentCommands contentCommands,
		Parsers parsers
	) {
		return new Menu(catalogCommands, articleCommands, contentCommands, parsers);
	}
}

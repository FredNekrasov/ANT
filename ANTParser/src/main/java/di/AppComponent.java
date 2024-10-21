package di;

import dagger.Component;

@Component(modules = { NetworkProvider.class, RepositoryBinder.class, ParserProviders.class, MenuProvider.class })
public interface AppComponent {
	Menu getMenu();
}

package di;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import dagger.Module;
import dagger.Provides;

import javax.inject.Singleton;
import java.net.http.HttpClient;
import java.time.Duration;

@Module
public class NetworkProvider {
    @Singleton
    @Provides
    public HttpClient provideHttpClient() {
        return HttpClient.newBuilder()
                .version(HttpClient.Version.HTTP_1_1)
                .connectTimeout(Duration.ofMinutes(1))
                .followRedirects(HttpClient.Redirect.NEVER)
                .build();
    }
    @Singleton
    @Provides
    public Gson provideGson() {
        return new GsonBuilder().setPrettyPrinting().create();
    }
}

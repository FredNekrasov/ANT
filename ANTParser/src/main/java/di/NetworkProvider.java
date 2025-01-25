package di;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import dagger.Module;
import dagger.Provides;

import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.time.Duration;

@Module
public class NetworkProvider {
    @Provides
    public HttpRequest.Builder provideHttpRequestBuilder() {
        return HttpRequest.newBuilder();
    }
    @Provides
    public HttpClient provideHttpClient() {
        return HttpClient.newBuilder()
                .version(HttpClient.Version.HTTP_1_1)
                .connectTimeout(Duration.ofMinutes(1))
                .followRedirects(HttpClient.Redirect.NEVER)
                .build();
    }
    @Provides
    public Gson provideGson() {
        return new GsonBuilder().setPrettyPrinting().create();
    }
}

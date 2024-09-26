package data.remote.api;

import jakarta.inject.Inject;

import java.net.URI;
import java.net.http.HttpRequest;

public final class HttpRequests {
    private final HttpRequest.Builder request = HttpRequest.newBuilder();
    @Inject public HttpRequests() {}
    public HttpRequest get(String url) {
        return request.uri(URI.create(url)).GET().build();
    }
    public HttpRequest post(String url, String body) {
        return request.uri(URI.create(url))
                .header("Content-Type", "application/json")
                .POST(HttpRequest.BodyPublishers.ofString(body))
                .build();
    }
    public HttpRequest put(String url, String body) {
        return request.uri(URI.create(url))
                .header("Content-Type", "application/json")
                .PUT(HttpRequest.BodyPublishers.ofString(body))
                .build();
    }
    public HttpRequest delete(String url) {
        return request.uri(URI.create(url)).DELETE().build();
    }
}

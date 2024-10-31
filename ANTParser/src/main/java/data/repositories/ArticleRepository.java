package data.repositories;

import com.google.gson.Gson;
import com.google.gson.JsonSyntaxException;
import data.remote.api.HttpRequests;
import domain.models.Article;
import domain.repository.IRepository;
import jakarta.inject.Inject;

import java.io.IOException;
import java.net.http.HttpClient;
import java.net.http.HttpResponse;
import java.util.Arrays;
import java.util.List;

public final class ArticleRepository implements IRepository<Article> {
    private final HttpClient client;
    private final HttpRequests httpRequests;
    private final Gson gson;
    @Inject
    public ArticleRepository(HttpClient httpClient, HttpRequests httpRequests, Gson gson) {
        this.client = httpClient;
        this.httpRequests = httpRequests;
        this.gson = gson;
    }
    @Override
    public List<Article> getAll() {
		try {
			var response = client.send(httpRequests.get("http://localhost:5145/api/v1/Article"), HttpResponse.BodyHandlers.ofString());
            if (response.statusCode() == 204) return List.of();
            return Arrays.stream(gson.fromJson(response.body(), Article[].class)).toList();
		} catch (IOException | InterruptedException | JsonSyntaxException e) {
            System.out.println("article repository getAll(): " + e.getMessage());
			throw new RuntimeException(e);
		}
    }
    @Override
    public void insert(Article model) {
        try {
            var response = client.send(httpRequests.post("http://localhost:5145/api/v1/Article", gson.toJson(model)), HttpResponse.BodyHandlers.ofString());
            System.out.println(response.statusCode());
        } catch (IOException | InterruptedException e) {
            System.out.println("article repository insert(): " + e.getMessage());
            throw new RuntimeException(e);
        }
    }
    @Override
    public void update(Article model) {
        try {
            var response = client.send(httpRequests.put("http://localhost:5145/api/v1/Article/" + model.id(), gson.toJson(model)), HttpResponse.BodyHandlers.ofString());
            System.out.println(response.statusCode());
        } catch (IOException | InterruptedException e) {
            System.out.println("article repository insert(): " + e.getMessage());
            throw new RuntimeException(e);
        }
    }
    @Override
    public void delete(long id) {
        try {
            var response = client.send(httpRequests.delete("http://localhost:5145/api/v1/Article/" + id), HttpResponse.BodyHandlers.ofString());
            System.out.println(response.statusCode());
        } catch (IOException | InterruptedException e) {
            System.out.println("article repository insert(): " + e.getMessage());
            throw new RuntimeException(e);
        }
    }
    @Override
    public Article getById(long id) {
        try {
            var response = client.send(httpRequests.get("http://localhost:5145/api/v1/Article/" + id), HttpResponse.BodyHandlers.ofString());
            System.out.println(response.statusCode());
            return gson.fromJson(response.body(), Article.class);
        } catch (IOException | InterruptedException | JsonSyntaxException e) {
            System.out.println("article repository insert(): " + e.getMessage());
            throw new RuntimeException(e);
        }
    }
}

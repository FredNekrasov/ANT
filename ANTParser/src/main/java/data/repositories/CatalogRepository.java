package data.repositories;

import com.google.gson.Gson;
import com.google.gson.JsonSyntaxException;
import data.remote.api.HttpRequests;
import domain.models.Catalog;
import domain.repository.IRepository;
import jakarta.inject.Inject;

import java.io.IOException;
import java.net.http.HttpClient;
import java.net.http.HttpResponse;
import java.util.Arrays;
import java.util.List;

public final class CatalogRepository implements IRepository<Catalog> {
    private final HttpClient client;
    private final HttpRequests httpRequests;
    private final Gson gson;
    @Inject
    public CatalogRepository(HttpClient httpClient, HttpRequests httpRequests, Gson gson) {
        this.client = httpClient;
        this.httpRequests = httpRequests;
        this.gson = gson;
    }
    @Override
    public List<Catalog> getAll() {
		try {
			var response = client.send(httpRequests.get("http://localhost:5145/api/v1/Catalog"), HttpResponse.BodyHandlers.ofString());
			if (response.statusCode() == 204) return List.of();
			return Arrays.stream(gson.fromJson(response.body(), Catalog[].class)).toList();
		} catch (IOException | InterruptedException | JsonSyntaxException e) {
			System.out.println("catalog repository getAll(): " + e.getMessage());
			throw new RuntimeException(e);
		}
    }
    @Override
    public void insert(Catalog model) {
        try {
			var response = client.send(httpRequests.post("http://localhost:5145/api/v1/Catalog", gson.toJson(model)), HttpResponse.BodyHandlers.ofString());
			System.out.println(response.statusCode());
        } catch (IOException | InterruptedException e) {
            System.out.println("catalog repository insert(): " + e.getMessage());
            throw new RuntimeException(e);
        }
    }
    @Override
    public void update(Catalog model) {
		try {
			var response = client.send(httpRequests.put("http://localhost:5145/api/v1/Catalog", gson.toJson(model)), HttpResponse.BodyHandlers.ofString());
			System.out.println(response.statusCode());
		} catch (IOException | InterruptedException e) {
			System.out.println("catalog repository insert(): " + e.getMessage());
			throw new RuntimeException(e);
		}
    }
    @Override
    public void delete(long id) {
		try {
			var response = client.send(httpRequests.delete("http://localhost:5145/api/v1/Catalog/" + id), HttpResponse.BodyHandlers.ofString());
			System.out.println(response.statusCode());
		} catch (IOException | InterruptedException e) {
			System.out.println("catalog repository insert(): " + e.getMessage());
			throw new RuntimeException(e);
		}
    }
    @Override
    public Catalog getById(long id) {
		try {
			var response = client.send(httpRequests.get("http://localhost:5145/api/v1/Catalog/" + id), HttpResponse.BodyHandlers.ofString());
			System.out.println(response.statusCode());
			return gson.fromJson(response.body(), Catalog.class);
		} catch (IOException | InterruptedException | JsonSyntaxException e) {
            System.out.println("catalog repository getById(): " + e.getMessage());
			throw new RuntimeException(e);
		}
	}
}

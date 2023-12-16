﻿using System.Net.Http.Headers;
using System.Net.Http.Json;
using MangaShop.Data.Enum;
using MangaShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace MangaShopAPIConsoleApp
{
    class Program
    {
        private static HttpClient httpClient;
        static async Task Main()
        {
                httpClient = new HttpClient
                {
                    BaseAddress = new Uri("http://localhost:5233/")
                };
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                await GetAllMangaAsync();

                var newManga = new Manga
                {
                    Title = "New Manga",
                    VolumeImage = "new-manga-image.jpg",
                    Description = "Description of the new manga",
                    Author = "Author Name",
                    MangaCategory = MangaCategory.Shonen,
                    Genre = Genre.Adventure,
                    Volume = 1,
                    DatePublished = DateTime.Now,
                    Price = 9.99M
                };

                Manga createdManga = await CreateMangaAsync(newManga);

                await GetMangaByIdAsync(createdManga.Id);

                await GetAllMangaAsync();

                var mangaToUpdate = await GetMangaByIdAsync(createdManga.Id);
                if (mangaToUpdate != null)
                {
                    mangaToUpdate.Title = "Updated Manga Title";
                    await UpdateMangaAsync(mangaToUpdate.Id, mangaToUpdate);
                }

                await GetAllMangaAsync();

                await DeleteMangaAsync(createdManga.Id);

                await GetAllMangaAsync();
        }
        static async Task GetAllMangaAsync()
        {
            Console.WriteLine("Getting all manga...");
            HttpResponseMessage response = await httpClient.GetAsync("api/Manga");
            response.EnsureSuccessStatusCode();

            var mangaList = await response.Content.ReadAsAsync<IEnumerable<Manga>>();
            Console.WriteLine("All manga:");
            foreach (var manga in mangaList)
            {
                Console.WriteLine($"Id: {manga.Id}, Title: {manga.Title}");
            }
            Console.WriteLine();
        }

        static async Task<Manga> GetMangaByIdAsync(int id)
        {
            Console.WriteLine($"Getting manga by Id: {id}...");
            HttpResponseMessage response = await httpClient.GetAsync($"api/Manga/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Manga>();
            }
            else
            {
                Console.WriteLine($"Manga not found. Status Code: {response.StatusCode}");
                return null;
            }
        }

        static async Task<Manga> CreateMangaAsync(Manga newManga)
        {
            Console.WriteLine("Creating new manga...");
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("api/Manga", newManga);
            response.EnsureSuccessStatusCode();

            // Read the created manga with the assigned Id from the response
            Manga createdManga = await response.Content.ReadFromJsonAsync<Manga>();

            Console.WriteLine("New manga created successfully.");
            Console.WriteLine();

            // Return the created manga
            return createdManga;
        }

        static async Task UpdateMangaAsync(int id, Manga updatedManga)
        {
            Console.WriteLine($"Updating manga with Id: {id}...");
            HttpResponseMessage response = await httpClient.PutAsJsonAsync($"api/Manga/{id}", updatedManga);
            response.EnsureSuccessStatusCode();
            Console.WriteLine("Manga updated successfully.");
            Console.WriteLine();
        }

        static async Task DeleteMangaAsync(int id)
        {
            Console.WriteLine($"Deleting manga with Id: {id}...");
            HttpResponseMessage response = await httpClient.DeleteAsync($"api/Manga/{id}");
            response.EnsureSuccessStatusCode();
            Console.WriteLine("Manga deleted successfully.");
            Console.WriteLine();
        }
    }
}
using System.Net.Http.Json;
using Budzetownik.Model;

namespace Budzetownik.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://budzetownikrest-c2b7c7a5fcckfkes.polandcentral-01.azurewebsites.net/api/")
        };
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<List<Category>>("Category");
        return response ?? new();
    }

    public async Task<bool> AddCategoryAsync(Category category)
    {
        var response = await _httpClient.PostAsJsonAsync("Category", category);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> AddExpenseAsync(Expense expense, FileResult? imageFile)
    {
        using var content = new MultipartFormDataContent();

        content.Add(new StringContent(expense.Description ?? ""), "Description");
        content.Add(new StringContent(expense.Amount.ToString()), "Amount");
        content.Add(new StringContent(expense.CategoryId.ToString()), "CategoryId");

        if (imageFile != null)
        {
            var stream = await imageFile.OpenReadAsync();
            var fileContent = new StreamContent(stream);
            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            content.Add(fileContent, "ImageFile", imageFile.FileName);
        }

        var response = await _httpClient.PostAsync("Expense", content);

        return response.IsSuccessStatusCode;
    }

}
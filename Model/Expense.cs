using System.Text.Json;

namespace Budzetownik.Model
{
    public class Expense
    {
        public int Id { get; set; }
        public string Description { get; set; } = "";
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public string? ImageName { get; set; }
        public DateTime Date { get; set; }
        public string? FoundItems { get; set; }
        public List<FoundItem>? ParsedItems =>
            string.IsNullOrEmpty(FoundItems)
                ? new List<FoundItem>()
                : JsonSerializer.Deserialize<List<FoundItem>>(FoundItems);
    }
}

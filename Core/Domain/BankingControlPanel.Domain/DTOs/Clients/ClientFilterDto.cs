namespace BankingControlPanel.Domain.DTOs.Clients
{
    public class ClientFilterDto
    {
        public string? SearchTerm { get; set; }
        public string? SortBy { get; set; }
        public int PageSize { get; set; } = 20;

        public List<string> LastSearches { get; set; } = new List<string>();
        public bool IsAscending { get; set; }
        public int PageIndex { get; set; } = 0;
    }
}
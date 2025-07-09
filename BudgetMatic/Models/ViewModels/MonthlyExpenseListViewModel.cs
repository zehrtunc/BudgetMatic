namespace BudgetMatic.Models.ViewModels
{
    public class MonthlyExpenseListViewModel
    {
        public long Id { get; set; }
        public string CategoryName { get; set; }

        public decimal?[] MonthlyAmounts { get; set; } = new decimal?[12];

        public string? Note { get; set; }

    }
}

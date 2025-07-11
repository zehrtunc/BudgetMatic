using BudgetMatic.Models.Enums;

namespace BudgetMatic.Models.ViewModels
{
    public class ExpenseListViewModel
    {
        public DateTime StartDate { get; set; }

        public string CategoryName { get; set; }

        public string? Note { get; set; }

        public decimal TotalAmount { get; set; }

        public string PaymentType { get; set; }

        public int? InstallmentCount { get; set; }

    }
}

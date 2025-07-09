using System.ComponentModel;

namespace BudgetMatic.Models.Enums
{
    public enum PaymentType
    {
        [Description("Peşin")]
        OneTime = 1,

        [Description("Taksit")]
        Installment = 2,

        [Description("Abonelik veya Düzenli Ödeme")]
        Subscription = 3
    }
}

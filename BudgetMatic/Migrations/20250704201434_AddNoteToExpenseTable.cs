using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetMatic.Migrations
{
    /// <inheritdoc />
    public partial class AddNoteToExpenseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "ExpenseItems");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Expenses");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "ExpenseItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

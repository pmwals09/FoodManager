using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddShoppingListAndItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MenuId",
                table: "Recipes",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<double>(
                name: "Servings",
                table: "Ingredients",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "CollectionName",
                table: "FoodItems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ServingsPerCollection",
                table: "FoodItems",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "CollectionName",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "ServingsPerCollection",
                table: "FoodItems");

            migrationBuilder.AlterColumn<decimal>(
                name: "Servings",
                table: "Ingredients",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");
        }
    }
}

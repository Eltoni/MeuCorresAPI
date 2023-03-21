using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevIO.Data.Migrations
{
    public partial class ll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Corridas_Veiculos_VeiculoId1",
                table: "Corridas");

            migrationBuilder.DropIndex(
                name: "IX_Corridas_VeiculoId1",
                table: "Corridas");

            migrationBuilder.DropColumn(
                name: "VeiculoId1",
                table: "Corridas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VeiculoId1",
                table: "Corridas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Corridas_VeiculoId1",
                table: "Corridas",
                column: "VeiculoId1",
                unique: true,
                filter: "[VeiculoId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Corridas_Veiculos_VeiculoId1",
                table: "Corridas",
                column: "VeiculoId1",
                principalTable: "Veiculos",
                principalColumn: "Id");
        }
    }
}

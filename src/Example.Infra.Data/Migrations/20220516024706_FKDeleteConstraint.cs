using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example.Infra.Data.Migrations
{
    public partial class FKDeleteConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidade",
                schema: "dbo",
                table: "Pessoa");

            migrationBuilder.AddForeignKey(
                name: "FK_Cidade",
                schema: "dbo",
                table: "Pessoa",
                column: "Id_Cidade",
                principalSchema: "dbo",
                principalTable: "Cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidade",
                schema: "dbo",
                table: "Pessoa");

            migrationBuilder.AddForeignKey(
                name: "FK_Cidade",
                schema: "dbo",
                table: "Pessoa",
                column: "Id_Cidade",
                principalSchema: "dbo",
                principalTable: "Cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

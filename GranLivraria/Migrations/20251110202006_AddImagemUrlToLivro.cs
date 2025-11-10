using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GranLivraria.Migrations
{
    /// <inheritdoc />
    public partial class AddImagemUrlToLivro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Livros",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(60)",
                oldMaxLength: 60)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<uint>(
                name: "Estoque",
                table: "Livros",
                type: "int unsigned",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ImagemUrl",
                table: "Livros",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemUrl",
                table: "Livros");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Livros",
                type: "varchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Estoque",
                table: "Livros",
                type: "int",
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "int unsigned");
        }
    }
}

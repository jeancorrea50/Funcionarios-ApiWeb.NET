using Microsoft.EntityFrameworkCore.Migrations;

namespace Funcionario_ApiWeb.NET.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    IdFuncionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CPF = table.Column<string>(type: "char(14)", nullable: false),
                    Telefone = table.Column<string>(type: "char(14)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.IdFuncionario);
                });

            migrationBuilder.InsertData(
                table: "Funcionario",
                columns: new[] { "IdFuncionario", "CPF", "Cargo", "Email", "Idade", "NomeCompleto", "Salario", "Telefone" },
                values: new object[] { 1, "063.485.221-32", "Analista de Logistisca JR", "ronaldopeira658@gmail.com", 24, "Ronaldo Pereira Cruz", 3100.00m, "(65)98132-4241" });

            migrationBuilder.InsertData(
                table: "Funcionario",
                columns: new[] { "IdFuncionario", "CPF", "Cargo", "Email", "Idade", "NomeCompleto", "Salario", "Telefone" },
                values: new object[] { 2, "026.752.421-25", "Analista Financeiro Pleno ", "carollineSouza123@gmail.com", 26, "Carolline Hererro Souza", 4200.00m, "(65)98421-6532" });

            migrationBuilder.InsertData(
                table: "Funcionario",
                columns: new[] { "IdFuncionario", "CPF", "Cargo", "Email", "Idade", "NomeCompleto", "Salario", "Telefone" },
                values: new object[] { 3, "542.481.263-78", "Analista de RH Senior", "Leandrocardosom5874@gmail.com", 33, "Leandro Cardoso Monteiro", 5600.00m, "(65)98365-6421" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionario");
        }
    }
}

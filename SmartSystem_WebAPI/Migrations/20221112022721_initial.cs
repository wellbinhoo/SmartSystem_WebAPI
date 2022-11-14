using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSystem_WebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Sigla = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Foto = table.Column<string>(type: "TEXT", nullable: true),
                    RG = table.Column<int>(type: "INTEGER", nullable: false),
                    DepartamentoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "Id", "Nome", "Sigla" },
                values: new object[] { 1, "Escritorio", "Esc" });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "Id", "Nome", "Sigla" },
                values: new object[] { 2, "Cozinha", "COZ" });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "Id", "Nome", "Sigla" },
                values: new object[] { 3, "Oficina", "OFC" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "DepartamentoId", "Foto", "Nome", "RG" },
                values: new object[] { 1, 1, "Foto", "Naruto", 102030 });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "DepartamentoId", "Foto", "Nome", "RG" },
                values: new object[] { 2, 2, "Foto", "Goku", 301020 });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "DepartamentoId", "Foto", "Nome", "RG" },
                values: new object[] { 3, 3, "Foto", "Yoga", 203010 });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_DepartamentoId",
                table: "Funcionarios",
                column: "DepartamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Departamentos");
        }
    }
}

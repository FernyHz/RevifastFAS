using Microsoft.EntityFrameworkCore.Migrations;

namespace Revifast.Migrations.DbRevifast
{
    public partial class AgregarEmpresas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Empresa (Nombre, RUC, Direccion) VALUES ('Farenet', 20107899124, 'Av. Manuel Olguín 2322')");
            migrationBuilder.Sql("INSERT INTO Empresa (Nombre, RUC, Direccion) VALUES ('ReviSeguros', 20339010664, 'Av. Separadora Industrial 2631')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}

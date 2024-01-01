using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hastane_Proje.Migrations
{
    /// <inheritdoc />
    public partial class güncelle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Kullanıcılar",
                newName: "Rol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rol",
                table: "Kullanıcılar",
                newName: "Role");
        }
    }
}

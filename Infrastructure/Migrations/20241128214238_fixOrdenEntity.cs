using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixOrdenEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenesInversion_TiposActivo_TipoActivoId",
                table: "OrdenesInversion");

            migrationBuilder.DropIndex(
                name: "IX_OrdenesInversion_TipoActivoId",
                table: "OrdenesInversion");

            migrationBuilder.DropColumn(
                name: "TipoActivoId",
                table: "OrdenesInversion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoActivoId",
                table: "OrdenesInversion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesInversion_TipoActivoId",
                table: "OrdenesInversion",
                column: "TipoActivoId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenesInversion_TiposActivo_TipoActivoId",
                table: "OrdenesInversion",
                column: "TipoActivoId",
                principalTable: "TiposActivo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

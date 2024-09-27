using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StokTakipSistemi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Musterilertablosuduzeltildi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Siparisler_Musterisler_MusteriId",
                table: "Siparisler");

            migrationBuilder.DropForeignKey(
                name: "FK_StokHareket_Siparisler_SiparisId",
                table: "StokHareket");

            migrationBuilder.DropForeignKey(
                name: "FK_StokHareket_Urunler_UrunId",
                table: "StokHareket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StokHareket",
                table: "StokHareket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Musterisler",
                table: "Musterisler");

            migrationBuilder.RenameTable(
                name: "StokHareket",
                newName: "StokHareketleri");

            migrationBuilder.RenameTable(
                name: "Musterisler",
                newName: "Musteriler");

            migrationBuilder.RenameIndex(
                name: "IX_StokHareket_UrunId",
                table: "StokHareketleri",
                newName: "IX_StokHareketleri_UrunId");

            migrationBuilder.RenameIndex(
                name: "IX_StokHareket_SiparisId",
                table: "StokHareketleri",
                newName: "IX_StokHareketleri_SiparisId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StokHareketleri",
                table: "StokHareketleri",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Musteriler",
                table: "Musteriler",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Siparisler_Musteriler_MusteriId",
                table: "Siparisler",
                column: "MusteriId",
                principalTable: "Musteriler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StokHareketleri_Siparisler_SiparisId",
                table: "StokHareketleri",
                column: "SiparisId",
                principalTable: "Siparisler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StokHareketleri_Urunler_UrunId",
                table: "StokHareketleri",
                column: "UrunId",
                principalTable: "Urunler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Siparisler_Musteriler_MusteriId",
                table: "Siparisler");

            migrationBuilder.DropForeignKey(
                name: "FK_StokHareketleri_Siparisler_SiparisId",
                table: "StokHareketleri");

            migrationBuilder.DropForeignKey(
                name: "FK_StokHareketleri_Urunler_UrunId",
                table: "StokHareketleri");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StokHareketleri",
                table: "StokHareketleri");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Musteriler",
                table: "Musteriler");

            migrationBuilder.RenameTable(
                name: "StokHareketleri",
                newName: "StokHareket");

            migrationBuilder.RenameTable(
                name: "Musteriler",
                newName: "Musterisler");

            migrationBuilder.RenameIndex(
                name: "IX_StokHareketleri_UrunId",
                table: "StokHareket",
                newName: "IX_StokHareket_UrunId");

            migrationBuilder.RenameIndex(
                name: "IX_StokHareketleri_SiparisId",
                table: "StokHareket",
                newName: "IX_StokHareket_SiparisId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StokHareket",
                table: "StokHareket",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Musterisler",
                table: "Musterisler",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Siparisler_Musterisler_MusteriId",
                table: "Siparisler",
                column: "MusteriId",
                principalTable: "Musterisler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StokHareket_Siparisler_SiparisId",
                table: "StokHareket",
                column: "SiparisId",
                principalTable: "Siparisler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StokHareket_Urunler_UrunId",
                table: "StokHareket",
                column: "UrunId",
                principalTable: "Urunler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

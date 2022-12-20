using Microsoft.EntityFrameworkCore.Migrations;

namespace AHY.AdvertisementApp.DataAccess.Migrations
{
    public partial class Add_AppRole_Seed_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "Definition" },
                values: new object[] { 1, "Member" });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "Definition" },
                values: new object[] { 2, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

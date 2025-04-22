using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogNest.Migrations
{
    public partial class AddRoleDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "49a84e40-a92a-4a20-93ff-a364331275be", "548e1c8a-c454-4269-a0e7-c592130d22c6", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6d3ee673-4837-412c-8dcf-b530ede65f49", "a03a4d78-07fd-4fdd-8bbd-a24dfadd9159", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "83b644f6-4c22-4be1-949c-3f92ecd63724", "dc821609-4fdb-4ecf-83ba-bb83c0cff020", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49a84e40-a92a-4a20-93ff-a364331275be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d3ee673-4837-412c-8dcf-b530ede65f49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83b644f6-4c22-4be1-949c-3f92ecd63724");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankingControlPanel.Infrastructure.Persistence.Sql.Migrations
{
    /// <inheritdoc />
    public partial class seedUsersAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("a27e3cb5-f9a2-4a8b-98dc-24cc06eee17f"), "Admin", "Admin" },
                    { new Guid("e7ad4c06-839d-4fd5-a43c-92319c9a6012"), "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "RoleId", "UserName" },
                values: new object[,]
                {
                    { new Guid("c405080e-2da2-4cd9-9da4-b1c2a699b297"), "user@test.com", "User", "User", "$2b$12$uUGDkynQvsESZf4pG1zPE..CWexqYEE1tOUM2MTS4Rr2XLA6UC./u", new Guid("e7ad4c06-839d-4fd5-a43c-92319c9a6012"), "user" },
                    { new Guid("e7265a53-8e29-4d0d-b6b5-8d2834519cff"), "admin@test.com", "Admin", "Admin", "$2b$12$ARv87t3BF1.UzLXXG7fAouuGahAluykDmSChkm5RYejuKQmWSC3sK", new Guid("a27e3cb5-f9a2-4a8b-98dc-24cc06eee17f"), "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c405080e-2da2-4cd9-9da4-b1c2a699b297"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e7265a53-8e29-4d0d-b6b5-8d2834519cff"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a27e3cb5-f9a2-4a8b-98dc-24cc06eee17f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e7ad4c06-839d-4fd5-a43c-92319c9a6012"));
        }
    }
}
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkCoreEncryptColumnExample.Migrations
{
    /// <inheritdoc />
    public partial class addedencryptionconfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Id",
                schema: "encryptexample",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                schema: "encryptexample",
                table: "Users",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "gen_random_uuid()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                schema: "encryptexample",
                table: "Users",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "EncryptionConfigurations",
                schema: "encryptexample",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    EncryptedPassword = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    IsReset = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncryptionConfigurations", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EncryptionConfigurations",
                schema: "encryptexample");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                schema: "encryptexample",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                schema: "encryptexample",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Id",
                schema: "encryptexample",
                table: "Users",
                column: "ID");
        }
    }
}

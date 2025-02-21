using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASbackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    fullname = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    cpf = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    age = table.Column<int>(type: "integer", nullable: false),
                    numberphone = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    adress = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    duedate = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    injuryhistory = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    numberemergency = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

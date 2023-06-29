using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace dotnet.Migrations
{
    /// <inheritdoc />
    public partial class CreatedUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DATA_NASC",
                table: "tb_users",
                newName: "DataNascimento");

            migrationBuilder.AddColumn<string>(
                name: "PASSWORD",
                table: "tb_users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ROLE",
                table: "tb_users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "tb_usuarios",
                columns: table => new
                {
                    USER_ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NOME = table.Column<string>(type: "text", nullable: false),
                    DATA_NASC = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuarios", x => x.USER_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_usuarios");

            migrationBuilder.DropColumn(
                name: "PASSWORD",
                table: "tb_users");

            migrationBuilder.DropColumn(
                name: "ROLE",
                table: "tb_users");

            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "tb_users",
                newName: "DATA_NASC");
        }
    }
}

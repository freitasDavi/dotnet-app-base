using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace dotnet.Migrations
{
    /// <inheritdoc />
    public partial class CreatedCourseAndRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_usuario",
                table: "usuario");

            migrationBuilder.RenameTable(
                name: "usuario",
                newName: "tb_users");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "tb_users",
                newName: "NOME");

            migrationBuilder.RenameColumn(
                name: "data_nascimento",
                table: "tb_users",
                newName: "DATA_NASC");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tb_users",
                newName: "USER_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_users",
                table: "tb_users",
                column: "USER_ID");

            migrationBuilder.CreateTable(
                name: "tb_courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NOME = table.Column<string>(type: "text", nullable: false),
                    CATEGORIA = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_courses", x => x.CourseId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_users",
                table: "tb_users");

            migrationBuilder.RenameTable(
                name: "tb_users",
                newName: "usuario");

            migrationBuilder.RenameColumn(
                name: "NOME",
                table: "usuario",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "DATA_NASC",
                table: "usuario",
                newName: "data_nascimento");

            migrationBuilder.RenameColumn(
                name: "USER_ID",
                table: "usuario",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuario",
                table: "usuario",
                column: "id");
        }
    }
}

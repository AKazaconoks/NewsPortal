using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForTEsts.Data.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "nofile.png");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "delfi");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

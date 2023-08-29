using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project2.Migrations
{
    /// <inheritdoc />
    public partial class remove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostModelId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PostModelId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PostModelId",
                table: "Comments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostModelId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostModelId",
                table: "Comments",
                column: "PostModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostModelId",
                table: "Comments",
                column: "PostModelId",
                principalTable: "Posts",
                principalColumn: "Id");
        }
    }
}

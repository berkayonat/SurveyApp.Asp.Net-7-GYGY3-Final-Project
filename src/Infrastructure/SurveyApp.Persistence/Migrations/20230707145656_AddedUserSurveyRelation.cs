using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserSurveyRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Surveys",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_AppUserId",
                table: "Surveys",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_AspNetUsers_AppUserId",
                table: "Surveys",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_AspNetUsers_AppUserId",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_AppUserId",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Surveys");
        }
    }
}

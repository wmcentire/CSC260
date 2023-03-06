using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAM_SocialMediaSite_02.Data.Migrations
{
    public partial class updateprimarykeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userId",
                table: "users",
                newName: "profileID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "profileID",
                table: "users",
                newName: "userId");
        }
    }
}

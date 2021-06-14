using Microsoft.EntityFrameworkCore.Migrations;

namespace Authenticator.Data.Migrations
{
    public partial class _00001_AlterASPNetUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FName", 
                table: "AspNetUsers", 
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true
                );
            migrationBuilder.AddColumn<string>(
               name: "LName",
               table: "AspNetUsers",
               type: "nvarchar(100)",
               maxLength: 100,
               nullable: true
               );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

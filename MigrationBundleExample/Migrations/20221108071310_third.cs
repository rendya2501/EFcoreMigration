using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationBundleExample.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VUEW [dbo].[MyView]
                AS
                SELECT ID,Name FROM dbo.People
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW MyView");
        }
    }
}

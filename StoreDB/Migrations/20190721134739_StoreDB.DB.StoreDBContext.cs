using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreDB.Migrations
{
    public partial class StoreDBDBStoreDBContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { "1", "kennyrg@gmail.com", "Kenny", "Rogers" },
                    { "2", "barryr@gmail.com", "Barry", "White" },
                    { "3", "janefonda@gmail.com", "Jane", "Fonda" },
                    { "4", "sametto@gmail.com", "Sam", "Etto" },
                    { "5", "adamsandler@gmail.com", "Adam", "Sandler" },
                    { "6", "oliviastone@gmail.com", "Olivia", "stone" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreDB.Migrations
{
    public partial class primaryKeyAuto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Users",
               columns: table => new
               {
                   UserId = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { "kennyrg@gmail.com", "Kenny", "Rogers" },
                    { "barryr@gmail.com", "Barry", "White" },
                    { "janefonda@gmail.com", "Jane", "Fonda" },
                    { "sametto@gmail.com", "Sam", "Etto" },
                    { "adamsandler@gmail.com", "Adam", "Sandler" },
                    { "oliviastone@gmail.com", "Olivia", "stone" }
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

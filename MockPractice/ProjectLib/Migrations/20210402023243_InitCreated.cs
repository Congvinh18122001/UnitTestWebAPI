using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectLib.Migrations
{
    public partial class InitCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "ID", "BirthPlace", "Birthday", "Email", "Gender", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Hai Phong", "18/12/2001", "asd12@gmail.com", "Male", "Truong Cong Vinh", "0123654789" },
                    { 2, "Ha Noi", "18/12/2000", "asd2@gmail.com", "Male", "Truong Cong Minh", "0123654789" },
                    { 3, "Hai Phong", "18/12/1999", "asd3@gmail.com", "Male", "Truong Cong Tuan", "0123654789" },
                    { 4, "Ha Noi", "18/12/1998", "asd4@gmail.com", "Male", "Truong Cong Tu", "0123654789" },
                    { 5, "Ha Nam", "18/12/2000", "asd5@gmail.com", "Male", "Truong Cong Duc", "0123654789" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Password", "RoleID", "Username" },
                values: new object[] { 1, "123", 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Password", "RoleID", "Username" },
                values: new object[] { 2, "123", 2, "User" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}

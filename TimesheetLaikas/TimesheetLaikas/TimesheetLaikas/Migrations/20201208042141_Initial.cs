using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimesheetLaikas.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "College");

            migrationBuilder.EnsureSchema(
                name: "Pay");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    EMP_FNAME = table.Column<string>(type: "TEXT", nullable: true),
                    EMP_LNAME = table.Column<string>(type: "TEXT", nullable: true),
                    ADDRESS = table.Column<string>(type: "TEXT", nullable: true),
                    CITY = table.Column<string>(type: "TEXT", nullable: true),
                    ZIPCODE = table.Column<string>(type: "TEXT", nullable: true),
                    Payrate = table.Column<decimal>(type: "Money", nullable: false),
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Employee_UserId",
                        column: x => x.UserId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Employee_UserId",
                        column: x => x.UserId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Employee_UserId",
                        column: x => x.UserId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Employee_UserId",
                        column: x => x.UserId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Division",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DivisionName = table.Column<string>(type: "TEXT", nullable: false),
                    DivsionChairId = table.Column<string>(type: "TEXT", nullable: true),
                    TimeStamp = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Division_Employee_DivsionChairId",
                        column: x => x.DivsionChairId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payperiods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TotalHoursWorked = table.Column<double>(type: "REAL", nullable: false),
                    OverTimeWorked = table.Column<double>(type: "REAL", nullable: true),
                    EmpID = table.Column<string>(type: "TEXT", nullable: true),
                    TimeStamp = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payperiods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payperiods_Employee_EmpID",
                        column: x => x.EmpID,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "College",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DeptName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DivisionId = table.Column<int>(type: "INTEGER", nullable: false),
                    TimeStamp = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Division",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Timesheet",
                schema: "Pay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PunchIn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PunchOut = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EmpID = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    TotalWorkTime = table.Column<string>(type: "TEXT", nullable: true),
                    TotalPay = table.Column<decimal>(type: "Money", nullable: true),
                    PayperiodId = table.Column<int>(type: "INTEGER", nullable: true),
                    TimeStamp = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timesheet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Timesheet_Employee_EmpID",
                        column: x => x.EmpID,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Timesheet_Payperiods_PayperiodId",
                        column: x => x.PayperiodId,
                        principalTable: "Payperiods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Division",
                columns: new[] { "Id", "DivisionName", "DivsionChairId" },
                values: new object[] { 1, "Admin", null });

            migrationBuilder.InsertData(
                table: "Division",
                columns: new[] { "Id", "DivisionName", "DivsionChairId" },
                values: new object[] { 2, "STEM", null });

            migrationBuilder.InsertData(
                table: "Division",
                columns: new[] { "Id", "DivisionName", "DivsionChairId" },
                values: new object[] { 3, "Art Department", null });

            migrationBuilder.InsertData(
                table: "Division",
                columns: new[] { "Id", "DivisionName", "DivsionChairId" },
                values: new object[] { 4, "Business, Account, and Public Service", null });

            migrationBuilder.InsertData(
                table: "Division",
                columns: new[] { "Id", "DivisionName", "DivsionChairId" },
                values: new object[] { 5, "Education", null });

            migrationBuilder.InsertData(
                table: "Division",
                columns: new[] { "Id", "DivisionName", "DivsionChairId" },
                values: new object[] { 6, "Health Sciences Division", null });

            migrationBuilder.InsertData(
                table: "Division",
                columns: new[] { "Id", "DivisionName", "DivsionChairId" },
                values: new object[] { 7, "Humanities, Fine Arts, and Social Services", null });

            migrationBuilder.InsertData(
                table: "Division",
                columns: new[] { "Id", "DivisionName", "DivsionChairId" },
                values: new object[] { 8, "Campus Security", null });

            migrationBuilder.InsertData(
                table: "Division",
                columns: new[] { "Id", "DivisionName", "DivsionChairId" },
                values: new object[] { 9, "Human Resources", null });

            migrationBuilder.InsertData(
                table: "Division",
                columns: new[] { "Id", "DivisionName", "DivsionChairId" },
                values: new object[] { 10, "General Staff", null });

            migrationBuilder.InsertData(
                schema: "College",
                table: "Department",
                columns: new[] { "Id", "DeptName", "DivisionId" },
                values: new object[] { 1, "Admin", 1 });

            migrationBuilder.InsertData(
                schema: "College",
                table: "Department",
                columns: new[] { "Id", "DeptName", "DivisionId" },
                values: new object[] { 2, "Computer Science", 2 });

            migrationBuilder.InsertData(
                schema: "College",
                table: "Department",
                columns: new[] { "Id", "DeptName", "DivisionId" },
                values: new object[] { 3, "Computer Information Technology", 2 });

            migrationBuilder.InsertData(
                schema: "College",
                table: "Department",
                columns: new[] { "Id", "DeptName", "DivisionId" },
                values: new object[] { 4, "Mathematics", 2 });

            migrationBuilder.InsertData(
                schema: "College",
                table: "Department",
                columns: new[] { "Id", "DeptName", "DivisionId" },
                values: new object[] { 7, "Welding", 2 });

            migrationBuilder.InsertData(
                schema: "College",
                table: "Department",
                columns: new[] { "Id", "DeptName", "DivisionId" },
                values: new object[] { 6, "Nursing", 6 });

            migrationBuilder.InsertData(
                schema: "College",
                table: "Department",
                columns: new[] { "Id", "DeptName", "DivisionId" },
                values: new object[] { 5, "Communication Studies", 7 });

            migrationBuilder.InsertData(
                schema: "College",
                table: "Department",
                columns: new[] { "Id", "DeptName", "DivisionId" },
                values: new object[] { 8, "Human Resources", 9 });

            migrationBuilder.InsertData(
                schema: "College",
                table: "Department",
                columns: new[] { "Id", "DeptName", "DivisionId" },
                values: new object[] { 9, "Janitorial", 10 });

            migrationBuilder.InsertData(
                schema: "College",
                table: "Department",
                columns: new[] { "Id", "DeptName", "DivisionId" },
                values: new object[] { 10, "Faculty", 10 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_DivisionId",
                schema: "College",
                table: "Department",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Division_DivsionChairId",
                table: "Division",
                column: "DivsionChairId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Employee",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Employee",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payperiods_EmpID",
                table: "Payperiods",
                column: "EmpID");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Timesheet_EmpID",
                schema: "Pay",
                table: "Timesheet",
                column: "EmpID");

            migrationBuilder.CreateIndex(
                name: "IX_Timesheet_PayperiodId",
                schema: "Pay",
                table: "Timesheet",
                column: "PayperiodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department_DepartmentId",
                table: "Employee",
                column: "DepartmentId",
                principalSchema: "College",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Division_Employee_DivsionChairId",
                table: "Division");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Timesheet",
                schema: "Pay");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Payperiods");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "College");

            migrationBuilder.DropTable(
                name: "Division");
        }
    }
}

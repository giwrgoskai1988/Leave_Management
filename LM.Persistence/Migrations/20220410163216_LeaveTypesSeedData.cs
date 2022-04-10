using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LM.Persistence.Migrations
{
    public partial class LeaveTypesSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DefaultDays", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { 1, "SYSTEM", new DateTime(2022, 4, 10, 19, 32, 16, 13, DateTimeKind.Local).AddTicks(7580), 10, null, null, "Vacation" });

            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DefaultDays", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { 2, "SYSTEM", new DateTime(2022, 4, 10, 19, 32, 16, 13, DateTimeKind.Local).AddTicks(7616), 12, null, null, "Sick" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

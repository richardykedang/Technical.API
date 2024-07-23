using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Technical.API.Migrations
{
    public partial class AddingIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "28ba3f2b-937c-4628-9abd-5693c531137b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "289f9002-371c-418c-9b0e-cb19e5799721");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73c47806-542d-4a84-9368-31b6de834236", true, "AQAAAAEAACcQAAAAEM/fAHLLCVZ81QHTkxYouH5llRdVT7w2MfegzmS5j9iQ6s1mRsud5tJtp5Q/8OIUgQ==", "e338488c-9f76-4bf7-91a6-fd3f6a95d0dc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "425fee2e-88fd-4967-928c-43c0da71f7d8", true, "AQAAAAEAACcQAAAAEKKZoNsTuSqFjH8hRhwFWcKwMWat2n8ryJL56QNUm9Qtmw/XzYU+RHU/G4tygJkA5g==", "4ec39002-0c4c-4d56-b343-dc20f82aa8bb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "ea58b272-6fa2-4c3e-8eec-c5fc17ba34a0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "9979d578-5fea-4dcb-9459-bf9a47e4ae8e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57beaac4-a38d-4989-8d49-8762ea7a34bb", false, "AQAAAAEAACcQAAAAEKnPkvTZL/arsRWASsjLDpwNENm7oXZTvg6FMCUolXTJb0K/4gUrerIgFVQq6Wzs5Q==", "d17571d6-8922-4ab2-8230-0ac432d4fcfb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9bad527-bdcd-4bfe-ac95-272397980446", false, "AQAAAAEAACcQAAAAEIqSyK16oWYUHcW/AK8Goe6mjrbTQJFvfLbFjpqaOZUu7XyISscNNaL87WajxrMqoA==", "d8217204-ae31-41fb-b75b-1d427522e4b1" });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerCreds",
                columns: table => new
                {
                    customer_cred_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    customer_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    password = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCreds", x => x.customer_cred_ID);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    movie_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    title = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    genre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    release_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    synopsis = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    director = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    rating = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    age_rating = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    timestamp = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.movie_ID);
                });

            migrationBuilder.CreateTable(
                name: "MyCustomers",
                columns: table => new
                {
                    customer_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    phone = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyCustomers", x => x.customer_ID);
                });

            migrationBuilder.CreateTable(
                name: "Screens",
                columns: table => new
                {
                    screen_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    capacity = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    sc_tier_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screens", x => x.screen_ID);
                });

            migrationBuilder.CreateTable(
                name: "ScreenTiers",
                columns: table => new
                {
                    tier_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    price = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreenTiers", x => x.tier_ID);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    seat_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    screen_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    seat_type = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.seat_ID);
                });

            migrationBuilder.CreateTable(
                name: "SeatTypes",
                columns: table => new
                {
                    type_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    price = table.Column<double>(type: "BINARY_DOUBLE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatTypes", x => x.type_ID);
                });

            migrationBuilder.CreateTable(
                name: "Showings",
                columns: table => new
                {
                    showing_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    movie_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    screen_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    start_time = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    scheduler_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Showings", x => x.showing_ID);
                });

            migrationBuilder.CreateTable(
                name: "StaffCredentials",
                columns: table => new
                {
                    staffcred_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    username = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    staff_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    password = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffCredentials", x => x.staffcred_ID);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    staff_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    username = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.staff_ID);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    ticket_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    customer_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    showing_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    seat_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    price = table.Column<double>(type: "BINARY_DOUBLE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.ticket_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerCreds");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "MyCustomers");

            migrationBuilder.DropTable(
                name: "Screens");

            migrationBuilder.DropTable(
                name: "ScreenTiers");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "SeatTypes");

            migrationBuilder.DropTable(
                name: "Showings");

            migrationBuilder.DropTable(
                name: "StaffCredentials");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}

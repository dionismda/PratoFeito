using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customer.Insfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "consumer_event_log",
                columns: table => new
                {
                    consumereventlogid = table.Column<Guid>(name: "consumer_event_log_id", type: "uuid", nullable: false),
                    eventid = table.Column<Guid>(name: "event_id", type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    dateconsumed = table.Column<DateTime>(name: "date_consumed", type: "timestamp with time zone", nullable: false),
                    tenantid = table.Column<Guid>(name: "tenant_id", type: "uuid", nullable: false),
                    createddate = table.Column<DateTime>(name: "created_date", type: "timestamp with time zone", nullable: false),
                    updateddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_consumer_event_log", x => x.consumereventlogid);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    customerid = table.Column<Guid>(name: "customer_id", type: "uuid", nullable: false),
                    firstname = table.Column<string>(name: "first_name", type: "character varying(120)", maxLength: 120, nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "character varying(120)", maxLength: 120, nullable: false),
                    amount = table.Column<decimal>(type: "numeric(10,4)", precision: 10, scale: 4, nullable: false),
                    tenantid = table.Column<Guid>(name: "tenant_id", type: "uuid", nullable: false),
                    createddate = table.Column<DateTime>(name: "created_date", type: "timestamp with time zone", nullable: false),
                    updateddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customer", x => x.customerid);
                });

            migrationBuilder.CreateTable(
                name: "integration_event_log",
                columns: table => new
                {
                    integrationeventlogid = table.Column<Guid>(name: "integration_event_log_id", type: "uuid", nullable: false),
                    eventid = table.Column<Guid>(name: "event_id", type: "uuid", nullable: false),
                    eventtypename = table.Column<string>(name: "event_type_name", type: "text", nullable: false),
                    state = table.Column<int>(type: "integer", nullable: false),
                    timessent = table.Column<int>(name: "times_sent", type: "integer", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    transactionid = table.Column<string>(name: "transaction_id", type: "text", nullable: false),
                    header = table.Column<string>(type: "text", nullable: false),
                    tenantid = table.Column<Guid>(name: "tenant_id", type: "uuid", nullable: false),
                    createddate = table.Column<DateTime>(name: "created_date", type: "timestamp with time zone", nullable: false),
                    updateddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_integration_event_log", x => x.integrationeventlogid);
                });

            migrationBuilder.CreateTable(
                name: "customer_order",
                columns: table => new
                {
                    customerorderid = table.Column<Guid>(name: "customer_order_id", type: "uuid", nullable: false),
                    customerid = table.Column<Guid>(name: "customer_id", type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(10,4)", precision: 10, scale: 4, nullable: false),
                    orderstate = table.Column<int>(name: "order_state", type: "integer", nullable: false),
                    tenantid = table.Column<Guid>(name: "tenant_id", type: "uuid", nullable: false),
                    createddate = table.Column<DateTime>(name: "created_date", type: "timestamp with time zone", nullable: false),
                    updateddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customer_order", x => x.customerorderid);
                    table.ForeignKey(
                        name: "fk_customer_order_customer_customer_id",
                        column: x => x.customerid,
                        principalTable: "customer",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_customer_order_customer_id",
                table: "customer_order",
                column: "customer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "consumer_event_log");

            migrationBuilder.DropTable(
                name: "customer_order");

            migrationBuilder.DropTable(
                name: "integration_event_log");

            migrationBuilder.DropTable(
                name: "customer");
        }
    }
}

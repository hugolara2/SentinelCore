using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SentinelCore.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "telemetry");

            migrationBuilder.CreateTable(
                name: "agent_identity",
                schema: "telemetry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SecretKey = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    LastSeen = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agent_identity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "system_metrics",
                schema: "telemetry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AgentId = table.Column<Guid>(type: "uuid", nullable: false),
                    HostName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    OperatingSystem = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CpuUsage = table.Column<double>(type: "double precision", nullable: false),
                    MemoryUsage = table.Column<double>(type: "double precision", nullable: false),
                    Timestamp = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_system_metrics", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_agent_identity_LastSeen",
                schema: "telemetry",
                table: "agent_identity",
                column: "LastSeen");

            migrationBuilder.CreateIndex(
                name: "IX_system_metrics_AgentId_Timestamp",
                schema: "telemetry",
                table: "system_metrics",
                columns: new[] { "AgentId", "Timestamp" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "agent_identity",
                schema: "telemetry");

            migrationBuilder.DropTable(
                name: "system_metrics",
                schema: "telemetry");
        }
    }
}

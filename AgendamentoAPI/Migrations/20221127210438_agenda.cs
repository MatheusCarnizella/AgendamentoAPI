using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendamentoAPI.Migrations
{
    public partial class agenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "confirmarAgendamentos",
                columns: table => new
                {
                    confirmarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    confirmarAgendamento = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_confirmarAgendamentos", x => x.confirmarId);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    pacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pacienteNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pacienteCPF = table.Column<int>(type: "int", fixedLength: true, maxLength: 11, nullable: false),
                    pacienteNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    agendamentoId = table.Column<int>(type: "int", nullable: false),
                    agendamentoNome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.pacienteId);
                });

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    agendamentoId = table.Column<int>(type: "int", nullable: false),
                    agendamentoMedico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    agendamentoDia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pacienteId = table.Column<int>(type: "int", nullable: false),
                    confirmarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.agendamentoId);
                    table.ForeignKey(
                        name: "FK_Agendamentos_confirmarAgendamentos_confirmarId",
                        column: x => x.confirmarId,
                        principalTable: "confirmarAgendamentos",
                        principalColumn: "confirmarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Pacientes_agendamentoId",
                        column: x => x.agendamentoId,
                        principalTable: "Pacientes",
                        principalColumn: "pacienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_confirmarId",
                table: "Agendamentos",
                column: "confirmarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "confirmarAgendamentos");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}

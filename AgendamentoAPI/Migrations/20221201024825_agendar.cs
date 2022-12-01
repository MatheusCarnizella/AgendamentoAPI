using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendamentoAPI.Migrations
{
    public partial class agendar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    pacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pacienteNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pacienteCPF = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    pacienteNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    agendamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.pacienteId);
                });

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    agendamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    agendamentoMedico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    agendamentoEscialidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    agendamentoDia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.agendamentoId);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Pacientes_pacienteId",
                        column: x => x.pacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "pacienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "confirmarAgendamentos",
                columns: table => new
                {
                    confirmarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    confirmarAgendamento = table.Column<bool>(type: "bit", nullable: false),
                    agendamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_confirmarAgendamentos", x => x.confirmarId);
                    table.ForeignKey(
                        name: "FK_confirmarAgendamentos_Agendamentos_agendamentoId",
                        column: x => x.agendamentoId,
                        principalTable: "Agendamentos",
                        principalColumn: "agendamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_pacienteId",
                table: "Agendamentos",
                column: "pacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_confirmarAgendamentos_agendamentoId",
                table: "confirmarAgendamentos",
                column: "agendamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "confirmarAgendamentos");

            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CondoNexus.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CONDOMINIOS",
                columns: table => new
                {
                    CND_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CND_NOME = table.Column<string>(type: "varchar(100)", nullable: false),
                    CND_CNPJ = table.Column<string>(type: "varchar(14)", nullable: false),
                    CND_NUMERO_UNIDADES = table.Column<int>(type: "int", nullable: false),
                    CND_NUMERO_BLOCOS = table.Column<int>(type: "int", nullable: false),
                    CND_NUMERO_ANDARES = table.Column<int>(type: "int", nullable: false),
                    CND_DATA_FUNDACAO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CND_ID", x => x.CND_ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_ENDERECOS",
                columns: table => new
                {
                    END_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CND_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    END_LOGRADOURO = table.Column<string>(type: "varchar(200)", nullable: false),
                    END_NUMERO = table.Column<string>(type: "varchar(10)", nullable: false),
                    END_COMPLEMENTO = table.Column<string>(type: "varchar(100)", nullable: false),
                    END_CEP = table.Column<string>(type: "varchar(8)", nullable: false),
                    END_BAIRRO = table.Column<string>(type: "varchar(100)", nullable: false),
                    END_CIDADE = table.Column<string>(type: "varchar(100)", nullable: false),
                    END_ESTADO = table.Column<string>(type: "varchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_END_ID", x => x.END_ID);
                    table.ForeignKey(
                        name: "FK_ENDERECOS_CONDOMINIOS",
                        column: x => x.CND_ID,
                        principalTable: "TB_CONDOMINIOS",
                        principalColumn: "CND_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_UNIDADES",
                columns: table => new
                {
                    UND_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UND_NUMERO = table.Column<string>(type: "varchar(10)", nullable: false),
                    UND_ANDAR = table.Column<int>(type: "int", nullable: false),
                    UND_BLOCO = table.Column<string>(type: "varchar(10)", nullable: false),
                    UND_STATUS_RESIDENCIAL = table.Column<int>(type: "int", nullable: false),
                    CND_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UND_ID", x => x.UND_ID);
                    table.ForeignKey(
                        name: "FK_UNIDADES_CONDOMINIOS",
                        column: x => x.CND_ID,
                        principalTable: "TB_CONDOMINIOS",
                        principalColumn: "CND_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_MORADORES",
                columns: table => new
                {
                    MRD_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MRD_NOME = table.Column<string>(type: "varchar(100)", nullable: false),
                    MRD_CPF = table.Column<string>(type: "varchar(11)", nullable: false),
                    MRD_TELEFONE = table.Column<string>(type: "varchar(20)", nullable: false),
                    MRD_EMAIL = table.Column<string>(type: "varchar(100)", nullable: false),
                    MRD_DATA_NASCIMENTO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MRD_FOTO = table.Column<string>(type: "varchar(255)", nullable: false),
                    UND_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MRD_ID", x => x.MRD_ID);
                    table.ForeignKey(
                        name: "FK_MORADORES_UNIDADES",
                        column: x => x.UND_ID,
                        principalTable: "TB_UNIDADES",
                        principalColumn: "UND_ID");
                });

            migrationBuilder.CreateTable(
                name: "TB_VEICULOS",
                columns: table => new
                {
                    VCL_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VCL_PLACA = table.Column<string>(type: "varchar(7)", nullable: false),
                    VCL_MARCA = table.Column<string>(type: "varchar(100)", nullable: false),
                    VCL_MODELO = table.Column<string>(type: "varchar(100)", nullable: false),
                    VCL_COR = table.Column<string>(type: "varchar(50)", nullable: false),
                    VCL_ANO = table.Column<int>(type: "int", nullable: false),
                    UND_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VCL_ID", x => x.VCL_ID);
                    table.ForeignKey(
                        name: "FK_Veiculo_Unidade",
                        column: x => x.UND_ID,
                        principalTable: "TB_UNIDADES",
                        principalColumn: "UND_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ENDERECOS_CND_ID",
                table: "TB_ENDERECOS",
                column: "CND_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_MORADORES_UND_ID",
                table: "TB_MORADORES",
                column: "UND_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_UNIDADES_CND_ID",
                table: "TB_UNIDADES",
                column: "CND_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_VEICULOS_UND_ID",
                table: "TB_VEICULOS",
                column: "UND_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ENDERECOS");

            migrationBuilder.DropTable(
                name: "TB_MORADORES");

            migrationBuilder.DropTable(
                name: "TB_VEICULOS");

            migrationBuilder.DropTable(
                name: "TB_UNIDADES");

            migrationBuilder.DropTable(
                name: "TB_CONDOMINIOS");
        }
    }
}

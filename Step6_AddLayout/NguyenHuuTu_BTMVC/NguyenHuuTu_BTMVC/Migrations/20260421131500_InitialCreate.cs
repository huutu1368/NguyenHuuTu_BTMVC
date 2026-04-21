using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NguyenHuuTu_BTMVC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "giaoViens",
                columns: table => new
                {
                    GiaoVienId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenGV = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_giaoViens", x => x.GiaoVienId);
                });

            migrationBuilder.CreateTable(
                name: "khoaHocs",
                columns: table => new
                {
                    KhoaHocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenKH = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khoaHocs", x => x.KhoaHocId);
                });

            migrationBuilder.CreateTable(
                name: "sinhViens",
                columns: table => new
                {
                    SinhVienId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenSinhVien = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sinhViens", x => x.SinhVienId);
                });

            migrationBuilder.CreateTable(
                name: "lopHocPhans",
                columns: table => new
                {
                    LopHocPhanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenLop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaoVienId = table.Column<int>(type: "int", nullable: false),
                    KhoaHocId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lopHocPhans", x => x.LopHocPhanId);
                    table.ForeignKey(
                        name: "FK_lopHocPhans_giaoViens_GiaoVienId",
                        column: x => x.GiaoVienId,
                        principalTable: "giaoViens",
                        principalColumn: "GiaoVienId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lopHocPhans_khoaHocs_KhoaHocId",
                        column: x => x.KhoaHocId,
                        principalTable: "khoaHocs",
                        principalColumn: "KhoaHocId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dangKyLopHocs",
                columns: table => new
                {
                    DangKyLopHocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ngaydk = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SinhVienId = table.Column<int>(type: "int", nullable: false),
                    LopHocPhanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dangKyLopHocs", x => x.DangKyLopHocId);
                    table.ForeignKey(
                        name: "FK_dangKyLopHocs_lopHocPhans_LopHocPhanId",
                        column: x => x.LopHocPhanId,
                        principalTable: "lopHocPhans",
                        principalColumn: "LopHocPhanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dangKyLopHocs_sinhViens_SinhVienId",
                        column: x => x.SinhVienId,
                        principalTable: "sinhViens",
                        principalColumn: "SinhVienId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dangKyLopHocs_LopHocPhanId",
                table: "dangKyLopHocs",
                column: "LopHocPhanId");

            migrationBuilder.CreateIndex(
                name: "IX_dangKyLopHocs_SinhVienId",
                table: "dangKyLopHocs",
                column: "SinhVienId");

            migrationBuilder.CreateIndex(
                name: "IX_lopHocPhans_GiaoVienId",
                table: "lopHocPhans",
                column: "GiaoVienId");

            migrationBuilder.CreateIndex(
                name: "IX_lopHocPhans_KhoaHocId",
                table: "lopHocPhans",
                column: "KhoaHocId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dangKyLopHocs");

            migrationBuilder.DropTable(
                name: "lopHocPhans");

            migrationBuilder.DropTable(
                name: "sinhViens");

            migrationBuilder.DropTable(
                name: "giaoViens");

            migrationBuilder.DropTable(
                name: "khoaHocs");
        }
    }
}

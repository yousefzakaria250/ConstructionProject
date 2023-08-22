using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class deleteSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_homePages_AboutPage_aboutId",
                table: "homePages");

            migrationBuilder.DropForeignKey(
                name: "FK_homePages_counterUps_counterUpId",
                table: "homePages");

            migrationBuilder.DropForeignKey(
                name: "FK_homePages_ProjectPage_projectId",
                table: "homePages");

            migrationBuilder.DropForeignKey(
                name: "FK_homePages_ServicePage_servicesId",
                table: "homePages");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_AboutPage_AboutPageId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_sliders_homePages_HomePageId",
                table: "sliders");

            migrationBuilder.DropIndex(
                name: "IX_sliders_HomePageId",
                table: "sliders");

            migrationBuilder.DropIndex(
                name: "IX_homePages_aboutId",
                table: "homePages");

            migrationBuilder.DropIndex(
                name: "IX_homePages_counterUpId",
                table: "homePages");

            migrationBuilder.DropIndex(
                name: "IX_homePages_projectId",
                table: "homePages");

            migrationBuilder.DropIndex(
                name: "IX_homePages_servicesId",
                table: "homePages");

            migrationBuilder.DropColumn(
                name: "HomePageId",
                table: "sliders");

            migrationBuilder.DropColumn(
                name: "aboutId",
                table: "homePages");

            migrationBuilder.DropColumn(
                name: "counterUpId",
                table: "homePages");

            migrationBuilder.DropColumn(
                name: "projectId",
                table: "homePages");

            migrationBuilder.DropColumn(
                name: "servicesId",
                table: "homePages");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_AboutPage_AboutPageId",
                table: "Section",
                column: "AboutPageId",
                principalTable: "AboutPage",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Section_AboutPage_AboutPageId",
                table: "Section");

            migrationBuilder.AddColumn<int>(
                name: "HomePageId",
                table: "sliders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "aboutId",
                table: "homePages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "counterUpId",
                table: "homePages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "projectId",
                table: "homePages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "servicesId",
                table: "homePages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_sliders_HomePageId",
                table: "sliders",
                column: "HomePageId");

            migrationBuilder.CreateIndex(
                name: "IX_homePages_aboutId",
                table: "homePages",
                column: "aboutId");

            migrationBuilder.CreateIndex(
                name: "IX_homePages_counterUpId",
                table: "homePages",
                column: "counterUpId");

            migrationBuilder.CreateIndex(
                name: "IX_homePages_projectId",
                table: "homePages",
                column: "projectId");

            migrationBuilder.CreateIndex(
                name: "IX_homePages_servicesId",
                table: "homePages",
                column: "servicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_homePages_AboutPage_aboutId",
                table: "homePages",
                column: "aboutId",
                principalTable: "AboutPage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_homePages_counterUps_counterUpId",
                table: "homePages",
                column: "counterUpId",
                principalTable: "counterUps",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_homePages_ProjectPage_projectId",
                table: "homePages",
                column: "projectId",
                principalTable: "ProjectPage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_homePages_ServicePage_servicesId",
                table: "homePages",
                column: "servicesId",
                principalTable: "ServicePage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_AboutPage_AboutPageId",
                table: "Section",
                column: "AboutPageId",
                principalTable: "AboutPage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_sliders_homePages_HomePageId",
                table: "sliders",
                column: "HomePageId",
                principalTable: "homePages",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class MHMergWork2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "header",
                table: "SolutionPage",
                newName: "ENheader");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "solutionItems",
                newName: "ENtitle");

            migrationBuilder.RenameColumn(
                name: "desc",
                table: "solutionItems",
                newName: "ENdesc");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "solution",
                newName: "ENtitle");

            migrationBuilder.RenameColumn(
                name: "desc",
                table: "sliders",
                newName: "ENdesc");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "sliders",
                newName: "ENTitle");

            migrationBuilder.RenameColumn(
                name: "header",
                table: "ProjectPage",
                newName: "ENheader");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "ProjectItems",
                newName: "ENtitle");

            migrationBuilder.RenameColumn(
                name: "desc2",
                table: "ProjectItems",
                newName: "ENdesc2");

            migrationBuilder.RenameColumn(
                name: "desc1",
                table: "ProjectItems",
                newName: "ENdesc1");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Project",
                newName: "ENtitle");

            migrationBuilder.RenameColumn(
                name: "desc",
                table: "counters",
                newName: "ENdesc");

            migrationBuilder.AddColumn<string>(
                name: "ARheader",
                table: "SolutionPage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ARdesc",
                table: "solutionItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ARtitle",
                table: "solutionItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ARtitle",
                table: "solution",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ARTitle",
                table: "sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ARdesc",
                table: "sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ARheader",
                table: "ProjectPage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ARdesc1",
                table: "ProjectItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ARdesc2",
                table: "ProjectItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ARtitle",
                table: "ProjectItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ARtitle",
                table: "Project",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ARdesc",
                table: "counters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ARheader",
                table: "SolutionPage");

            migrationBuilder.DropColumn(
                name: "ARdesc",
                table: "solutionItems");

            migrationBuilder.DropColumn(
                name: "ARtitle",
                table: "solutionItems");

            migrationBuilder.DropColumn(
                name: "ARtitle",
                table: "solution");

            migrationBuilder.DropColumn(
                name: "ARTitle",
                table: "sliders");

            migrationBuilder.DropColumn(
                name: "ARdesc",
                table: "sliders");

            migrationBuilder.DropColumn(
                name: "ARheader",
                table: "ProjectPage");

            migrationBuilder.DropColumn(
                name: "ARdesc1",
                table: "ProjectItems");

            migrationBuilder.DropColumn(
                name: "ARdesc2",
                table: "ProjectItems");

            migrationBuilder.DropColumn(
                name: "ARtitle",
                table: "ProjectItems");

            migrationBuilder.DropColumn(
                name: "ARtitle",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ARdesc",
                table: "counters");

            migrationBuilder.RenameColumn(
                name: "ENheader",
                table: "SolutionPage",
                newName: "header");

            migrationBuilder.RenameColumn(
                name: "ENtitle",
                table: "solutionItems",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "ENdesc",
                table: "solutionItems",
                newName: "desc");

            migrationBuilder.RenameColumn(
                name: "ENtitle",
                table: "solution",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "ENdesc",
                table: "sliders",
                newName: "desc");

            migrationBuilder.RenameColumn(
                name: "ENTitle",
                table: "sliders",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "ENheader",
                table: "ProjectPage",
                newName: "header");

            migrationBuilder.RenameColumn(
                name: "ENtitle",
                table: "ProjectItems",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "ENdesc2",
                table: "ProjectItems",
                newName: "desc2");

            migrationBuilder.RenameColumn(
                name: "ENdesc1",
                table: "ProjectItems",
                newName: "desc1");

            migrationBuilder.RenameColumn(
                name: "ENtitle",
                table: "Project",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "ENdesc",
                table: "counters",
                newName: "desc");
        }
    }
}

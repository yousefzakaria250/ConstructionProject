using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class init18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Content_ContentPage_ContentPageId",
                table: "Content");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_AboutPage_AboutPageId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceItems_Services_ServiceId",
                table: "ServiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServicePage_ServicePageId",
                table: "Services");

            migrationBuilder.AddForeignKey(
                name: "FK_Content_ContentPage_ContentPageId",
                table: "Content",
                column: "ContentPageId",
                principalTable: "ContentPage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_AboutPage_AboutPageId",
                table: "Section",
                column: "AboutPageId",
                principalTable: "AboutPage",
                principalColumn: "Id");
                

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceItems_Services_ServiceId",
                table: "ServiceItems",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServicePage_ServicePageId",
                table: "Services",
                column: "ServicePageId",
                principalTable: "ServicePage",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Content_ContentPage_ContentPageId",
                table: "Content");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_AboutPage_AboutPageId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceItems_Services_ServiceId",
                table: "ServiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServicePage_ServicePageId",
                table: "Services");

            migrationBuilder.AddForeignKey(
                name: "FK_Content_ContentPage_ContentPageId",
                table: "Content",
                column: "ContentPageId",
                principalTable: "ContentPage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Section_AboutPage_AboutPageId",
                table: "Section",
                column: "AboutPageId",
                principalTable: "AboutPage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceItems_Services_ServiceId",
                table: "ServiceItems",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServicePage_ServicePageId",
                table: "Services",
                column: "ServicePageId",
                principalTable: "ServicePage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

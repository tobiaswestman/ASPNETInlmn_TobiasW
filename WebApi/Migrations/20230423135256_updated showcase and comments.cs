using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class updatedshowcaseandcomments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Offer",
                table: "Showcases",
                newName: "OfferTitle");

            migrationBuilder.RenameColumn(
                name: "Ingress",
                table: "Showcases",
                newName: "OfferDescription");

            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "Comments",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CustomerEmail",
                table: "Comments",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OfferTitle",
                table: "Showcases",
                newName: "Offer");

            migrationBuilder.RenameColumn(
                name: "OfferDescription",
                table: "Showcases",
                newName: "Ingress");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Comments",
                newName: "CustomerName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Comments",
                newName: "CustomerEmail");
        }
    }
}

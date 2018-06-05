using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookList.Migrations
{
    public partial class addAuthorAndEditoraAno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Books",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Ano",
                table: "Books",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Autor",
                table: "Books",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Editora",
                table: "Books",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ano",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Autor",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Editora",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Books",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}

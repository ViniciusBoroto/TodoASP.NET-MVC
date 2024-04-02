using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.Migrations
{
    /// <inheritdoc />
    public partial class TaskTablePopulation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO TodoTasks(Title, Description, Finished) Values('Ração', 'Comprar comida para o cachorro', 0)");
            mb.Sql("INSERT INTO TodoTasks(Title, Description, Finished) Values('Limpar tênis', 'Limpar meu Vans', 0)");
            mb.Sql("INSERT INTO TodoTasks(Title, Description, Finished) Values('Academia', 'Ir na academia hoje', 1)");
            mb.Sql("INSERT INTO TodoTasks(Title, Description, Finished) Values('Água', 'Beber 3L de água', 1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

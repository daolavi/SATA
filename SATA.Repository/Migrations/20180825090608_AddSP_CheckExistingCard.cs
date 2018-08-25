using Microsoft.EntityFrameworkCore.Migrations;

namespace SATA.Repository.Migrations
{
    public partial class AddSP_CheckExistingCard : Migration
    {
        private const string createStoreProcedureSQL = @"
CREATE PROCEDURE [dbo].[IsExistingCard]
	@CardNumber NVARCHAR(16),
	@IsExisting BIT OUTPUT
AS
BEGIN

IF(EXISTS(SELECT* FROM DBO.Card WHERE CardNumber = @CardNumber))
	SET @IsExisting = 1
ELSE
    SET @IsExisting = 0
END
";

        private const string dropStoreProcedureSQL = @"DROP PROCEDURE IsExistingCard";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(createStoreProcedureSQL);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(dropStoreProcedureSQL);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperDigital.Persistency.Migrations
{
    public partial class AddViewToDbSuperdigital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                    CREATE VIEW [accounts].Moviment
                                    AS
	                                    WITH Moviment 
	                                    AS(
	                                    SELECT [DATA] = CONVERT(VARCHAR, w.[CreatedAt], 103),
		                                       [OPERACAO] = 'S',
		                                       [TIPO] = 'SAQUE',
		                                       [VALOR] = FORMAT(w.[Value], 'c', 'pt-br'),
		                                       [DESCRICAO] = 'SAQUE EQUIP ' + w.[Equipament],
		                                       [CONTA_ORIGEM] = a.[AccountNumber],
		                                       [CONTA_DESTINO] = NULL
		                                    FROM [accounts].[Withdrawal] w
			                                    JOIN [accounts].AccountHolder a
				                                    ON w.AccountHolderId = a.Id

	                                    UNION

	                                    SELECT [DATA] = CONVERT(VARCHAR, p.[CreatedAt], 103),
		                                       [OPERACAO] = 'P',
		                                       [TIPO] = 'PAGAMENTO CONCESSIONARIA',
		                                       [VALOR] = FORMAT(p.[Value], 'c', 'pt-br'),
		                                       [DESCRICAO] = 'CLARO BR ',
		                                       [CONTA_ORIGEM] = a.[AccountNumber],
		                                       [CONTA_DESTINO] = NULL
		                                    FROM [accounts].[Payment] p
			                                    JOIN [accounts].AccountHolder a
				                                    ON p.AccountHolderId = a.Id

	                                    UNION

	                                    SELECT [DATA] = CONVERT(VARCHAR, t.[CreatedAt], 103),
		                                       [OPERACAO] = 'T',
		                                       [TIPO] = 'TRANSFERENCIA',
		                                       [VALOR] = FORMAT(t.[Value], 'c', 'pt-br'),
		                                       [DESCRICAO] = 'TRANSFERENCIA ENTRE CONTAS ',
		                                       [CONTA_ORIGEM] = a.[AccountNumber],
		                                       [CONTA_DESTINO] = t.[Account]
		                                    FROM [accounts].[Transfer] t
			                                    JOIN [accounts].AccountHolder a
				                                    ON t.AccountHolderId = a.Id

	                                    UNION

	                                    SELECT [DATA] = CONVERT(VARCHAR, d.[CreatedAt], 103),
		                                       [OPERACAO] = 'D',
		                                       [TIPO] = 'DEPOSITO',
		                                       [VALOR] = FORMAT(d.[Value], 'c', 'pt-br'),
		                                       [DESCRICAO] = 'DEPOSITO CONTAS EM CONTA CORRENTE',
		                                       [CONTA_ORIGEM] = a.[AccountNumber],
		                                       [CONTA_DESTINO] = d.[Account]
		                                    FROM [accounts].[Deposit] d
			                                    JOIN [accounts].AccountHolder a
				                                    ON d.AccountHolderId = a.Id
	                                    )

	                                    SELECT [DATA], 
		                                       [OPERACAO], 
		                                       [TIPO], 
		                                       [VALOR], 
		                                       [DESCRICAO], 
		                                       [CONTA_ORIGEM], 
		                                       [CONTA_DESTINO]
		                                    FROM Moviment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP [accounts].[Moviment]");
        }
    }
}

select * from [accounts].AccountHolder
select * from [accounts].Withdrawal
select * from [accounts].Payment
select * from [accounts].Transfer
select * from [accounts].AccountHolder

update [accounts].AccountHolder set AccountBalance = 2700 where id = 1


insert into [accounts].AccountHolder values(GETDATE(), 0, null, null, 'Adriano Victor', '12345678989', '00033258', '0021648', '0035', '', 1, 2.700)

insert into [accounts].Withdrawal values(GETDATE(), 0, null, null, 1, 20.00, '00A253390')
insert into [accounts].Payment values(GETDATE(), 0, null, null, 1, 55.00, 'ENEL')
insert into [accounts].Transfer values(GETDATE(), 0, null, null, 1, 100.00, '001', '0245987', '88')
update [accounts].Transfer set Agency = '008435', Account = '072845' where id = 1


SELECT [DATA] = CONVERT(VARCHAR, w.[CreatedAt], 103),
	   [OPERACAO] = 'S',
	   [TIPO] = 'SAQUE',
	   [VALOR] = FORMAT(w.[Value], 'c', 'pt-br'),
	   [DESCRICAO] = 'SAQUE EQUIP ' + w.[Equipament],
	   [CONTA_ORIGEM] = a.[AccountNumber],
	   NULL
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
	   NULL
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

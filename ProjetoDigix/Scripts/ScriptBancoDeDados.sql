﻿CREATE TABLE BENEFICIARIO(
	IDBENEFICIARIO	UNIQUEIDENTIFIER	NOT NULL,
	NOME			NVARCHAR(100)		NOT NULL,
	CPF				NVARCHAR(15)		NOT NULL,
	SALARIO			DECIMAL(10,2)		NOT NULL, 
	PRIMARY KEY(IDBENEFICIARIO))
GO

CREATE TABLE DEPENDENTE(
	IDDEPENDENTE	UNIQUEIDENTIFIER	NOT NULL,
	NOME			NVARCHAR(150)		NOT NULL,
	DATANASCIMENTO	DATE				NOT NULL,
	IDBENEFICIARIO	UNIQUEIDENTIFIER	NOT NULL,
	PRIMARY KEY(IDDEPENDENTE),
	FOREIGN KEY(IDBENEFICIARIO) REFERENCES BENEFICIARIO(IDBENEFICIARIO))
GO


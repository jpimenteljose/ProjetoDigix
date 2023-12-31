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

--ANTONIO
INSERT INTO BENEFICIARIO(IDBENEFICIARIO,NOME,CPF,SALARIO) VALUES('F1095812-AA2D-4FFF-9AA8-BAE82FC65604','Antonio','98765432100,850);
INSERT INTO DEPENDENTE(IDDEPENDENTE,NOME,DATANASCIMENTO,IDBENEFICIARIO) VALUES (Newid(),'Jorge','2005-08-16','F1095812-AA2D-4FFF-9AA8-BAE82FC65604');

--JOSE
INSERT INTO BENEFICIARIO(IDBENEFICIARIO,NOME,CPF,SALARIO) VALUES('11D0D3D4-DF9B-43BC-B0A3-73DE6B336842','José','98765432106,850);
INSERT INTO DEPENDENTE(IDDEPENDENTE,NOME,DATANASCIMENTO,IDBENEFICIARIO) VALUES (Newid(),'Maria','2015-07-05','11D0D3D4-DF9B-43BC-B0A3-73DE6B336842');
INSERT INTO DEPENDENTE(IDDEPENDENTE,NOME,DATANASCIMENTO,IDBENEFICIARIO) VALUES (Newid(),'João','2018-03-01','11D0D3D4-DF9B-43BC-B0A3-73DE6B336842');

--ROSANGELA
INSERT INTO BENEFICIARIO(IDBENEFICIARIO,NOME,CPF,SALARIO) VALUES('EF18D290-80AE-4E2B-9E82-EA48EC6078EC','Rosangela','65498712357','1350);
INSERT INTO DEPENDENTE(IDDEPENDENTE,NOME,DATANASCIMENTO,IDBENEFICIARIO) VALUES (Newid(),'Luiz','2016-09-15','EF18D290-80AE-4E2B-9E82-EA48EC6078EC');
INSERT INTO DEPENDENTE(IDDEPENDENTE,NOME,DATANASCIMENTO,IDBENEFICIARIO) VALUES (Newid(),'Claudia','2005-09-04','EF18D290-80AE-4E2B-9E82-EA48EC6078EC');
INSERT INTO DEPENDENTE(IDDEPENDENTE,NOME,DATANASCIMENTO,IDBENEFICIARIO) VALUES (Newid(),'Ana','2019-06-23','EF18D290-80AE-4E2B-9E82-EA48EC6078EC');

--REGINA
INSERT INTO BENEFICIARIO(IDBENEFICIARIO,NOME,CPF,SALARIO) VALUES('6B13D9CC-7947-43CE-B960-A6E909230DE9','Regina','95345876523',950);;
INSERT INTO DEPENDENTE(IDDEPENDENTE,NOME,DATANASCIMENTO,IDBENEFICIARIO) VALUES (Newid(),'Renata','2990-12-28','6B13D9CC-7947-43CE-B960-A6E909230DE9');
INSERT INTO DEPENDENTE(IDDEPENDENTE,NOME,DATANASCIMENTO,IDBENEFICIARIO) VALUES (Newid(),'Renata','2016-05-01','6B13D9CC-7947-43CE-B960-A6E909230DE9');
INSERT INTO DEPENDENTE(IDDEPENDENTE,NOME,DATANASCIMENTO,IDBENEFICIARIO) VALUES (Newid(),'Rosangela','2015-12-28','6B13D9CC-7947-43CE-B960-A6E909230DE9');
INSERT INTO DEPENDENTE(IDDEPENDENTE,NOME,DATANASCIMENTO,IDBENEFICIARIO) VALUES (Newid(),'Rosane','2017-08-03','6B13D9CC-7947-43CE-B960-A6E909230DE9');
INSERT INTO DEPENDENTE(IDDEPENDENTE,NOME,DATANASCIMENTO,IDBENEFICIARIO) VALUES (Newid(),'Romulo','2020-10-12','6B13D9CC-7947-43CE-B960-A6E909230DE9');
INSERT INTO DEPENDENTE(IDDEPENDENTE,NOME,DATANASCIMENTO,IDBENEFICIARIO) VALUES (Newid(),'Pedro','2021-11-02','6B13D9CC-7947-43CE-B960-A6E909230DE9');

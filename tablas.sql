CREATE DATABASE [HCF]   
GO 
USE [HCF] 
GO	

CREATE TABLE tbTipoEncomienda(
    [IdTipoEncomienda]              INT IDENTITY(1,1),
    [Descripcion]     NVARCHAR(300) NOT NULL,
    CONSTRAINT PK_tbTipoEncomienda_IdTipoEncomienda PRIMARY KEY(IdTipoEncomienda)
); 

INSERT INTO tbTipoEncomienda	VALUES ('Muestras');
INSERT INTO tbTipoEncomienda	VALUES ('Documentos');

CREATE TABLE tbEmpresaGuia(
    [IdEmpresaGuia]					INT IDENTITY(1,1),
    [Descripcion]					NVARCHAR(300) NOT NULL,
	Exprecion						NVARCHAR(300)
    CONSTRAINT PK_tbEmpresaGuia_IdEmpresaGuia PRIMARY KEY(IdEmpresaGuia)
); 

INSERT INTO tbEmpresaGuia	VALUES ('FEDEX','\b(\d{12}|\d{15}|\d{20})\b');

CREATE TABLE tbPagoEncomienda(
	IdPagoEncomienda INT IDENTITY(1,1),
	IdEmpresaGuia INT NOT NULL,
	Factura  NVARCHAR(50)

	CONSTRAINT	PK_tbTipoEncomienda_IdPagoEncomienda PRIMARY KEY(IdPagoEncomienda)
	CONSTRAINT  FK_tbPagoEncomienda_tbTipoUsuario_IdEmpresaGuia	FOREIGN KEY(IdEmpresaGuia) REFERENCES tbEmpresaGuia(IdEmpresaGuia)
)

CREATE TABLE tbPagoEncomiendaDetalle(
	IdPagoEncomiendaDetalle INT IDENTITY(1,1),
	IdPagoEncomienda INT NOT NULL,
	IdTipoEncomienda INT NOT NULL,
	Traking NVARCHAR(50),
	Precio DECIMAL(18,2),


	CONSTRAINT	PK_tbPagoEncomiendaDetalle_IdPagoEncomiendaDetalle PRIMARY KEY(IdPagoEncomiendaDetalle),
	CONSTRAINT  FK_tbPagoEncomiendaDetalle_IdPagoEncomienda_IdPagoEncomienda	FOREIGN KEY(IdPagoEncomienda) REFERENCES tbPagoEncomienda(IdPagoEncomienda),
	CONSTRAINT  FK_tbPagoEncomiendaDetalle_tbTipoEncomienda_IdTipoEncomienda	FOREIGN KEY(IdTipoEncomienda) REFERENCES tbTipoEncomienda(IdTipoEncomienda),
)
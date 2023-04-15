﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [TB_CONDOMINIOS] (
    [CND_ID] uniqueidentifier NOT NULL,
    [CND_NOME] varchar(100) NOT NULL,
    [CND_CNPJ] varchar(14) NOT NULL,
    [CND_NUMERO_UNIDADES] int NOT NULL,
    [CND_NUMERO_BLOCOS] int NOT NULL,
    [CND_NUMERO_ANDARES] int NOT NULL,
    [CND_DATA_FUNDACAO] datetime2 NOT NULL,
    CONSTRAINT [PK_CND_ID] PRIMARY KEY ([CND_ID])
);
GO

CREATE TABLE [TB_ENDERECOS] (
    [END_ID] uniqueidentifier NOT NULL,
    [CND_ID] uniqueidentifier NOT NULL,
    [END_LOGRADOURO] varchar(200) NOT NULL,
    [END_NUMERO] varchar(10) NOT NULL,
    [END_COMPLEMENTO] varchar(100) NOT NULL,
    [END_CEP] varchar(8) NOT NULL,
    [END_BAIRRO] varchar(100) NOT NULL,
    [END_CIDADE] varchar(100) NOT NULL,
    [END_ESTADO] varchar(2) NOT NULL,
    CONSTRAINT [PK_END_ID] PRIMARY KEY ([END_ID]),
    CONSTRAINT [FK_ENDERECOS_CONDOMINIOS] FOREIGN KEY ([CND_ID]) REFERENCES [TB_CONDOMINIOS] ([CND_ID]) ON DELETE CASCADE
);
GO

CREATE TABLE [TB_UNIDADES] (
    [UND_ID] uniqueidentifier NOT NULL,
    [UND_NUMERO] varchar(10) NOT NULL,
    [UND_ANDAR] int NOT NULL,
    [UND_BLOCO] varchar(10) NOT NULL,
    [UND_STATUS_RESIDENCIAL] int NOT NULL,
    [CND_ID] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_UND_ID] PRIMARY KEY ([UND_ID]),
    CONSTRAINT [FK_UNIDADES_CONDOMINIOS] FOREIGN KEY ([CND_ID]) REFERENCES [TB_CONDOMINIOS] ([CND_ID]) ON DELETE CASCADE
);
GO

CREATE TABLE [TB_MORADORES] (
    [MRD_ID] uniqueidentifier NOT NULL,
    [MRD_NOME] varchar(100) NOT NULL,
    [MRD_CPF] varchar(11) NOT NULL,
    [MRD_TELEFONE] varchar(20) NOT NULL,
    [MRD_EMAIL] varchar(100) NOT NULL,
    [MRD_DATA_NASCIMENTO] datetime2 NOT NULL,
    [MRD_FOTO] varchar(255) NOT NULL,
    [UND_ID] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_MRD_ID] PRIMARY KEY ([MRD_ID]),
    CONSTRAINT [FK_MORADORES_UNIDADES] FOREIGN KEY ([UND_ID]) REFERENCES [TB_UNIDADES] ([UND_ID])
);
GO

CREATE TABLE [TB_VEICULOS] (
    [VCL_ID] uniqueidentifier NOT NULL,
    [VCL_PLACA] varchar(7) NOT NULL,
    [VCL_MARCA] varchar(100) NOT NULL,
    [VCL_MODELO] varchar(100) NOT NULL,
    [VCL_COR] varchar(50) NOT NULL,
    [VCL_ANO] int NOT NULL,
    [UND_ID] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_VCL_ID] PRIMARY KEY ([VCL_ID]),
    CONSTRAINT [FK_Veiculo_Unidade] FOREIGN KEY ([UND_ID]) REFERENCES [TB_UNIDADES] ([UND_ID])
);
GO

CREATE UNIQUE INDEX [IX_TB_ENDERECOS_CND_ID] ON [TB_ENDERECOS] ([CND_ID]);
GO

CREATE INDEX [IX_TB_MORADORES_UND_ID] ON [TB_MORADORES] ([UND_ID]);
GO

CREATE INDEX [IX_TB_UNIDADES_CND_ID] ON [TB_UNIDADES] ([CND_ID]);
GO

CREATE INDEX [IX_TB_VEICULOS_UND_ID] ON [TB_VEICULOS] ([UND_ID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230415151628_InitialMigration', N'6.0.16');
GO

COMMIT;
GO


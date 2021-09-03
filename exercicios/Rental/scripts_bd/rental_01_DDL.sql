CREATE DATABASE Rental;
GO

USE Rental;
GO

CREATE TABLE empresa (
	IdEmpresa TINYINT PRIMARY KEY IDENTITY(1,1),
	end_empresa VARCHAR(100), 
	Cnpj CHAR(14),
);
GO

CREATE TABLE marca (
	IdMarca TINYINT PRIMARY KEY IDENTITY(1,1),
	nomeMarca VARCHAR(20),
);
GO

CREATE TABLE modelo (
	IdModelo TINYINT PRIMARY KEY IDENTITY(1,1),
	IdMarca TINYINT FOREIGN KEY REFERENCES marca (IdMarca),
	nomeModelo VARCHAR(50),
);
GO

CREATE TABLE veiculo (
	IdVeiculo TINYINT PRIMARY KEY IDENTITY (1,1),
	IdEmpresa TINYINT FOREIGN KEY REFERENCES empresa (IdEmpresa),
	IdModelo TINYINT FOREIGN KEY REFERENCES modelo (IdModelo),
	placaVeiculo CHAR(7),
);
GO

CREATE TABLE cliente (
	IdCliente SMALLINT PRIMARY KEY IDENTITY (1,1),
	nomeCliente VARCHAR(50) NOT NULL,
	sobrenomeCliente VARCHAR (50) NOT NULL,
	cpfCliente CHAR(11) UNIQUE,
);
GO

CREATE TABLE aluguel (
	IdAluguel INT PRIMARY KEY IDENTITY (1,1),
	IdCliente SMALLINT FOREIGN KEY REFERENCES cliente (IdCliente),
	IdVeiculo TINYINT FOREIGN KEY REFERENCES veiculo (IdVeiculo),
	dataAluguel DATETIME,
	valorAluguel MONEY,
	prazoLocacao TINYINT,
);
GO
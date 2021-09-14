USE InLock_Games; 
GO

INSERT INTO Estudios (NomeEstudio)
VALUES	('Blizzard') , ('Rockstar Studios') ,('Square Enix');
GO

INSERT INTO Jogos (NomeJogo, DescricaoJogo, DataLancamento, ValorJogo, IdEstudio) 
VALUES ('Diablo 3', '� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�', '15/05/2012', 99.00 , 1) ,
		('Red Dead Redemption II', 'Jogo eletr�nico de a��o-aventura western', '26/10/2018', 120.00, 2);

GO

INSERT INTO TiposUsuarios (NomeTipoUsuario)
VALUES ('ADMINISTRADOR') , ('CLIENTE');
GO

INSERT INTO Usuarios (NomeUsuario, Email, Senha, IdTipoUsuario)
VALUES ('Fernando','cliente@cliente.com', '12345', 2), ('Lucas','admin@admin.com', '54321', 1)
GO
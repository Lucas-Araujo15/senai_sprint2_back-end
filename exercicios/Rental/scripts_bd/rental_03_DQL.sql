USE Rental;
GO

SELECT * FROM empresa;
GO

SELECT * FROM marca;
GO

SELECT * FROM modelo;
GO

SELECT * FROM veiculo;
GO

SELECT * FROM cliente;
GO

SELECT * FROM aluguel;
GO

SELECT * FROM usuario;
GO

SELECT * FROM tipoUsuario;
GO

-- SELECT UTILIZANDO JOIN->

-- Listar todos os alugueis mostrando as datas de início e fim, o nome do cliente que alugou e nome do modelo do carro:

SELECT IdAluguel, nomeCliente, sobrenomeCliente, nomeModelo, placaVeiculo, dataInicio, dataFim, valorAluguel FROM aluguel
LEFT JOIN veiculo
ON veiculo.IdVeiculo = aluguel.IdVeiculo
INNER JOIN modelo
ON modelo.IdModelo = veiculo.IdModelo
LEFT JOIN cliente
ON cliente.IdCliente = aluguel.IdCliente


-- Listar os alugueis de um determinado cliente mostrando seu nome, as datas de início e fim e o nome do modelo do carro:

SELECT IdAluguel, nomeCliente, sobrenomeCliente nomeModelo, placaVeiculo, dataInicio, dataFim, valorAluguel FROM aluguel
LEFT JOIN veiculo
ON veiculo.IdVeiculo = aluguel.IdVeiculo
INNER JOIN modelo
ON modelo.IdModelo = veiculo.IdModelo
LEFT JOIN cliente
ON cliente.IdCliente = aluguel.IdCliente
WHERE nomeCliente = 'Lucas'
SELECT * FROM PRODUTO

INSERT INTO PRODUTO (Descricao, DataCriacao) VALUES ('Farinha', GETDATE())
INSERT INTO PRODUTO (Descricao, DataCriacao) VALUES ('Açúcar', GETDATE())
INSERT INTO PRODUTO (Descricao, DataCriacao) VALUES ('Sal', GETDATE())

SET IDENTITY_INSERT PRODUTO ON

DELETE FROM PRODUTO WHERE ID=3

UPDATE PRODUTO SET Descricao = 'Chocolate' WHERE ID = 1

DROP TABLE PRODUTO

select Id,Descricao, DataCriacao, case when status = 0 then 'Inativo' else 'Ativo' end status from Produto
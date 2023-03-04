CREATE DATABASE CONTROLE_DA_LOJA

USE CONTROLE_DA_LOJA

CREATE TABLE EQUIPAMENTO
(
    ID INT IDENTITY(1,1)NOT NULL,
    NOME VARCHAR(50) NOT NULL,
    PRECO FLOAT NOT NULL,
    NR_SERIE VARCHAR(100) NOT NULL,
    DATA_FABRICACAO DATE NOT NULL,
    FABRICANTE VARCHAR (50) NOT NULL

        CONSTRAINT PK_EQUIPAMENTO PRIMARY KEY (ID)
)

USE CONTROLE_DA_LOJA

CREATE TABLE CHAMADO
(
    ID INT IDENTITY (1,1) NOT NULL,
    TITULO VARCHAR(50)NOT NULL,
    DESCRICAO NVARCHAR(500) NOT NULL,
    EQUIPAMENTO INT NOT NULL,
    DATA_ABERTURA DATETIME NOT NULL

        CONSTRAINT PK_CHAMADO PRIMARY KEY (ID)
        CONSTRAINT FK_CHAMADO FOREIGN KEY
    (EQUIPAMENTO) REFERENCES EQUIPAMENTO
    (ID)

)


USE CONTROLE_DA_LOJA

INSERT INTO EQUIPAMENTO
    (NOME, PRECO, NR_SERIE, DATA_FABRICACAO,FABRICANTE)
VALUES
('Projetor PowerLite S39', 1250, '123456789', (GETDATE()-100), 'Epson'),
('Impressora Deskjet Ink Advantage 2776', 2050, '0987654321', (GETDATE()-600), 'LG'),
(' Notebook Inspiron 15 3000', 3520, '2468101214', (GETDATE()-150), 'Dell')


USE CONTROLE_DA_LOJA

INSERT INTO CHAMADO
    (TITULO, DESCRICAO, EQUIPAMENTO, DATA_ABERTURA)
VALUES
('Impressora', 'Descrição: Olá, estou com problemas na minha Impressora. 
Ela está apresentando falhas na impressão, com manchas e riscos nas páginas. 
Já fiz uma limpeza nos cartuchos de tinta, mas o problema persiste.
Gostaria de agendar uma visita técnica para solucionar esse problema.',
1, (GETDATE()-5)),
('Projetor', 'Descrição: Olá, estou com problemas no meu Projetor. 
Ele está apresentando problemas na exibição das imagens, 
com uma distorção nas cores e na nitidez. 
Já verifiquei as conexões e ajustei as configurações, 
mas o problema persiste.
Preciso de assistência técnica para resolver esse problema.',
2,(GETDATE()-4))




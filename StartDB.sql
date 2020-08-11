create database Hungry
go

use Hungry
go

create table Adendo
(
	Id int identity,
	Nome nvarchar(64) not null,
	Ativo bit not null,
	VigenciaInicial smalldatetime null,
	VigenciaFinal smalldatetime null,

	constraint PK_Adendo primary key([Id])
)

create table Produto
(
	Id int identity,
	Nome nvarchar(64) not null,
	Valor decimal(4,2) not null,

	constraint PK_Produto primary key([Id])
)

create table Cliente
(
	Id int identity,
	Nome nvarchar(64) not null,
	Endereco nvarchar(128) not null,

	constraint PK_Cliente primary key([Id])
)

create table Pedido
(
	Id int identity,
	DataHoraCriacao smalldatetime not null,
	Endereco nvarchar(128) not null,
	ClienteId int not null,

	constraint PK_Pedido primary key([Id]),
	constraint FK_Pedido_Cliente foreign key([ClienteId]) references Cliente ([Id])
)

create table PedidoItem
(
	Id int identity,
	PedidoId int not null,
	ProdutoId int not null,
	Quantidade decimal(2,1) not null,
	ValorUnitario decimal(4,2) not null,

	constraint PK_PedidoItem primary key([Id]),
	constraint FK_PedidoItem_Pedido foreign key([PedidoId]) references Pedido ([Id]),
	constraint FK_PedidoItem_Produto foreign key([ProdutoId]) references Produto ([Id])
)

create table PedidoAdendo
(
	Id int identity,
	PedidoId int not null,
	AdendoId int not null,
	Valor decimal(4,2) not null,

	constraint PK_PedidoAdendo primary key([Id]),
	constraint FK_PedidoAdendo_Pedido foreign key([PedidoId]) references Pedido ([Id]),
	constraint FK_PedidoAdendo_Produto foreign key([AdendoId]) references Adendo ([Id])
)
go

if not exists(select top 1 1 from Adendo)
begin
	insert into Adendo values
	('Frete', 0, null, null),
	('Desconto especial de Dia dos pais', 1, '2020-08-09 00:00', '2020-08-09 23:59')
end
go

if not exists(select top 1 1 from Produto)
begin
	insert into Produto values
	('3 Queijos', 50.00),
	('Frango com requeijão', 59.99),
	('Mussarela', 42.50),
	('Calabresa', 42.50),
	('Pepperoni', 55.00),
	('Portuguesa', 45.00),
	('Veggie', 59.99)
end
go

if not exists(select top 1 1 from Cliente)
begin
	insert into Cliente values
	('Teste', 'Avenida Principal, 100 - Centro')
end
go
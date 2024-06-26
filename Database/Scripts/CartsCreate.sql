CREATE TABLE IF NOT EXISTS [ShoppingCart]
(
	[CustomerId]	TEXT			NOT NULL,	-- GUID
	[CreateDateUtc]	DATETIME		NOT NULL,
	PRIMARY KEY([CustomerId])
);

CREATE TABLE IF NOT EXISTS [ShoppingCartDetail] 
(
	[CustomerId]	TEXT			NOT NULL,	-- GUID
	[ProductId]		INTEGER			NOT NULL,
	[Quantity]		INTEGER			NOT NULL 	DEFAULT(1),
	[UnitPrice]		DECIMAL			NOT NULL,
	FOREIGN KEY([CustomerId]) REFERENCES [ShoppingCart]([CustomerId]),
	PRIMARY KEY([CustomerId], [ProductId])
);


CREATE TABLE IF NOT EXISTS [WishList]
(
	[CustomerId]	TEXT			NOT NULL,	-- GUID
	[CreateDateUtc]	DATETIME		NOT NULL,
	PRIMARY KEY([CustomerId])
);

CREATE TABLE IF NOT EXISTS [WishListDetail] 
(
	[CustomerId]	TEXT			NOT NULL,	-- GUID
	[ProductId]		INTEGER			NOT NULL,
	FOREIGN KEY([CustomerId]) REFERENCES [WishList]([CustomerId]),
	PRIMARY KEY([CustomerId], [ProductId])
);



CREATE TABLE IF NOT EXISTS [Category]
(
	[CategoryId]	INTEGER			NOT NULL,
	[Description]	VARCHAR(255) 	NOT NULL,
	PRIMARY KEY([CategoryId] AUTOINCREMENT)
);


CREATE TABLE IF NOT EXISTS [Product]
(
	[ProductId]		INTEGER			NOT NULL,
	[Description]	VARCHAR(255) 	NOT NULL,
	[CategoryId]	INTEGER			NOT NULL,
	[UnitPrice]		DECIMAL			NOT NULL,
	[UnitsInStock]	INTEGER	 		NOT NULL	DEFAULT(0),
	[UnitsOnOrder]	INTEGER	 		NOT NULL	DEFAULT(0),
	[ReorderLevel]	INTEGER	 		NOT NULL	DEFAULT(0),
	[Discontinued]	BOOLEAN 		NOT NULL	DEFAULT(0),	
	FOREIGN KEY([CategoryId]) REFERENCES [Category]([CategoryId]),
	PRIMARY KEY([ProductId] AUTOINCREMENT)
);


CREATE INDEX IF NOT EXISTS [IDX_Product_Category] ON [Product] 
(
	[CategoryId]		ASC
);
CREATE TABLE IF NOT EXISTS [Order]
(
	[OrderId]		INTEGER			NOT NULL,
	[CustomerId]	TEXT			NOT NULL,	-- GUID
	[CreateDateUtc]	DATETIME		NOT NULL,
	[ShipDateUtc]	DATETIME			NULL,
	[TrackingId]	VARCHAR(100)		NULL,
	PRIMARY KEY([OrderId] AUTOINCREMENT)
);

CREATE TABLE IF NOT EXISTS [OrderDetail] 
(
	[OrderId]		INTEGER			NOT NULL,
	[ProductId]		INTEGER			NOT NULL,
	[Quantity]		INTEGER			NOT NULL 	DEFAULT(1),
	[UnitPrice]		DECIMAL			NOT NULL,
	[Discount]		DECIMAL			NOT NULL	DEFAULT(0),
	FOREIGN KEY([OrderId]) REFERENCES [Order]([OrderId]),
	PRIMARY KEY([OrderId], [ProductId])
);

CREATE INDEX IF NOT EXISTS [IDX_OrderDetail_Order] ON [OrderDetail] 
(
	[OrderId]		ASC
);
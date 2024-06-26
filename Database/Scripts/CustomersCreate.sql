CREATE TABLE IF NOT EXISTS [Customer] 
(
	[CustomerId]	TEXT			NOT NULL,	-- GUID
	[FirstName]		VARCHAR(25)			NULL,
	[LastName]		VARCHAR(255)	NOT NULL,	-- Can be used as Company Name
	[EmailAddress] 	VARCHAR(100)	NOT NULL,
	[PhoneNumber]	VARCHAR(15)			NULL,
	PRIMARY KEY([CustomerId])
);


CREATE TABLE IF NOT EXISTS [AddressType] 
(
	[AddressTypeId]	INTEGER			NOT NULL,
	[Description]	VARCHAR(255) 	NOT NULL,
	PRIMARY KEY([AddressTypeId] AUTOINCREMENT)
);


CREATE TABLE IF NOT EXISTS [Address] 
(
	[AddressId]		INTEGER	 		NOT NULL,
	[CustomerId]	TEXT			NOT NULL,	-- GUID
	[AddressTypeId]	INTEGER		 	NOT NULL,
	[StreetLine1]	VARCHAR(255)	NOT NULL,
	[StreetLine2]	VARCHAR(255)		NULL,
	[City]			VARCHAR(50)		NOT NULL,
	[Region]		VARCHAR(50)		NOT NULL,
	[PostalCode]	VARCHAR(10)		NOT NULL,
	FOREIGN KEY([CustomerId]) REFERENCES [Customer]([CustomerId]),
	FOREIGN KEY([AddressTypeId]) REFERENCES [AddressType]([AddressTypeId]),
	PRIMARY KEY([AddressId] AUTOINCREMENT)
);


CREATE INDEX IF NOT EXISTS [IDX_Customer_EmailAddress] ON [Customer] 
(
	[EmailAddress]		ASC
);

CREATE UNIQUE INDEX IF NOT EXISTS [IDX_Address_Customer_AddresType] ON [Address] 
(
	[CustomerId]		ASC,
	[AddressTypeId]		ASC
);
Create Database LitmosAimBridge
Go
Use LitmosAimBridge
Go
Create table Configs(ConfigID INT NOT NULL  iDENTITY(1,1) PRIMARY KEY, [Key] NVARCHAR(100), [Value] NVARCHAR(100))
Go
INSERT INTO Configs([key],[Value]) VALUES ('ABapikey', 'e8ef19cd-cd95-4e61-b78f-d3a2d04fcc5a')
GO
INSERT INTO Configs([key],[Value]) VALUES ('ABSource','abhiram')
GO
INSERT INTO Configs([key],[Value]) VALUES ('basurl','https://api.litmos.com/v1.svc/')
GO

CREATE DATABASE AimBridgeAPI
GO
USE AimBridgeAPI
GO
CREATE TABLE Configuration
(Id          INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
 ConfigKey   NVARCHAR(100) NOT NULL, 
 ConfigValue NVARCHAR(100) NOT NULL
)
GO
INSERT INTO Configuration
(ConfigKey, 
 ConfigValue
)
VALUES
('apikey', 
 'e8ef19cd-cd95-4e61-b78f-d3a2d04fcc5a'
)
GO
CREATE PROCEDURE GetAPIKey
AS
     SELECT ConfigValue
     FROM Configuration
     WHERE ConfigKey = 'apikey'
GO
CREATE PROCEDURE UpdateAPIKey(@apikey NVARCHAR(100))
AS
     UPDATE Configuration
       SET 
           ConfigValue = @apikey
     WHERE ConfigKey = 'apikey'
GO
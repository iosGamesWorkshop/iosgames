CREATE TABLE [BT].[GameBattleshipMatch]
(
	[MatchID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [FirstUserID] INT NOT NULL, 
    [SecondUserID] INT NOT NULL, 
    [FirstUserShipsSetup] VARCHAR(255) NOT NULL, 
    [SecondUserShipsSetup] VARCHAR(255) NOT NULL, 
    [Created] DATETIME NOT NULL DEFAULT GETUTCDATE(), 
    [Finished] DATETIME NULL,

	CONSTRAINT [FK_GameBattleshipMatch_FirstUser] FOREIGN KEY (FirstUserID) REFERENCES [BT].[User](UserID),
	CONSTRAINT [FK_GameBattleshipMatch_SecondUser] FOREIGN KEY (SecondUserID) REFERENCES [BT].[User](UserID)

)

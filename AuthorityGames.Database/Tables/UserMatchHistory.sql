CREATE TABLE [BT].[UserMatchHistory]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [UserID] INT NOT NULL, 
    [MatchID] INT NOT NULL, 
    [MatchResult] VARCHAR(15) NOT NULL, 
    [Score] INT NOT NULL,

	CONSTRAINT [FK_User_UserID] FOREIGN KEY (UserID) REFERENCES [BT].[User](UserID),
	CONSTRAINT [FK_GameBattleshipMatch_MatchID] FOREIGN KEY (MatchID) REFERENCES [BT].[GameBattleshipMatch](MatchID),
	CONSTRAINT [CHK_GameBattleshipMatch_MatchResult] CHECK (MatchResult = 'WIN' OR MatchResult = 'LOSE' OR MatchResult = 'DRAW')
)

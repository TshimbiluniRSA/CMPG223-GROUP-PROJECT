CREATE TABLE [dbo].[MatchInfo]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Team1_ID] INT NULL, 
    [Team2_ID] INT NULL, 
    [Team1_Score] INT NULL, 
    [Team2_Score] INT NULL, 
    [ TournamentID] INT NULL
)

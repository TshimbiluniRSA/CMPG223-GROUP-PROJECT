﻿CREATE TABLE [dbo].[Tournament]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[StartDate] DateTime NOT NULL,
	[GameUsedID] INT NOT NULL,
	[PlatformID] INT NOT NULL,
	[MaximumParticipants] SMALLINT NOT NULL,
	[LastEnterenceDate] DATETIME NOT NULL,
	[VenueID] INT NOT NULL

	CONSTRAINT FK_GameUsed_ID FOREIGN KEY (GameUsedID) REFERENCES GAME (Id),
	CONSTRAINT FK_PlatformID FOREIGN KEY (PlatformID) REFERENCES PLATFORM (Id),
	CONSTRAINT FK_VenueID FOREIGN KEY (VenueID) REFERENCES VANUEINFO (Id)
)

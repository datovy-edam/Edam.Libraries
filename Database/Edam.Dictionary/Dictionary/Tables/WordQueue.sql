CREATE TABLE [Dictionary].[WordQueue] (
    [KeyID]        NVARCHAR (40)      NOT NULL,
    [LexiconID]    NVARCHAR (128)     NOT NULL,
    [Category]     NVARCHAR (128)     NOT NULL,
    [Term]         NVARCHAR (128)     NOT NULL,
    [OriginalTerm] NVARCHAR (128)     NOT NULL,
    [Soundex]      NVARCHAR (4)       NOT NULL,
    [Confidence]   DECIMAL (18, 2)    NULL,
    [Definition]   NVARCHAR (MAX)     NOT NULL,
    [Status]       INT                NULL,
    [CreatedDate]  DATETIMEOFFSET (7) NOT NULL,
    [UpdatedDate]  DATETIMEOFFSET (7) NOT NULL,
    CONSTRAINT [PK_WordQueue] PRIMARY KEY CLUSTERED ([KeyID] ASC)
);


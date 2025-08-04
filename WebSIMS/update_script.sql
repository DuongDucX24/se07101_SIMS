IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Courses] (
    [CourseID] int NOT NULL IDENTITY,
    [CourseCode] nvarchar(20) NOT NULL,
    [CourseName] nvarchar(100) NOT NULL,
    [Description] nvarchar(200) NOT NULL,
    [Credits] integer NOT NULL,
    [Department] nvarchar(100) NOT NULL,
    [CreatedAt] datetime2 NULL,
    CONSTRAINT [PK_Courses] PRIMARY KEY ([CourseID])
);

CREATE TABLE [Users] (
    [UserID] int NOT NULL IDENTITY,
    [Username] nvarchar(30) NOT NULL,
    [PasswordHash] nvarchar(255) NOT NULL,
    [Role] nvarchar(100) NOT NULL,
    [CreatedAt] datetime2 NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserID])
);

CREATE TABLE [Students] (
    [StudentId] int NOT NULL IDENTITY,
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    [DateOfBirth] datetime2 NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [EnrollmentDate] datetime2 NOT NULL,
    [UserId] int NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY ([StudentId]),
    CONSTRAINT [FK_Students_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserID])
);

CREATE INDEX [IX_Students_UserId] ON [Students] ([UserId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250804020204_AddStudentEntity', N'9.0.7');

COMMIT;
GO


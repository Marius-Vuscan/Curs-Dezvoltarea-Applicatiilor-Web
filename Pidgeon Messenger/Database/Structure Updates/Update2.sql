USE [Pidgeon Messenger];

CREATE TABLE UsersGroup(
	Id nvarchar(450),
	Name VARCHAR(255),
	CONSTRAINT PK_UsersGroup PRIMARY KEY(Id),
	CONSTRAINT UC_UsersGroup_Name UNIQUE(Name)
);

CREATE TABLE UserVSGroup(
	Id nvarchar(450),
	UserId nvarchar(450),
	GroupId nvarchar(450),
	CONSTRAINT PK_UserVSGroup PRIMARY KEY(Id),
	CONSTRAINT FK_UserVSGroup_User FOREIGN KEY(UserId) REFERENCES AspNetUsers(Id),
	CONSTRAINT FK_UserVSGroup_Group FOREIGN KEY(GroupId) REFERENCES UsersGroup(Id)
);

CREATE TABLE Message(
	Id nvarchar(450),
	UserVSGroupId nvarchar(450),
	Message VARCHAR(MAX) NOT NULL,
	Date DateTime NOT NULL,
	CONSTRAINT PK_Message PRIMARY KEY(Id),
	CONSTRAINT FK_Message_UserVSGroup FOREIGN KEY(UserVSGroupId) REFERENCES UserVSGroup(Id),
);
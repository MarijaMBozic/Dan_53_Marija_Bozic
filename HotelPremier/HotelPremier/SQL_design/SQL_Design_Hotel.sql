CREATE DATABASE HotelPremier;
GO
Use HotelPremier

drop table if exists Request 
drop table if exists Manager
drop table if exists Worker
drop table if exists HotelUser
drop table if exists Gender
drop table if exists Role
drop table if exists Engagment
drop table if exists QualificationLevel

create table Gender(
   GenderId      int            identity (1,1) primary key,   
   Name          nvarchar(100)   unique not null
   )

create table Role(
   RoleId      int            identity (1,1) primary key,   
   Name        nvarchar(100)   unique not null
   )

create table Engagment(
   EngagmentId  int            identity (1,1) primary key,   
   Name         nvarchar(100)   unique not null
   )

create table QualificationLevel(
   QualificationLevelId  int            identity (1,1) primary key,   
   Name                 nvarchar(100)   unique not null
   )
create table HotelUser(
   HotelUserId                 int            identity (1,1) primary key,   
   FullName                    nvarchar(100)           not null,
   DateOfBirth                 date                   default getDate(),
   Email                       nvarchar(100)  unique  not null,
   Username                    nvarchar(100)  unique  not null,
   Password                    nvarchar(100)          not null,
   RoleId                      int                    not null,
   FOREIGN KEY (RoleId)  REFERENCES Role(RoleId)
)

create table Manager(
 ManagerId                              int            identity (1,1) primary key,   
 HotelUserId                            int                    not null,
 FOREIGN KEY (HotelUserId)  REFERENCES HotelUser(HotelUserId),
 HotelFloor                             int        unique      not null,
 WorkExperience                         int                    not null,
 QualificationLevelId                   int                    not null,
 FOREIGN KEY (QualificationLevelId)  REFERENCES QualificationLevel(QualificationLevelId),
)

create table Worker(
 WorkerId                               int            identity (1,1) primary key,   
 HotelFloor                            int                    not null,
 Citizenship                   nvarchar(100)                   not null,
 Salary                                 money                  not null    ,
 HotelUserId                            int                    not null,
 FOREIGN KEY (HotelUserId)  REFERENCES HotelUser(HotelUserId),
 GenderId                               int                    not null,
 FOREIGN KEY (GenderId)  REFERENCES Gender(GenderId),
 EngagmentId                            int                    not null,
 FOREIGN KEY (EngagmentId)  REFERENCES Engagment(EngagmentId),
 WorkExperience                         int                    not null,
 QualificationLevelId                   int                    not null,
 FOREIGN KEY (QualificationLevelId)  REFERENCES QualificationLevel(QualificationLevelId),
  ManagerId                            int                    not null,
 FOREIGN KEY (ManagerId)  REFERENCES Manager(ManagerId),
)

create table Request(
 RequestId                               int            identity (1,1) primary key,   
 StartDate                              date                   default getDate(),
 EndDate                                date                   default getDate(),
 Reason                        nvarchar(100)                   not null,
 Status                                 bit                        null,
 Explanation                   nvarchar(100)                       null,
 WorkerId                            int                       not null,
 FOREIGN KEY (WorkerId)  REFERENCES Worker(WorkerId),
 ManagerId                              int                    not null,
 FOREIGN KEY (ManagerId)  REFERENCES Manager(ManagerId) ,
 IsDeleted                              bit                    default 0 not null
)

Insert into Gender(Name)
values('Female'),
      ('Male')

Insert into Role(Name)
values('Worker'),
      ('Manager')
	  

Insert into QualificationLevel(Name)
values('I'),
      ('II'),
	  ('III'),
      ('IV'),
	  ('V'),
	  ('VI'),
      ('VII')

Insert into Engagment(Name)
values('Cleaning'),
      ('Cooking'),
	  ('Supervising'),
      ('Reporting')

go

CREATE VIEW vwManager AS
	SELECT        dbo.QualificationLevel.Name AS QualificationLevelId, dbo.HotelUser.HotelUserId, dbo.HotelUser.FullName, dbo.HotelUser.DateOfBirth, dbo.HotelUser.Email, dbo.HotelUser.Username, dbo.HotelUser.Password, 
                         dbo.HotelUser.RoleId, dbo.Manager.ManagerId, dbo.Manager.HotelFloor, dbo.Manager.WorkExperience, dbo.Manager.QualificationLevelId AS Expr1
	FROM            dbo.QualificationLevel INNER JOIN
                         dbo.Manager ON dbo.QualificationLevel.QualificationLevelId = dbo.Manager.QualificationLevelId INNER JOIN
                         dbo.HotelUser ON dbo.Manager.HotelUserId = dbo.HotelUser.HotelUserId

go

CREATE VIEW vwRequest AS
SELECT        dbo.Request.RequestId, dbo.Request.StartDate, dbo.Request.EndDate, dbo.Request.Reason, dbo.Request.Status, dbo.Request.Explanation, dbo.Request.WorkerId, dbo.Request.ManagerId, dbo.Request.IsDeleted AS Mgn, 
                         dbo.Manager.ManagerId AS Expr1, dbo.Worker.WorkerId AS Expr2
FROM            dbo.Request INNER JOIN
                         dbo.Manager ON dbo.Request.ManagerId = dbo.Manager.ManagerId INNER JOIN
                         dbo.Worker ON dbo.Request.WorkerId = dbo.Worker.WorkerId

go

CREATE VIEW vwWorker AS
	SELECT        dbo.HotelUser.HotelUserId, dbo.HotelUser.FullName, dbo.HotelUser.DateOfBirth, dbo.HotelUser.Email, dbo.HotelUser.Username, dbo.HotelUser.Password, dbo.HotelUser.RoleId, dbo.Worker.WorkerId, dbo.Worker.Citizenship, 
                         dbo.Worker.GenderId, dbo.Worker.EngagmentId, dbo.Worker.Salary, dbo.Worker.HotelFloor, dbo.Worker.WorkExperience, dbo.Worker.QualificationLevelId, dbo.Engagment.Name, dbo.Worker.ManagerId
	FROM            dbo.HotelUser INNER JOIN
                         dbo.Worker ON dbo.HotelUser.HotelUserId = dbo.Worker.HotelUserId INNER JOIN
                         dbo.Engagment ON dbo.Worker.EngagmentId = dbo.Engagment.EngagmentId
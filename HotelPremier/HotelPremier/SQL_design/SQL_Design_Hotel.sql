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
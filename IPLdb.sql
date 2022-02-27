--Database creation
create Database IPLdb
use IPLdb



----1.User Table-----
create table Users(UserId int constraint pk_user primary key,UserName  varchar (20),Password varchar(20),FirstName varchar (20),Lastname varchar (20) )
Select * from users

----2.Roles Table-----
create table Roles (RoleId int constraint pk_Roles primary key, RoleName varchar(20))



----3.UserRoles Table-----
create table UserRoles (UserId int constraint fk_user foreign key references Users(UserId), RoleId int constraint fk_Role foreign key references Roles(RoleId))
Select * from userroles
--make userid pk

----4.Team Table-----
create table Team (Id int constraint pk_Team primary key, Team_Name Varchar(20) ,GroundName varchar(20), Franchises Varchar(40))


----5.Player Table-----
create table Player (Player_Id int constraint pk_Player primary key,TeamId int constraint fk_Team foreign key references Team(Id), Name Varchar(20), Age int, 
SpecialtyId int constraint fk_Specialty foreign key references Specialty(SpecialityId))


---6.Specialty Table----
create table Specialty (SpecialityId int constraint pk_Specialty primary key, SpecialityDescription Varchar(20))

---7.Match Table----
create table Matches
(Id int constraint pk_Match primary key ,
TeamOneId int constraint fk_Team2 foreign key references Team(Id),
TeamTwoId int constraint fk_Team1 foreign key references Team(Id),
VenueId int  constraint fk_Venue1 foreign key references Venue(Id), 
ScheduleId int constraint fk_Schedule foreign key references Schedule(Id))




----8.Venue Table----
Create table Venue (Id int constraint pk_Venue primary key, Location Varchar(20), Description Varchar(20))


----9.Schedule-----
create table Schedule(Id int constraint pk_Schedule primary key,VenueId int constraint fk_Venue foreign key references Venue (Id), MatchDate Date,
StartTime Time, EndTime Time)
alter table schedule add  MatchId int constraint fk_Match foreign key references Matches (Id) 



----10.Ticket Table ----
create table Ticket
( Id int constraint pk_Ticket primary key, 
MatchId int constraint fk_Schedule1 foreign key references Matches(Id),
CategoryId int constraint fk_TicketCategory foreign key references TicketCategory(Id), 
Price int)




---11.TicketCategory-----
create table TicketCategory( Id int constraint pk_TicketCategory primary key,Name varchar (20),Description varchar (20))


-----12.News----
create table News( Id int constraint pk_News primary key, NewsDate Date, MatchId int constraint fk_Match3 foreign key references Matches(Id), Description Varchar(20))


----13.Statistics----
create Table Statistic
(TeamId int constraint fk_Team3 foreign key references Team(Id), 
Played int, Won int , Lost int, Tied int, 
N_R decimal,NetRR decimal, 
ForAgainst int,Pts int)
--make teamid pk



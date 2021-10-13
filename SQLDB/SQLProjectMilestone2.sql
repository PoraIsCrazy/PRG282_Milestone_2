USE [Student Info]
GO
CREATE TABLE StudentInfo
(
StudentNum INT Identity(1,1) PRIMARY KEY,
StudentName VARCHAR(20) NOT NULL,
StudentSurname VARCHAR(20) NOT NULL,
StudentImage VARBINARY,
StudentDOB DATE,
StudentGender VARCHAR(10) ,
PhoneNum VARCHAR(10) NOT NULL UNIQUE,
Adress VARCHAR(25),
ModuleCodes VARCHAR(20),
CHECK(ModuleCodes in('151','152','171','172','181','182','251','251','271','272','281','282','371','372','381','382')),
CHECK(StudentGender in('Male','Female','Other'))
)

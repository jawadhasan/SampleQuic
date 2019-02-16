CREATE DATABASE dbQuiz17
GO
USE dbQuiz17
GO 
CREATE TABLE tblStudent
(
STD_ID INT PRIMARY KEY IDENTITY,
STD_NAME NVARCHAR(MAX),
STD_ENROLL NVARCHAR(MAX),
STD_PWD NVARCHAR(MAX)
) 
GO
CREATE TABLE tblResult
(
RES_ID INT PRIMARY KEY IDENTITY,
RES_NAME NVARCHAR(MAX),
RES_ENROLL NVARCHAR(MAX),
RES_MARKS FLOAT
)
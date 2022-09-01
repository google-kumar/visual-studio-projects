

create database Clinic_Management_System

use Clinic_Management_System

create table User_Details(UserName varchar(10) primary key,FirstName varchar(20),LastName varchar(20),Password varchar(20))

create table Doctor_Details(DoctorID varchar(10) primary key,FirstName varchar(20),LastName varchar(20),Sex varchar(1),Specialization varchar(20),VisitingHours_From varchar(5),VisitingHours_To varchar(5))

create table Patient_Details(PatientID varchar(10) primary key,FirstName varchar(20),LastName varchar(20),Sex varchar(1),Age int,DateofBirth varchar(11))

create table Appointment_Details(PatientID varchar(10),Specialization varchar(20),DoctorID varchar(10),DoctorName varchar(20),VisitDate varchar(11),AppointmentTime varchar(13))

create proc GetUserDetails as select * from User_Details

create proc GetDoctorDetails as select * from Doctor_Details

create proc GetPatientDetails as select * from Patient_Details

create proc GetAppointmentDetails as select * from Appointment_Details






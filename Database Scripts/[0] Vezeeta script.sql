/*drop table cart_ CASCADE CONSTRAINTS;
drop table users_ CASCADE CONSTRAINTS;
drop table booking_ CASCADE CONSTRAINTS;
drop table medicine_ CASCADE CONSTRAINTS;
drop table Doctor_ CASCADE CONSTRAINTS;
drop table Adminstrator_ CASCADE CONSTRAINTS;
drop table Ratings_ CASCADE CONSTRAINTS;
drop table patient_ CASCADE CONSTRAINTS;
*/


create table users_(
user_id_ number(15) primary key,
email_ varchar2(100), 
password_ varchar2(100),
user_type_ varchar2(100),
unique (email_)
);
insert into  users_ values(1,'mohamed@gmail.com','mohamed123','doctor');
insert into  users_ values(2,'eslam@gmail.com','eslam123','doctor');
insert into  users_ values(3,'amr@gmail.com','amr123','doctor');
insert into  users_ values(4,'hassan@gmail.com','asd123','admin');
insert into  users_ values(5,'hamdy@gmail.com','hamdy123','admin');
insert into  users_ values(6,'essam@gmail.com','essam123','admin');
insert into  users_ values(7,'ashraf@gmail.com','ashraf123','patient');
insert into  users_ values(8,'antar@gmail.com','antar123','patient');
insert into  users_ values(9,'omar@gmail.com','omar123','patient');

----------------------------------------------------------------------------------------------------------------------


create table doctor_ (
doctor_id_ number(15) references users_ (user_id_) ,  
doctor_name_ varchar2(100),
phone_number_ varchar2(11) unique,
department_ varchar2(100),
work_start_time_ varchar2(100), 
work_end_time_ varchar2(100),
address_ varchar2(100),
weekend_ varchar2(100),
examination_cost_ number(15),

primary key (doctor_id_)
);
insert into doctor_ values (1, 'mohamed' ,'010265523', 'eyes' , '9' , '11',  'ain shams', 'friday',200);
insert into doctor_ values (2, 'eslam' ,'010265422', 'dentist' , '5' , '9', 'heliopolis', 'saturday sunday',300 );
insert into doctor_ values (3, 'amr' ,'0102655311', 'childern', '7', '8', 'alf maskan', 'saturday',400 );


----------------------------------------------------------------------------------------------------------------------


create table Adminstrator_(
admin_id_ number(15) references users_ (user_id_) ,
admin_name_ varchar2(100),
primary key (admin_id_)
);
insert into Adminstrator_ values(4,'hassan');
insert into Adminstrator_ values(5,'hamdy');
insert into Adminstrator_ values(6,'esam');


----------------------------------------------------------------------------------------------------------------------



create table  patient_ (
patient_id_ number(15) references users_ (user_id_)  , 
patient_name_ varchar2(100),
phone_number_ varchar2(11) unique,
information_ varchar2(100),
  primary key (patient_id_)
);
-- drop  table (nameoftable) cascade constraints;
-- delete from table where id = 1
insert into patient_ values (7 ,'ashraf','01064512352','bard');
insert into patient_ values (8 ,'antar','01405645123','ko7a' );
insert into patient_ values (9 ,'omar','01056453425','eshal' );


----------------------------------------------------------------------------------------------------------------------


create table medicine_
(
  admin_id_ number(15) references Adminstrator_ (admin_id_),
  medicine_name_ varchar2(100) unique,
  available_quantity_ number(15),
  cost_ number(15),
  primary key (medicine_name_, admin_id_)
);
insert into medicine_ values(4 , 'congestal', 4, 100);
insert into medicine_ values(5 , 'cetal', 20, 200);
insert into medicine_ values(6 , 'cometrex', 100, 26);


----------------------------------------------------------------------------------------------------------------------



create table cart_
(
  patient_id_ number(15)references patient_(patient_id_),
 medicine_name_ varchar2(100) references medicine_(medicine_name_),
  primary key (patient_id_ , medicine_name_)
);

insert into cart_ values(7,'congestal');
insert into cart_ values(8, 'cometrex');
insert into cart_ values(9, 'cetal');


----------------------------------------------------------------------------------------------------------------------



create table  Ratings_ (
patient_id_ number(15)  references patient_ (patient_id_) ,  
rate_ number(15),
doctor_id_ number(15) references doctor_(doctor_id_),
primary key (patient_id_ , doctor_id_)
);

INSERT INTO Ratings_ values (7 ,10,1  );
INSERT INTO Ratings_ values (8 ,8, 3 );
INSERT INTO Ratings_ values (9 ,3, 2 );
INSERT INTO Ratings_ values (7 ,3, 2 );


----------------------------------------------------------------------------------------------------------------------


create table booking_
(
 patient_id_ number(15) references patient_ (patient_id_), 
 doctor_id_ number(15) references doctor_(doctor_id_), 
 date_time_ DATE,
 examination_cost_ number(15) ,
 primary key (patient_id_ ,  doctor_id_)
);

insert into booking_ values (8 , 1 ,TO_DATE('2021/05/03 21:02:44', 'yyyy/mm/dd hh24:mi:ss'), 200);
insert into booking_ values (9 , 3 ,TO_DATE('2021/05/03 21:02:44', 'yyyy/mm/dd hh24:mi:ss'), 400);
insert into booking_ values (7 , 2 ,TO_DATE('2021/05/03 21:02:44', 'yyyy/mm/dd hh24:mi:ss'), 300);






/*--------------------------------------------- Procedures --------------------------------------------------*/
/*--------------------------------------------- Procedures --------------------------------------------------*/
/*--------------------------------------------- Procedures --------------------------------------------------*/
/*--------------------------------------------- Procedures --------------------------------------------------*/
/*--------------------------------------------- Procedures --------------------------------------------------*/





create or replace procedure retrieve_doctor_cost_ (doctor_id_ in number ,  ret out number)
as
begin
select examination_cost_ into ret from doctor_ where doctor_.doctor_id_ = doctor_id_;
end retrieve_doctor_cost_;


--------------------------------------------------------------------------------------------------------------------



create or replace procedure retrieve_medicine_name_( ret out sys_refcursor )
as
begin
open  ret for 
select medicine_name_ from medicine_;
end retrieve_medicine_name_;


----------------------------------------------------------------------------------------------------------------------


create or replace procedure GetMaxUserID_ (MID out number)
as
begin
select max(user_id_)
into MID
from Users_;
end;

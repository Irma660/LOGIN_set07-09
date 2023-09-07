Create database BDLOGIN
go
 use LOGINBD
 go 
 create table USUARIO
 (
 id_usuario varchar(4) primary key,
 nombre varchar,
 usuario varchar,
 contraseña varchar (8));
 insert into USUARIO values('1111','Paola Sanchez','Pao123','ert509ul')

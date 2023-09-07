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
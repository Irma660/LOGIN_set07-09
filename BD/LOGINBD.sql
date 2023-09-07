Create database BDLOGIN
go
 use LOGINBD
 go 
 create table USUARIO
 (
 id_usuario int primary key identity(1,1),
 nombre varchar not null,
 usuario varchar not null,
 contraseña varchar (8) not null);


 insert into USUARIO (nombre, usuario, contraseña)
 values('Paola Sanchez','Pao123','ert509ul')
 

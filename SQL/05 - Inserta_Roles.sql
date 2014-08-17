
-- Inserta Roles

USE SisRes;
INSERT  INTO dbo.GEN_Rol
        ( Rol, Descripcion )
VALUES  ( 'Administrador', 'Acceso a todos los módulos.' ) ,
        ( 'Recepcion', 'Acceso a reserva de habitaciones.' )
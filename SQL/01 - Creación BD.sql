USE master;
IF ( EXISTS ( SELECT    name
              FROM      master.dbo.sysdatabases
              WHERE     ( '[' + name + ']' = 'SisRes'
                          OR name = 'SisRes'
                        ) ) )
    BEGIN
        EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'SisRes'
        ALTER DATABASE SisRes
        SET  SINGLE_USER WITH ROLLBACK IMMEDIATE
        DROP DATABASE SisRes                      	
    END
GO

CREATE DATABASE SisRes
GO

USE SisRes;

/*==============================================================*/
/* Table: GEN_Clientes                                          */
/*==============================================================*/
CREATE TABLE GEN_Clientes
    (
      RUT INT NOT NULL ,
      DV CHAR(1) NOT NULL ,
      Nombres VARCHAR(30) NOT NULL ,
      ApPaterno VARCHAR(30) NOT NULL ,
      ApMaterno VARCHAR(30) NOT NULL ,
      Direccion VARCHAR(MAX) NULL ,
      Fono INT NULL ,
      Email VARCHAR(50) NULL ,
      IdTipoCliente INT NOT NULL ,
      Estado BIT NOT NULL ,
      CONSTRAINT PK_GEN_CLIENTES PRIMARY KEY ( RUT )
    )
go

/*==============================================================*/
/* Table: GEN_Rol                                               */
/*==============================================================*/
CREATE TABLE GEN_Rol
    (
      IdRol INT IDENTITY ,
      Rol VARCHAR(20) NOT NULL ,
      Descripcion VARCHAR(MAX) NULL ,
      CONSTRAINT PK_GEN_ROL PRIMARY KEY ( IdRol )
    )
go

/*==============================================================*/
/* Table: GEN_TipoCliente                                       */
/*==============================================================*/
CREATE TABLE GEN_TipoCliente
    (
      IdTipoCliente INT IDENTITY ,
      TipoCliente VARCHAR(30) NOT NULL ,
      Descripcion VARCHAR(MAX) NULL ,
      Descuento INT NOT NULL ,
      CONSTRAINT PK_GEN_TIPOCLIENTE PRIMARY KEY ( IdTipoCliente )
    )
go

/*==============================================================*/
/* Table: GEN_Usuarios                                          */
/*==============================================================*/
CREATE TABLE GEN_Usuarios
    (
      RUT INT NOT NULL ,
      DV CHAR(1) NOT NULL ,
      Nombres VARCHAR(30) NOT NULL ,
      ApPaterno VARCHAR(30) NOT NULL ,
      ApMaterno VARCHAR(30) NOT NULL ,
      Fono INT NULL ,
      Email VARCHAR(50) NULL ,
      IdRol INT NOT NULL ,
      Clave VARCHAR(20) NOT NULL ,
      Estado BIT NOT NULL ,
      CONSTRAINT PK_GEN_USUARIOS PRIMARY KEY ( RUT )
    )
go

/*==============================================================*/
/* Table: HAB_HabitacionImagenes                                */
/*==============================================================*/
CREATE TABLE HAB_HabitacionImagenes
    (
      IdHabitacion INT NOT NULL ,
      Imagen VARCHAR(MAX) NOT NULL
    )
go

/*==============================================================*/
/* Table: HAB_Habitaciones                                      */
/*==============================================================*/
CREATE TABLE HAB_Habitaciones
    (
      IdHabitacion INT IDENTITY ,
      IdTipoHabitacion INT NOT NULL ,
      Numero INT NOT NULL ,
      Observaciones VARCHAR(MAX) NULL ,
      Disponible BIT NOT NULL ,
      Reserva BIT NOT NULL ,
      CONSTRAINT PK_HAB_HABITACIONES PRIMARY KEY ( IdHabitacion )
    )
go

/*==============================================================*/
/* Table: HAB_TipoHabitacion                                    */
/*==============================================================*/
CREATE TABLE HAB_TipoHabitacion
    (
      IdTipoHabitacion INT IDENTITY ,
      TipoHabitacion VARCHAR(30) NOT NULL ,
      Descripcion VARCHAR(MAX) NULL ,
      Precio INT NOT NULL ,
      CONSTRAINT PK_HAB_TIPOHABITACION PRIMARY KEY ( IdTipoHabitacion )
    )
go

/*==============================================================*/
/* Table: RES_DetalleReserva                                    */
/*==============================================================*/
CREATE TABLE RES_DetalleReserva
    (
      IdReserva INT NOT NULL ,
      IdServicio INT NOT NULL ,
      Precio INT NOT NULL
    )
go

/*==============================================================*/
/* Table: RES_ReservaHabitacion                                 */
/*==============================================================*/
CREATE TABLE RES_ReservaHabitacion
    (
      IdReserva INT IDENTITY ,
      RUTUsuario INT NOT NULL ,
      RUTCliente INT NOT NULL ,
      IdHabitacion INT NOT NULL ,
      HoraFechaRes DATETIME NOT NULL ,
      DiasReserva INT NOT NULL ,
      Descuento INT NOT NULL ,
      CONSTRAINT PK_RES_RESERVAHABITACION PRIMARY KEY ( IdReserva )
    )
go

/*==============================================================*/
/* Table: SER_Servicios                                         */
/*==============================================================*/
CREATE TABLE SER_Servicios
    (
      IdServicio INT IDENTITY ,
      Servicio VARCHAR(30) NOT NULL ,
      Descripcion VARCHAR(MAX) NULL ,
      Precio INT NOT NULL ,
      CONSTRAINT PK_SER_SERVICIOS PRIMARY KEY ( IdServicio )
    )
go

ALTER TABLE GEN_Clientes
ADD CONSTRAINT FK_GEN_CLIE_REFERENCE_GEN_TIPO FOREIGN KEY (IdTipoCliente)
REFERENCES GEN_TipoCliente (IdTipoCliente)
go

ALTER TABLE GEN_USUARIOS
ADD CONSTRAINT FK_GEN_USUA_REFERENCE_GEN_ROL FOREIGN KEY (IdRol)
REFERENCES GEN_Rol (IdRol)
go

ALTER TABLE HAB_HabitacionImagenes
ADD CONSTRAINT FK_HAB_HABI_REFERENCE_HAB_HABI FOREIGN KEY (IdHabitacion)
REFERENCES HAB_Habitaciones (IdHabitacion)
go

ALTER TABLE HAB_Habitaciones
ADD CONSTRAINT FK_HAB_HABI_REFERENCE_HAB_TIPO FOREIGN KEY (IdTipoHabitacion)
REFERENCES HAB_TipoHabitacion (IdTipoHabitacion)
go

ALTER TABLE RES_DetalleReserva
ADD CONSTRAINT FK_RES_DETA_REFERENCE_SER_SERV FOREIGN KEY (IdServicio)
REFERENCES SER_Servicios (IdServicio)
go

ALTER TABLE RES_DetalleReserva
ADD CONSTRAINT FK_RES_DETA_REFERENCE_RES_RESE FOREIGN KEY (IdReserva)
REFERENCES RES_ReservaHabitacion (IdReserva)
go

ALTER TABLE RES_ReservaHabitacion
ADD CONSTRAINT FK_RES_RESE_REFERENCE_HAB_HABI FOREIGN KEY (IdHabitacion)
REFERENCES HAB_Habitaciones (IdHabitacion)
go

ALTER TABLE RES_ReservaHabitacion
ADD CONSTRAINT FK_RES_RESE_REF_RESER_GEN_CLIE FOREIGN KEY (RUTCliente)
REFERENCES GEN_Clientes (RUT)
go

ALTER TABLE RES_ReservaHabitacion
ADD CONSTRAINT FK_RES_RESE_REF_RESER_GEN_USUA FOREIGN KEY (RUTUsuario)
REFERENCES GEN_Usuarios (RUT)
go
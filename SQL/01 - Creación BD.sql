USE master;
IF ( EXISTS ( SELECT    name
              FROM      master.dbo.sysdatabases
              WHERE     ( '[' + name + ']' = 'SisRes'
                          OR name = 'SisRes'
                        ) ) )
    DROP DATABASE SisRes
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
/* Table: GEN_USUARIOS                                          */
/*==============================================================*/
CREATE TABLE GEN_USUARIOS
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
      IdHabitacion INT NOT NULL ,
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
      Precio MONEY NOT NULL ,
      CONSTRAINT PK_HAB_TIPOHABITACION PRIMARY KEY ( IdTipoHabitacion )
    )
go

/*==============================================================*/
/* Table: RES_DetalleReserva                                    */
/*==============================================================*/
CREATE TABLE RES_DetalleReserva
    (
      IdDetalleReserva INT NOT NULL ,
      IdServicio INT NULL ,
      Precio MONEY NULL ,
      CONSTRAINT PK_RES_DETALLERESERVA PRIMARY KEY ( IdDetalleReserva )
    )
go

/*==============================================================*/
/* Table: RES_ReservaHabitacion                                 */
/*==============================================================*/
CREATE TABLE RES_ReservaHabitacion
    (
      IdReserva INT NOT NULL ,
      RUTCliente INT NULL ,
      IdHabitacion INT NULL ,
      IdDetalleReserva INT NULL ,
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
      IdServicio INT NOT NULL ,
      Servicio VARCHAR(30) NOT NULL ,
      Descripcion VARCHAR(MAX) NULL ,
      Precio MONEY NOT NULL ,
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

ALTER TABLE RES_ReservaHabitacion
ADD CONSTRAINT FK_RES_RESE_REFERENCE_RES_DETA FOREIGN KEY (IdDetalleReserva)
REFERENCES RES_DetalleReserva (IdDetalleReserva)
go

ALTER TABLE RES_ReservaHabitacion
ADD CONSTRAINT FK_RES_RESE_REFERENCE_HAB_HABI FOREIGN KEY (IdHabitacion)
REFERENCES HAB_Habitaciones (IdHabitacion)
go

ALTER TABLE RES_ReservaHabitacion
ADD CONSTRAINT FK_RES_RESE_REF_RESER_GEN_CLIE FOREIGN KEY (RUTCliente)
REFERENCES GEN_Clientes (RUT)
go

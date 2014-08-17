
-- Inserta Servicios de habitación

USE SisRes;
INSERT INTO dbo.SER_Servicios
        ( Servicio ,
          Descripcion ,
          Precio
        )
VALUES  ( 'Frigobar' ,
          'Acceso a bebestibles.' ,
          15000
        ),
        ( 'TV' ,
          'Televisión con canales HD.' ,
          5000
        ),
        ( 'DVD' ,
          'Televisión más cartelera de películas.' ,
          7000
        ),
        ( 'Desayuno' ,
          'Servicio de desayuno entre 8:30 y 10:30' ,
          0
        )

-- Inserta Servicios de habitaci�n

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
          'Televisi�n con canales HD.' ,
          5000
        ),
        ( 'DVD' ,
          'Televisi�n m�s cartelera de pel�culas.' ,
          7000
        ),
        ( 'Desayuno' ,
          'Servicio de desayuno entre 8:30 y 10:30' ,
          0
        )

-- Inserta Tipo de Habitación

USE SisRes;
INSERT INTO dbo.HAB_TipoHabitacion
        ( TipoHabitacion ,
          Descripcion ,
          Precio
        )
VALUES  ( 'Simple' ,
          'Incluye una cama de 1 plaza.' ,
          20000
        ),
        ( 'Doble' ,
          'Incluye dos camas de 1 plaza.' ,
          30000
        ),
        ( 'Matrimonial' ,
          'Incluye una cama de 2 plazas.' ,
          40000
        )
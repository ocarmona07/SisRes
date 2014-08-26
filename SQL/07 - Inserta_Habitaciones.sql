
-- Inserta las habitaciones
USE SisRes;
INSERT INTO dbo.HAB_Habitaciones
        ( IdTipoHabitacion ,
          Numero ,
          Observaciones ,
          Disponible ,
          Reserva
        )
VALUES  ( 1 ,
          101 ,
          'Habitaci�n simple' ,
          1 ,
          0
        ),
        ( 1 ,
          102 ,
          'Habitaci�n simple con vista al centro' ,
          1 ,
          0
        ),
        ( 1 ,
          105 ,
          'Habitaci�n simple con vista al atardecer' ,
          1 ,
          0
        ),
        ( 2 ,
          103 ,
          'Habitaci�n doble' ,
          1 ,
          0
        ),
        ( 3 ,
          104 ,
          'Habitaci�n matrimonial' ,
          1 ,
          0
        ),
        ( 1 ,
          202 ,
          'Habitaci�n simple' ,
          1 ,
          0
        ),
        ( 1 ,
          204 ,
          'Habitaci�n simple con vista al centro' ,
          1 ,
          0
        ),
        ( 3 ,
          201 ,
          'Habitaci�n matrimonial' ,
          1 ,
          0
        ),
        ( 2 ,
          203 ,
          'Habitaci�n doble con vista al atardecer' ,
          1 ,
          0
        ),
        ( 2 ,
          205 ,
          'Habitaci�n doble' ,
          1 ,
          0
        ),
        ( 3 ,
          301 ,
          'Habitaci�n matrimonial' ,
          1 ,
          0
        ),
        ( 3 ,
          302 ,
          'Habitaci�n matrimonial con vista al centro' ,
          1 ,
          0
        )

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
          'Habitación simple' ,
          1 ,
          0
        ),
        ( 1 ,
          102 ,
          'Habitación simple con vista al centro' ,
          1 ,
          0
        ),
        ( 1 ,
          105 ,
          'Habitación simple con vista al atardecer' ,
          1 ,
          0
        ),
        ( 2 ,
          103 ,
          'Habitación doble' ,
          1 ,
          0
        ),
        ( 3 ,
          104 ,
          'Habitación matrimonial' ,
          1 ,
          0
        ),
        ( 1 ,
          202 ,
          'Habitación simple' ,
          1 ,
          0
        ),
        ( 1 ,
          204 ,
          'Habitación simple con vista al centro' ,
          1 ,
          0
        ),
        ( 3 ,
          201 ,
          'Habitación matrimonial' ,
          1 ,
          0
        ),
        ( 2 ,
          203 ,
          'Habitación doble con vista al atardecer' ,
          1 ,
          0
        ),
        ( 2 ,
          205 ,
          'Habitación doble' ,
          1 ,
          0
        ),
        ( 3 ,
          301 ,
          'Habitación matrimonial' ,
          1 ,
          0
        ),
        ( 3 ,
          302 ,
          'Habitación matrimonial con vista al centro' ,
          1 ,
          0
        )
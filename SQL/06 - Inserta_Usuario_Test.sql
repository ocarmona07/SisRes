-- Usuario Test

USE SisRes;
INSERT INTO dbo.GEN_Usuarios
        ( RUT ,
          DV ,
          Nombres ,
          ApPaterno ,
          ApMaterno ,
          Fono ,
          Email ,
          IdRol ,
          Clave ,
          Estado
        )
VALUES  ( 15988820 , -- RUT - int
          '7' , -- DV - char(1)
          'Omar Eduardo' , -- Nombres - varchar(30)
          'Carmona' , -- ApPaterno - varchar(30)
          'Rivas' , -- ApMaterno - varchar(30)
          82433600 , -- Fono - int
          'ocarmona07@gmail.com' , -- Email - varchar(50)
          1 , -- IdRol - int
          '123456' , -- Clave - varchar(20)
          1  -- Estado - bit
        )
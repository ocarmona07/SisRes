
-- Inserta Tipos de clientes

USE SisRes;
INSERT  INTO dbo.GEN_TipoCliente
        ( TipoCliente, Descripcion, Descuento )
VALUES  ( 'Espor�dico',
          'Cliente de visita',
          0
          ),
        ( 'Habitual',
          'Cliente frecuente',
          30
          )
CREATE VIEW mario_killers.AfiliadosParaCompra AS 
SELECT A.persona AS persona, A.grupo_familia AS grupo_familia, A.nro_familiar AS nro_familiar, P.apellido AS apellido, P.nombre AS nombre, P.documento AS documento, GF.plan_medico AS plan_medico, 
  P.direccion AS direccion, P.fecha_nac AS fecha_nac, P.mail AS mail, TD.id AS tipo_doc, P.sexo AS sexo, P.telefono AS telefono, A.cant_hijos AS cant_hijos, A.estado_civil AS estado_civil, A.activo AS activo
FROM mario_killers.Afiliado A JOIN mario_killers.Persona P ON A.persona = P.id
         JOIN mario_killers.Grupo_Familia GF ON A.grupo_familia = GF.codigo
         JOIN mario_killers.Tipo_Documento TD ON P.tipo_doc = TD.id
GO

CREATE VIEW mario_killers.BonoPorUsuario AS
SELECT a.grupo_familia
FROM mario_killers.Bono_Farmacia bf
	JOIN mario_killers.Compra c ON c.id = bf.compra
	JOIN mario_killers.Persona p ON p.id = c.persona
	JOIN mario_killers.Afiliado a ON a.persona = p.id
GO
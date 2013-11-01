CREATE VIEW mario_killers.AfiliadosABM AS 
SELECT A.grupo_familia AS grupo_familia, A.nro_familiar AS nro_familiar, P.apellido AS apellido, P.nombre AS nombre, P.documento AS documento, GF.plan_medico AS plan_medico
FROM mario_killers.Afiliado A JOIN mario_killers.Persona P ON A.persona = P.id
							  JOIN mario_killers.Grupo_Familia GF ON A.grupo_familia = GF.codigo
GO



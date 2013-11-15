CREATE VIEW mario_killers.BonoYcompra AS
SELECT c.id AS compra, c.fecha AS fecha, bf.codigo AS codigo, bf.plan_medico AS plan_medico, a.grupo_familia AS grupo
FROM mario_killers.Bono_Farmacia bf
	join mario_killers.Compra c on c.id = bf.compra
	join mario_killers.Afiliado a on a.persona = c.persona
GO


select * from mario_killers.BonoYcompra
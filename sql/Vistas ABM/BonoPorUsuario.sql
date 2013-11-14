CREATE VIEW mario_killers.BonoYcompra AS
SELECT c.id AS compra, c.fecha AS fecha, bf.codigo AS codigo, bf.plan_medico AS plan_medico
FROM mario_killers.Bono_Farmacia bf
	join mario_killers.Compra c on c.id = bf.compra
GO


select * from mario_killers.BonoYcompra
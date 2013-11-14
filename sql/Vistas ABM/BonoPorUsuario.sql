CREATE VIEW mario_killers.BonoPorUsuario AS
SELECT a.grupo_familia
FROM mario_killers.Bono_Farmacia bf
	JOIN mario_killers.Compra c ON c.id = bf.compra
	JOIN mario_killers.Persona p ON p.id = c.persona
	JOIN mario_killers.Afiliado a ON a.persona = p.id
GO
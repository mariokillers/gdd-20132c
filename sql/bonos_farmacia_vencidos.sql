SELECT TOP 5 Persona.nombre AS nombre, Persona.apellido AS apellido, COUNT(Bono_Farmacia.codigo) AS cantidad
FROM mario_killers.Bono_Farmacia
     JOIN mario_killers.Compra ON Bono_Farmacia.compra = Compra.id
     JOIN mario_killers.Afiliado ON Compra.persona = Afiliado.persona
     JOIN mario_killers.Persona ON Afiliado.persona = Persona.id
WHERE Compra.fecha + 60 < GETDATE() -- TODO: Usar fecha del sistema en vez de GETDATE
GROUP BY Persona.nombre, Persona.apellido
ORDER BY COUNT(Bono_Farmacia.codigo) DESC
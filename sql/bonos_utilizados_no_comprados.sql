SELECT (SELECT COUNT(Bono_Consulta.id)
FROM mario_killers.Bono_Consulta
     JOIN mario_killers.Compra ON Bono_Consulta.compra = Compra.id
     JOIN mario_killers.Turno ON Bono_Consulta.turno = Turno.id
WHERE Compra.persona <> Turno.persona)

+

(SELECT COUNT(Bono_Farmacia.codigo)
FROM mario_killers.Bono_Farmacia
     JOIN mario_killers.Compra ON Bono_Farmacia.compra = Compra.id
     JOIN mario_killers.Turno ON Bono_Farmacia.turno = Turno.id
WHERE Compra.persona <> Turno.persona)
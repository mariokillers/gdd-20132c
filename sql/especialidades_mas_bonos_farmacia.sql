SELECT TOP 5 Especialidad.descripcion AS especialidad, COUNT(Bono_Farmacia.codigo) AS cantidad
FROM mario_killers.Bono_Farmacia
     JOIN mario_killers.Turno ON Bono_Farmacia.turno = Turno.id
     JOIN mario_killers.Especialidad ON Turno.especialidad = Especialidad.codigo
GROUP BY Especialidad.descripcion
ORDER BY COUNT(Bono_Farmacia.codigo) DESC
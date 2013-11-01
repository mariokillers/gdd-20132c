SELECT TOP 5 Especialidad.descripcion 'Especialidad médica', COUNT(Bono_Farmacia.id) 'Bonos farmacia recetados'
FROM mario_killers.Bono_Farmacia
     JOIN mario_killers.Turno ON Bono_Farmacia.turno = Turno.id
     JOIN mario_killers.Especialidad ON Turno.especialidad = Especialidad.codigo
GROUP BY Especialidad.descripcion
ORDER BY COUNT(Bono_Farmacia.id) DESC
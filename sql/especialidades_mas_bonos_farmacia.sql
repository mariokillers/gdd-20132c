SELECT TOP 5 Especialidad.descripcion AS 'Especialidad', COUNT(DISTINCT bono_farmacia) AS 'Bonos recetados'
FROM mario_killers.Medicamento_HistoriaClinica
	JOIN mario_killers.Bono_Farmacia on Medicamento_HistoriaClinica.bono_farmacia = Bono_Farmacia.codigo
	JOIN mario_killers.Historia_Clinica ON Medicamento_HistoriaClinica.historia_clinica = Historia_Clinica.id
     JOIN mario_killers.Especialidad ON Historia_Clinica.especialidad = Especialidad.codigo
     JOIN mario_killers.Compra ON Bono_Farmacia.compra = Compra.id
WHERE Compra.fecha between @desde and @hasta     
GROUP BY Especialidad.descripcion
ORDER BY COUNT(DISTINCT bono_farmacia) DESC
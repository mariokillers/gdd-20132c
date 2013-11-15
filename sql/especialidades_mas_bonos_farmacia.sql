SELECT TOP 5 Especialidad.descripcion AS 'Especialidad', COUNT(DISTINCT bono_farmacia) AS 'Bonos recetados'
FROM mario_killers.Medicamento_HistoriaClinica
	JOIN mario_killers.Historia_Clinica ON Medicamento_HistoriaClinica.historia_clinica = Historia_Clinica.id
     JOIN mario_killers.Especialidad ON Historia_Clinica.especialidad = Especialidad.codigo
GROUP BY Especialidad.descripcion
ORDER BY COUNT(DISTINCT bono_farmacia) DESC
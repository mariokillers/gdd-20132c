SELECT (SELECT COUNT(Bono_Consulta.id)
FROM mario_killers.Bono_Consulta
     JOIN mario_killers.Compra ON Bono_Consulta.compra = Compra.id
     JOIN mario_killers.Turno ON Bono_Consulta.turno = Turno.id
WHERE Compra.persona <> Turno.persona) and Compra.fecha between @desde and @hasta)

+

(SELECT COUNT(Bono_Farmacia.codigo)
FROM mario_killers.Medicamento_HistoriaClinica
     JOIN mario_killers.Bono_Farmacia ON Medicamento_HistoriaClinica.bono_farmacia = Bono_Farmacia.codigo
     JOIN mario_killers.Compra ON Bono_Farmacia.compra = Compra.id
     JOIN mario_killers.Historia_Clinica ON Historia_Clinica.id = Medicamento_HistoriaClinica.historia_clinica
WHERE Compra.persona <> Historia_Clinica.afiliado) and Compra.fecha between @desde and @hasta)
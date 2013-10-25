-- Esto NO es parte de la entrega, solo es para testear el script

/*
ALTER TABLE mario_killers.Rango
	DROP CONSTRAINT max_horas_por_semana, horarios_validos
GO
ALTER TABLE mario_killers.Medicamento_Receta
	DROP CONSTRAINT max_3
GO
ALTER TABLE mario_killers.Agenda
	DROP CONSTRAINT max_120_dias, fechas_validas
GO
*/
ALTER TABLE mario_killers.Usuario
	DROP CONSTRAINT FK_Usuario_Persona;
DROP TABLE mario_killers.Agenda
DROP TABLE mario_killers.Bajas_Afiliado
DROP TABLE mario_killers.Bono_Consulta
DROP TABLE mario_killers.Bono_Farmacia
DROP TABLE mario_killers.Especialidad_Profesional
DROP TABLE mario_killers.Funcionalidad_Rol
DROP TABLE mario_killers.Compra
DROP TABLE mario_killers.Medicamento
DROP TABLE mario_killers.Medicamento_Receta
DROP TABLE mario_killers.Modificaciones_Grupo
DROP TABLE mario_killers.Receta
DROP TABLE mario_killers.Rango
DROP TABLE mario_killers.Roles_Usuario
DROP TABLE mario_killers.Sintoma
DROP TABLE mario_killers.Afiliado
DROP TABLE mario_killers.Estado_Civil
DROP TABLE mario_killers.Atencion
DROP TABLE mario_killers.Funcionalidad
DROP TABLE mario_killers.Grupo_Familia
DROP TABLE mario_killers.Plan_Medico
DROP TABLE mario_killers.Rol
DROP TABLE mario_killers.Turno
DROP TABLE mario_killers.Profesional
DROP TABLE mario_killers.Especialidad
DROP TABLE mario_killers.Tipo_Especialidad
DROP TABLE mario_killers.Persona
DROP TABLE mario_killers.Usuario
DROP TABLE mario_killers.Tipo_Documento

DROP FUNCTION mario_killers.horas_por_semana
DROP FUNCTION mario_killers.horas_se_pisan

DROP SCHEMA mario_killers
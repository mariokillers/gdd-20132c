-- Esto NO es parte de la entrega, solo es para testear el script
DROP TABLE
	mario_killers.Sintoma,
	mario_killers.Medicamento_Receta,
    mario_killers.Medicamento,
    mario_killers.Bono_Farmacia,
    mario_killers.Receta,
    mario_killers.Bono_Consulta,
    mario_killers.Atencion,
    mario_killers.Turno,
    mario_killers.Especialidad,
    mario_killers.Tipo_Especialidad,
    mario_killers.Especialidad_Profesional,
    mario_killers.Rango,
    mario_killers.Agenda,
    mario_killers.Profesional,
    mario_killers.Modificaciones_Grupo,
    mario_killers.Bajas_Afiliado,
    mario_killers.Afiliado,
    mario_killers.Grupo_Familia,
    mario_killers.Estado_Civil,
    mario_killers.Compra,
    mario_killers.Plan_Medico,
    mario_killers.Rol_Usuario,
    mario_killers.Funcionalidad_Rol,
    mario_killers.Funcionalidad,
    mario_killers.Rol,
    mario_killers.Usuario,
    mario_killers.Persona,
    mario_killers.Tipo_Documento
           
DROP FUNCTION mario_killers.horas_por_semana,
              mario_killers.horas_se_pisan,
              mario_killers.roles_usuario

DROP PROCEDURE mario_killers.agregar_funcionalidad

DROP SCHEMA mario_killers
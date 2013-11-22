-- Esto NO es parte de la entrega, solo es para testear el script
DROP VIEW mario_killers.AfiliadosABM, mario_killers.ProfesionalYPersona, mario_killers.ProfesionalABM, mario_killers.AfiliadosParaCompra, mario_killers.BonoYcompra, mario_killers.TurnosPorPaciente

DROP TABLE
	mario_killers.Cancelacion,
	mario_killers.Tipo_Cancelacion,
	mario_killers.Medicamento_Atencion,
	mario_killers.Bono_Farmacia,
    mario_killers.Bono_Consulta,
	mario_killers.Atencion,
    mario_killers.Medicamento,
    mario_killers.Turno,
    mario_killers.Especialidad_Profesional,
    mario_killers.Especialidad,
    mario_killers.Tipo_Especialidad,
    mario_killers.Rango,
    mario_killers.Agenda,
    mario_killers.Profesional,
    mario_killers.Modificaciones_Grupo,
    mario_killers.Bajas_Afiliado,
    mario_killers.Rol_Usuario,
    mario_killers.Funcionalidad_Rol,
    mario_killers.Funcionalidad,
    mario_killers.Rol,
    mario_killers.Usuario,
    mario_killers.Compra,
    mario_killers.Afiliado,
    mario_killers.Grupo_Familia,
    mario_killers.Estado_Civil,
    mario_killers.Plan_Medico,
    mario_killers.Persona,
    mario_killers.Tipo_Documento
           
DROP FUNCTION mario_killers.horas_por_semana,
              mario_killers.horas_se_pisan,
              mario_killers.horario_atencion,
              mario_killers.roles_usuario,
              mario_killers.cant_medicamentos,
              mario_killers.Turno_Valido,
              mario_killers.bono_farmacia_valido

DROP PROCEDURE mario_killers.agregar_funcionalidad,
               mario_killers.agregarPlanAlGrupo,
               mario_killers.agregarRol,
               mario_killers.agregarAfiliado,
               mario_killers.agregarAfiliadoFamilia,
               mario_killers.registrarCambioPlan,
               mario_killers.hacerCompra,
               mario_killers.agregarProfesional,
               mario_killers.modificarProfesional,
               mario_killers.verificarTurno,
               mario_killers.agregarTurno,
               mario_killers.agregarHClinica,
               mario_killers.anularDia,

               mario_killers.anularRango,

               mario_killers.listado_4

DROP VIEW mario_killers.listado_4_view


DROP SCHEMA mario_killers
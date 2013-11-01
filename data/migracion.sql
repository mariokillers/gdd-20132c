CREATE VIEW mario_killers.Pacientes AS
	SELECT DISTINCT Paciente_Nombre, Paciente_Apellido,
					Paciente_Dni, Paciente_Fecha_Nac,
					Paciente_Direccion, Paciente_Telefono, Paciente_Mail,
					Plan_Med_Codigo
	FROM gd_esquema.Maestra
	WHERE Paciente_Nombre IS NOT NULL
GO

CREATE VIEW mario_killers.Medicos AS
	SELECT DISTINCT Medico_Nombre, Medico_Apellido,
					Medico_Dni, Medico_Fecha_Nac,
					Medico_Direccion, Medico_Telefono, Medico_Mail
	FROM gd_esquema.Maestra
	WHERE Medico_Nombre IS NOT NULL
GO

CREATE VIEW mario_killers.Especialidades AS
	SELECT DISTINCT Especialidad_Codigo, Especialidad_Descripcion,
	                Tipo_Especialidad_Codigo, Tipo_Especialidad_Descripcion
	FROM gd_esquema.Maestra
	WHERE Especialidad_Codigo IS NOT NULL AND
	      Especialidad_Descripcion IS NOT NULL AND
	      Tipo_Especialidad_Codigo IS NOT NULL AND
	      Tipo_Especialidad_Descripcion IS NOT NULL
GO

CREATE VIEW mario_killers.Planes_Medicos AS
	SELECT DISTINCT Plan_Med_Codigo, Plan_Med_Descripcion,
	                Plan_Med_Precio_Bono_Consulta, Plan_Med_Precio_Bono_Farmacia
	FROM gd_esquema.Maestra
	WHERE Plan_Med_Codigo IS NOT NULL
GO

CREATE VIEW mario_killers.Medicamentos AS
	SELECT DISTINCT Bono_Farmacia_Medicamento
	FROM gd_esquema.Maestra
	WHERE Bono_Farmacia_Medicamento IS NOT NULL
GO

CREATE VIEW mario_killers.Medicamentos_Turno AS
	SELECT Bono_Farmacia_Medicamento, Turno_Numero
	FROM gd_esquema.Maestra
	WHERE Bono_Farmacia_Medicamento IS NOT NULL AND Turno_Numero IS NOT NULL
GO


CREATE VIEW mario_killers.Compras AS
	SELECT Compra_Bono_Fecha, Paciente_Dni, Plan_Med_Codigo
	FROM gd_esquema.Maestra
	WHERE Compra_Bono_Fecha IS NOT NULL
	      AND Plan_Med_Codigo IS NOT NULL
	GROUP BY Compra_Bono_Fecha, Paciente_Dni, Plan_Med_Codigo
GO

CREATE VIEW mario_killers.Bonos_Consulta AS
	SELECT DISTINCT Bono_Consulta_Numero,
	                MAX(Turno_Numero) AS Turno_Numero,
	                MAX(Compra_Bono_Fecha) AS Compra_Bono_Fecha,
	                Paciente_Dni
	FROM gd_esquema.Maestra
	WHERE Bono_Consulta_Numero IS NOT NULL
	GROUP BY Bono_Consulta_Numero, Paciente_Dni
GO

CREATE VIEW mario_killers.Turnos AS
	SELECT DISTINCT Turno_Numero, Paciente_Dni, Medico_Dni, Turno_Fecha, Especialidad_Codigo,
	                MAX(Consulta_Sintomas) Consulta_Sintomas,
	                MAX(Consulta_Enfermedades) Consulta_Enfermedades
	FROM gd_esquema.Maestra
	WHERE Turno_Numero IS NOT NULL
	GROUP BY Turno_Numero, Paciente_Dni, Medico_Dni, Turno_Fecha, Especialidad_Codigo
GO

CREATE VIEW mario_killers.Bonos_Farmacia AS
	SELECT DISTINCT Bono_Farmacia_Numero,
	                MAX(Compra_Bono_Fecha) Compra_Bono_Fecha,
	                MAX(Turno_Numero) AS Turno_Numero,
	                Paciente_Dni
	FROM gd_esquema.Maestra
	WHERE Bono_Farmacia_Numero IS NOT NULL
	GROUP BY Bono_Farmacia_Numero, Paciente_Dni
GO

-- Personas
SET IDENTITY_INSERT mario_killers.Persona ON
INSERT INTO mario_killers.Persona (id, nombre, apellido, documento, fecha_nac, direccion, telefono, mail)
	SELECT Paciente_Dni, Paciente_Nombre, Paciente_Apellido, Paciente_Dni,
	       Paciente_Fecha_Nac, Paciente_Direccion, Paciente_Telefono,
	       Paciente_Mail
	FROM mario_killers.Pacientes

INSERT INTO mario_killers.Persona (id, nombre, apellido, documento, fecha_nac, direccion, telefono, mail)
	SELECT Medico_Dni, Medico_Nombre, Medico_Apellido, Medico_Dni,
	       Medico_Fecha_Nac, Medico_Direccion, Medico_Telefono,
	       Medico_Mail
	FROM mario_killers.Medicos
SET IDENTITY_INSERT mario_killers.Persona OFF

-- Planes medicos
INSERT INTO mario_killers.Plan_Medico
           (codigo, descripcion, precio_bono_consulta, precio_bono_farmacia)
	SELECT Plan_Med_Codigo,
	       Plan_Med_Descripcion,
	       Plan_Med_Precio_Bono_Consulta,
	       Plan_Med_Precio_Bono_Farmacia
	FROM mario_killers.Planes_Medicos

-- Grupos de familia
INSERT INTO mario_killers.Grupo_Familia (codigo, plan_medico)
	SELECT Persona.id, Plan_Med_Codigo
	FROM mario_killers.Pacientes
	     JOIN mario_killers.Persona
	     ON mario_killers.Pacientes.Paciente_DNI = mario_killers.Persona.documento

-- Afiliados y grupos de familia individuales
INSERT INTO mario_killers.Afiliado (persona, grupo_familia, nro_familiar)
	SELECT id, id, 1
	FROM mario_killers.Persona
	WHERE documento IN (SELECT Paciente_Dni FROM mario_killers.Pacientes)

-- Especialidades
SET IDENTITY_INSERT mario_killers.Tipo_Especialidad ON
INSERT INTO mario_killers.Tipo_Especialidad (codigo, descripcion)
	SELECT DISTINCT Tipo_Especialidad_Codigo, Tipo_Especialidad_Descripcion
	FROM mario_killers.Especialidades
SET IDENTITY_INSERT mario_killers.Tipo_Especialidad OFF

SET IDENTITY_INSERT mario_killers.Especialidad ON
INSERT INTO mario_killers.Especialidad (codigo, descripcion, tipo)
	SELECT Especialidad_Codigo, Especialidad_Descripcion, Tipo_Especialidad_Codigo
	FROM mario_killers.Especialidades
SET IDENTITY_INSERT mario_killers.Especialidad OFF

-- Profesionales
INSERT INTO mario_killers.Profesional (persona)
	SELECT id
	FROM mario_killers.Persona
	WHERE documento IN (SELECT Medico_Dni FROM mario_killers.Medicos)
   
-- Medicamentos
INSERT INTO mario_killers.Medicamento (detalle)
	SELECT Bono_Farmacia_Medicamento FROM mario_killers.Medicamentos

-- Compras
INSERT INTO mario_killers.Compra (fecha, persona, plan_medico)
	SELECT Compra_Bono_Fecha, Paciente_Dni, Plan_Med_Codigo
	FROM mario_killers.Compras

-- Turnos
SET IDENTITY_INSERT mario_killers.Turno ON
INSERT INTO mario_killers.Turno (id, persona, profesional, horario, especialidad, sintomas, diagnostico)
	SELECT Turno_Numero, Paciente_Dni,
	       Medico_Dni, Turno_Fecha, Especialidad_Codigo,
	       Consulta_Sintomas, Consulta_Enfermedades
	FROM mario_killers.Turnos
SET IDENTITY_INSERT mario_killers.Turno OFF
GO

-- Bonos consulta
INSERT INTO mario_killers.Bono_Consulta (compra, turno, plan_medico)
	SELECT Compra.id, Bonos_Consulta.Turno_Numero, Compra.plan_medico
	FROM mario_killers.Bonos_Consulta
	     JOIN mario_killers.Compra
	     ON Compra.persona = Bonos_Consulta.Paciente_Dni
			AND Compra.fecha = Bonos_Consulta.Compra_Bono_Fecha

-- Bonos farmacia
INSERT INTO mario_killers.Bono_Farmacia (compra, plan_medico, turno)
	SELECT Compra.id, plan_medico, Bonos_Farmacia.Turno_Numero
	FROM mario_killers.Bonos_Farmacia
		JOIN mario_killers.Compra
		ON Compra.persona = Bonos_Farmacia.Paciente_Dni
			AND Compra.fecha = Bonos_Farmacia.Compra_Bono_Fecha

-- Medicamentos por turno
INSERT INTO mario_killers.Medicamento_Turno (medicamento, turno)
	SELECT Bono_Farmacia_Medicamento, Turno_Numero
	FROM mario_killers.Medicamentos_Turno

DROP VIEW mario_killers.Pacientes
         ,mario_killers.Medicos
         ,mario_killers.Especialidades
         ,mario_killers.Planes_Medicos
         ,mario_killers.Medicamentos
         ,mario_killers.Medicamentos_Turno
         ,mario_killers.Bonos_Consulta
         ,mario_killers.Turnos
         ,mario_killers.Compras
         ,mario_killers.Bonos_Farmacia

---------------------- Constraints post-migracion ----------------------

ALTER TABLE mario_killers.Turno WITH NOCHECK
	ADD CONSTRAINT fecha_turno CHECK (mario_killers.horario_atencion(horario) = 1)
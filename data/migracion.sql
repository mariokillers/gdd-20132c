-------------------------------------------------- MIGRACION --------------------------------

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

CREATE VIEW mario_killers.Medicamentos_Atencion AS
	SELECT Bono_Farmacia_Medicamento, Turno_Numero, Bono_Farmacia_Numero
	FROM gd_esquema.Maestra
	WHERE Bono_Farmacia_Medicamento IS NOT NULL AND Turno_Numero IS NOT NULL
GO


CREATE VIEW mario_killers.Compras AS
	SELECT Bono_Consulta_Numero AS id, Compra_Bono_Fecha, Paciente_Dni, Plan_Med_Codigo
	FROM gd_esquema.Maestra
	WHERE Compra_Bono_Fecha IS NOT NULL
	      AND Plan_Med_Codigo IS NOT NULL
	      AND Bono_Consulta_Numero IS NOT NULL
	      AND Bono_Farmacia_Numero IS NULL
	UNION
	SELECT Bono_Farmacia_Numero + 1000000 AS id, Compra_Bono_Fecha, Paciente_Dni, Plan_Med_Codigo
	FROM gd_esquema.Maestra
	WHERE Compra_Bono_Fecha IS NOT NULL
		AND Plan_Med_Codigo IS NOT NULL
		AND Bono_Farmacia_Numero IS NOT NULL
		AND Bono_Consulta_Numero IS NULL
GO

CREATE VIEW mario_killers.Bonos_Consulta AS
	SELECT DISTINCT Bono_Consulta_Numero,
	                MAX(Turno_Numero) AS Turno_Numero,
	                MAX(Compra_Bono_Fecha) AS Compra_Bono_Fecha,
	                Paciente_Dni,
	                Plan_Med_Codigo
	FROM gd_esquema.Maestra
	WHERE Bono_Consulta_Numero IS NOT NULL
	GROUP BY Bono_Consulta_Numero, Paciente_Dni, Plan_Med_Codigo
GO

CREATE VIEW mario_killers.Turnos AS
	SELECT DISTINCT Turno_Numero, Paciente_Dni, Medico_Dni, Turno_Fecha, Especialidad_Codigo,
	                MAX(Consulta_Sintomas) Consulta_Sintomas,
	                MAX(Consulta_Enfermedades) Consulta_Enfermedades,
	                mario_killers.Turno_Valido(Turno_Fecha) AS Turno_Activo
	FROM gd_esquema.Maestra
	WHERE Turno_Numero IS NOT NULL
	GROUP BY Turno_Numero, Paciente_Dni, Medico_Dni, Turno_Fecha, Especialidad_Codigo, Plan_Med_Codigo
GO

CREATE VIEW mario_killers.Bonos_Farmacia AS
	SELECT DISTINCT Bono_Farmacia_Numero,
	                MAX(Compra_Bono_Fecha) Compra_Bono_Fecha,
	                Bono_Farmacia_Fecha_Vencimiento,
	                Bono_Farmacia_Medicamento,
	                MAX(Turno_Numero) AS Turno_Numero,
	                Paciente_Dni,
	                Plan_Med_Codigo,
	                mario_killers.bono_farmacia_valido(Compra_Bono_Fecha, Bono_Farmacia_Fecha_Vencimiento, Bono_Farmacia_Medicamento) AS valido
	FROM gd_esquema.Maestra
	WHERE Bono_Farmacia_Numero IS NOT NULL AND Compra_Bono_Fecha IS NOT NULL
	GROUP BY Bono_Farmacia_Numero, Paciente_Dni, Bono_Farmacia_Fecha_Vencimiento, Bono_Farmacia_Medicamento, Compra_Bono_Fecha, Plan_Med_Codigo
GO

CREATE VIEW mario_killers.Especialidades_Profesional AS
	SELECT DISTINCT Medico_Dni, Especialidad_Codigo
	FROM gd_esquema.Maestra
	WHERE Medico_Dni IS NOT NULL
	      AND Especialidad_Codigo IS NOT NULL
GO

CREATE VIEW mario_killers.Usuarios AS
	SELECT DISTINCT CONVERT(VARCHAR(255), Medico_Dni) AS nombre, Medico_Dni AS persona, '24afe47d0bd302ae42643c5848d99b683264026cd12cc998e05e100bbf2dc30d' AS pw, 2 AS rol
	FROM gd_esquema.Maestra
	WHERE Medico_Dni IS NOT NULL
	UNION 
	SELECT DISTINCT CONVERT(VARCHAR(255), Paciente_Dni) AS nombre, Paciente_Dni AS persona, '1aeaeba4bdbf8907638434b60504b1037c01905bec294fb2cd5348724f2fa64f' AS pw, 3 AS rol
	FROM gd_esquema.Maestra
	WHERE Paciente_Dni IS NOT NULL
GO

-- Personas
SET IDENTITY_INSERT mario_killers.Persona ON
INSERT INTO mario_killers.Persona (id, nombre, apellido, documento, fecha_nac, direccion, telefono, mail, sexo, tipo_doc)
	SELECT Paciente_Dni, Paciente_Nombre, Paciente_Apellido, Paciente_Dni,
	       Paciente_Fecha_Nac, Paciente_Direccion, Paciente_Telefono,
	       Paciente_Mail, 'X', 5
	FROM mario_killers.Pacientes

INSERT INTO mario_killers.Persona (id, nombre, apellido, documento, fecha_nac, direccion, telefono, mail, sexo, tipo_doc)
	SELECT Medico_Dni, Medico_Nombre, Medico_Apellido, Medico_Dni,
	       Medico_Fecha_Nac, Medico_Direccion, Medico_Telefono,
	       Medico_Mail, 'X', 5
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
SET IDENTITY_INSERT mario_killers.Grupo_Familia ON
INSERT INTO mario_killers.Grupo_Familia (codigo, plan_medico)
	SELECT Persona.id, Plan_Med_Codigo
	FROM mario_killers.Pacientes
	     JOIN mario_killers.Persona
	     ON mario_killers.Pacientes.Paciente_DNI = mario_killers.Persona.documento
SET IDENTITY_INSERT mario_killers.Grupo_Familia OFF  

-- Afiliados y grupos de familia individuales
INSERT INTO mario_killers.Afiliado (persona, grupo_familia, nro_familiar, estado_civil, cant_hijos)
	SELECT id, id, 1, 6, 0
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

INSERT INTO mario_killers.Especialidad_Profesional (profesional, especialidad)
	SELECT Medico_Dni, Especialidad_Codigo
	FROM mario_killers.Especialidades_Profesional

-- Medicamentos
INSERT INTO mario_killers.Medicamento (detalle)
	SELECT Bono_Farmacia_Medicamento FROM mario_killers.Medicamentos

-- Turnos
SET IDENTITY_INSERT mario_killers.Turno ON
INSERT INTO mario_killers.Turno (id, persona, profesional, horario, especialidad, activo)
	SELECT Turno_Numero, Paciente_Dni,
	       Medico_Dni, Turno_Fecha, Especialidad_Codigo,
	       Turno_Activo
	FROM mario_killers.Turnos
SET IDENTITY_INSERT mario_killers.Turno OFF
GO

-- Historia clinica
-- Inicialmente los ID de historia clinica son los numeros de turno
INSERT INTO mario_killers.Atencion (id, horario_atencion, sintomas, diagnostico)
	SELECT Turno_Numero, Turno_Fecha, Consulta_Sintomas, Consulta_Enfermedades
	FROM mario_killers.Turnos

-- Compras
SET IDENTITY_INSERT mario_killers.Compra ON
INSERT INTO mario_killers.Compra (id, fecha, persona, plan_medico)
	SELECT id, Compra_Bono_Fecha, Paciente_Dni, Plan_Med_Codigo
	FROM mario_killers.Compras
SET IDENTITY_INSERT mario_killers.Compra OFF

-- Bonos consulta
INSERT INTO mario_killers.Bono_Consulta (compra, plan_medico)
	SELECT Bono_Consulta_Numero, Plan_Med_Codigo
	FROM mario_killers.Bonos_Consulta

-- Bonos farmacia
SET IDENTITY_INSERT mario_killers.Bono_Farmacia ON
INSERT INTO mario_killers.Bono_Farmacia (codigo, compra, plan_medico,  activo)
	SELECT Bono_Farmacia_Numero, Bono_Farmacia_Numero + 1000000, Plan_Med_Codigo, valido
	FROM mario_killers.Bonos_Farmacia
SET IDENTITY_INSERT mario_killers.Bono_Farmacia OFF

-- Medicamentos por turno
-- Inicialmente los ID de historia clinica son los numeros de turno
INSERT INTO mario_killers.Medicamento_Atencion (medicamento, atencion, bono_farmacia)
	SELECT Bono_Farmacia_Medicamento, Turno_Numero, Bono_Farmacia_Numero
	FROM mario_killers.Medicamentos_Atencion

--Usuarios
INSERT INTO mario_killers.Usuario (nombre, persona, pw)
	SELECT nombre, persona, pw
	FROM mario_killers.Usuarios
GO
	
--Rol por usuario
INSERT INTO mario_killers.Rol_Usuario (usuario, rol)
	SELECT nombre, rol
	FROM mario_killers.Usuarios
GO

DROP VIEW mario_killers.Pacientes
         ,mario_killers.Medicos
         ,mario_killers.Especialidades
         ,mario_killers.Planes_Medicos
         ,mario_killers.Medicamentos
         ,mario_killers.Medicamentos_Atencion
         ,mario_killers.Bonos_Consulta
         ,mario_killers.Turnos
         ,mario_killers.Compras
         ,mario_killers.Bonos_Farmacia
         ,mario_killers.Especialidades_Profesional
         ,mario_killers.Usuarios

---------------------- Constraints post-migracion ----------------------

ALTER TABLE mario_killers.Turno WITH NOCHECK
	ADD CONSTRAINT fecha_turno CHECK (mario_killers.horario_atencion(horario) = 1)
	
ALTER TABLE mario_killers.Medicamento_Atencion WITH NOCHECK
	ADD CONSTRAINT max_5_receta CHECK ( mario_killers.cant_medicamentos(Atencion) <= 5)
	
ALTER TABLE mario_killers.Turno WITH NOCHECK
	ADD CONSTRAINT horario_valido CHECK (mario_killers.Turno_Valido(horario) = 1)


------ Administrador General (admin) y un Administrativo	
INSERT INTO mario_killers.Usuario (nombre, pw)
	VALUES ('admin', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7'),
		   ('administrador', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7');
	GO

INSERT INTO mario_killers.Rol_Usuario
	VALUES ('admin', 1),
	       ('administrador', 4)	       	       
GO
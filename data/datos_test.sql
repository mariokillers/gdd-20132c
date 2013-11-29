-- Usuarios de prueba
INSERT INTO mario_killers.Usuario (nombre, pw)
VALUES ('cormillot', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7'),
	   ('tomi', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7');

INSERT INTO mario_killers.Rol_Usuario (usuario, rol)
VALUES ('cormillot', 2),
	   ('tomi', 3);

INSERT mario_killers.Profesional (persona)
	SELECT id FROM mario_killers.Persona WHERE documento = 11111111
GO
INSERT mario_killers.Plan_Medico (codigo, descripcion, precio_bono_consulta, precio_bono_farmacia)
	VALUES (1, 'PLAN FRUTA', 10, 10)
	
SET IDENTITY_INSERT mario_killers.Grupo_Familia ON
INSERT mario_killers.Grupo_Familia (codigo, plan_medico)
	SELECT id, 1 FROM mario_killers.Persona WHERE documento = 11111111
SET IDENTITY_INSERT mario_killers.Grupo_Familia OFF

INSERT mario_killers.Afiliado (persona, grupo_familia, nro_familiar, cant_hijos, estado_civil)
	SELECT id, id, 1, 0, 6 from mario_killers.Persona WHERE documento = 11111111
GO

SET IDENTITY_INSERT mario_killers.Tipo_Especialidad ON
INSERT mario_killers.Tipo_Especialidad(codigo, descripcion) VALUES (1, 'Tipo Fruta')
SET IDENTITY_INSERT mario_killers.Tipo_Especialidad OFF
GO

SET IDENTITY_INSERT mario_killers.Especialidad ON
INSERT mario_killers.Especialidad(codigo, descripcion, tipo) VALUES (1, 'Especial Fruta', 1)
SET IDENTITY_INSERT mario_killers.Especialidad OFF
GO

INSERT mario_killers.Especialidad_Profesional (profesional, especialidad) VALUES (1, 1)
GO

SET IDENTITY_INSERT mario_killers.Rango ON
INSERT INTO mario_killers.Rango (id, dia, profesional, hora_desde, hora_hasta, especialidad) VALUES (1, 2, 1, '7:00', '10:00', 1)
INSERT INTO mario_killers.Rango (id, dia, profesional, hora_desde, hora_hasta, especialidad) VALUES (2, 2, 1, '15:00', '18:00', 1)
INSERT INTO mario_killers.Rango (id, dia, profesional, hora_desde, hora_hasta, especialidad) VALUES (3, 3, 1, '7:00', '10:00', 1)
INSERT INTO mario_killers.Rango (id, dia, profesional, hora_desde, hora_hasta, especialidad) VALUES (5, 3, 1, '14:00', '17:00', 1)
INSERT INTO mario_killers.Rango (id, dia, profesional, hora_desde, hora_hasta, especialidad) VALUES (4, 4, 1, '15:00', '18:00', 1)
SET IDENTITY_INSERT mario_killers.Rango OFF
GO

INSERT INTO mario_killers.Agenda (profesional, desde, hasta) VALUES (1, '01/01/2014', '04/01/2014')
GO

SET IDENTITY_INSERT mario_killers.Turno ON
--INSERT INTO mario_killers.Turno (id, persona, profesional, horario, especialidad, activo) VALUES (1, 1, 1,GETDATE(), 1, 1)
SET IDENTITY_INSERT mario_killers.Turno OFF
GO

SET IDENTITY_INSERT mario_killers.Compra ON
INSERT INTO mario_killers.Compra (id, persona, plan_medico, fecha) VALUES (1, 1, 1, GETDATE())
SET IDENTITY_INSERT mario_killers.Compra OFF

SET IDENTITY_INSERT mario_killers.Bono_Farmacia ON
INSERT INTO mario_killers.Bono_Farmacia (codigo, compra, plan_medico) VALUES (1, 1, 1)
SET IDENTITY_INSERT mario_killers.Bono_Farmacia OFF
GO

SET IDENTITY_INSERT mario_killers.Bono_Consulta ON
INSERT INTO mario_killers.Bono_Consulta(id, compra, plan_medico) VALUES (1, 1, 1)
SET IDENTITY_INSERT mario_killers.Bono_Consulta OFF
GO

INSERT INTO mario_killers.Medicamento (detalle) VALUES ('VIAGRA POTENCIA MAXIMA')
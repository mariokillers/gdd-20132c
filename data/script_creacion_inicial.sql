CREATE SCHEMA mario_killers AUTHORIZATION gd
GO

CREATE FUNCTION mario_killers.horario_atencion(@hora datetime) returns int
AS BEGIN
	DECLARE @result int
	SET @result = CASE
		WHEN DATEPART(DW, @hora) BETWEEN 2 AND 6
		     AND CONVERT(TIME, @hora) BETWEEN '07:00:00' AND '20:00:00'
		THEN 1
		WHEN DATEPART(DW, @hora) = 7
		     AND CONVERT(TIME, @hora) BETWEEN '10:00:00' AND '15:00:00'
		THEN 1
		ELSE 0
	END
	RETURN @result
END
GO

CREATE FUNCTION mario_killers.horas_por_semana(@profesional int) RETURNS int AS
BEGIN
	RETURN (SELECT SUM(DATEDIFF(HOUR, hora_desde, hora_hasta))
	FROM mario_killers.Rango
	WHERE Rango.profesional = @profesional)
END
GO

CREATE FUNCTION mario_killers.horas_se_pisan(@profesional int) RETURNS bit AS
BEGIN
	RETURN (
		SELECT COUNT(1)
		FROM mario_killers.Rango r1 JOIN mario_killers.Rango r2 ON r1.dia = r2.dia
		WHERE r1.hora_desde <= r2.hora_hasta AND r2.hora_desde <= r1.hora_hasta
		      AND r1.id <> r2.id
	)
END
GO

CREATE PROCEDURE mario_killers.agregar_funcionalidad(@rol varchar(255), @func varchar(255)) AS
BEGIN
	INSERT INTO mario_killers.Funcionalidad_Rol (rol, funcionalidad)
		VALUES ((SELECT id FROM mario_killers.Rol WHERE nombre = @rol),
		        (SELECT id FROM mario_killers.Funcionalidad WHERE nombre = @func))
END
GO

CREATE TABLE mario_killers.Tipo_Documento (
	id int IDENTITY,
	tipo varchar(10) NOT NULL,
	PRIMARY KEY (id)
)

CREATE TABLE mario_killers.Persona (
	id int IDENTITY,
	nombre varchar(255) NOT NULL,
	apellido varchar(255) NOT NULL,
	documento numeric(18, 0) NOT NULL,
	fecha_nac datetime NOT NULL,
	direccion varchar(255) NOT NULL,
	telefono numeric(18, 0) NOT NULL,
	mail varchar(255) NOT NULL,

    -- Campos faltantes
	tipo_doc int,
	sexo char(1),
	
	PRIMARY KEY (id),
	FOREIGN KEY (tipo_doc) REFERENCES mario_killers.Tipo_Documento(id),
	UNIQUE (tipo_doc, documento)
)

CREATE TABLE mario_killers.Usuario (
	nombre varchar(255),
	persona int,
	pw char(64) NOT NULL, -- SHA256
	intentos_login int NOT NULL
		CONSTRAINT "intentos_login_0" DEFAULT 0,
	activo bit NOT NULL
		CONSTRAINT "usuario_activo" DEFAULT 1,
	PRIMARY KEY (nombre),
	FOREIGN KEY (persona) REFERENCES mario_killers.Persona(id),
)

CREATE TABLE mario_killers.Rol (
	id int IDENTITY,
	nombre varchar(255) NOT NULL,
	activo bit NOT NULL
		CONSTRAINT rol_activo DEFAULT 1,
	PRIMARY KEY (id)
)

CREATE TABLE mario_killers.Funcionalidad (
	id int IDENTITY,
	nombre varchar(255) NOT NULL,
	PRIMARY KEY (id)
)

CREATE TABLE mario_killers.Funcionalidad_Rol (
	rol int NOT NULL,
	funcionalidad int NOT NULL,
	FOREIGN KEY (rol) REFERENCES mario_killers.Rol(id),
	FOREIGN KEY (funcionalidad) REFERENCES mario_killers.Funcionalidad(id)
)

CREATE TABLE mario_killers.Rol_Usuario (
	usuario varchar(255),
	rol int,
	FOREIGN KEY (usuario) REFERENCES mario_killers.Usuario(nombre),
	FOREIGN KEY (rol) REFERENCES mario_killers.Rol(id),
	PRIMARY KEY (usuario, rol)
)

CREATE TABLE mario_killers.Plan_Medico (
	codigo numeric(18, 0),
	descripcion varchar(255) NOT NULL,
	precio_bono_consulta numeric(18, 0) NOT NULL,
	precio_bono_farmacia numeric(18, 0) NOT NULL,
	PRIMARY KEY (codigo)
)

CREATE TABLE mario_killers.Compra (
	id int IDENTITY,
	fecha datetime,
	persona int,
	plan_medico numeric(18, 0) NOT NULL,
	PRIMARY KEY (id),
	FOREIGN KEY (plan_medico) REFERENCES mario_killers.Plan_Medico(codigo)
)

CREATE TABLE mario_killers.Estado_Civil (
	id int IDENTITY,
	estado varchar(255) NOT NULL,
	PRIMARY KEY (id)
)

CREATE TABLE mario_killers.Grupo_Familia (
	codigo numeric(18, 0),
	plan_medico numeric(18, 0) NOT NULL,
	PRIMARY KEY (codigo),
	FOREIGN KEY (plan_medico) REFERENCES mario_killers.Plan_Medico(codigo)
)

CREATE TABLE mario_killers.Afiliado (
	-- Cantidad de consultas se calcula
	persona int,
	estado_civil int,
	grupo_familia numeric(18,0) NOT NULL,
	nro_familiar int NOT NULL,
	cant_hijos int,
	activo bit NOT NULL
		CONSTRAINT afiliado_activo DEFAULT 1,
	PRIMARY KEY (persona),
	UNIQUE (grupo_familia, nro_familiar),
	FOREIGN KEY (persona) REFERENCES mario_killers.Persona(id),
	FOREIGN KEY (estado_civil) REFERENCES mario_killers.Estado_Civil(id),
	FOREIGN KEY (grupo_familia) REFERENCES mario_killers.Grupo_Familia(codigo)
)

CREATE TABLE mario_killers.Bajas_Afiliado (
	persona int NOT NULL,
	fecha datetime NOT NULL,
	FOREIGN KEY (persona) REFERENCES mario_killers.Afiliado(persona)
)


CREATE TABLE mario_killers.Modificaciones_Grupo (
	grupo_familia numeric(18, 0) NOT NULL,
	plan_medico numeric(18, 0) NOT NULL,
	fecha datetime NOT NULL,
	motivo varchar(255) NOT NULL,
	FOREIGN KEY (grupo_familia) REFERENCES mario_killers.Grupo_Familia(codigo),
	FOREIGN KEY (plan_medico) REFERENCES mario_killers.Plan_medico(codigo)
)

CREATE TABLE mario_killers.Profesional (
	persona int,
	matricula int,
	activo bit NOT NULL
		CONSTRAINT profesional_activo DEFAULT 1,
	PRIMARY KEY (persona),
	FOREIGN KEY (persona) REFERENCES mario_killers.Persona(id)
	-- UNIQUE (matricula)
)

CREATE TABLE mario_killers.Agenda (
	profesional int NOT NULL,
	desde date NOT NULL,
	hasta date NOT NULL,
	PRIMARY KEY (profesional),
	CONSTRAINT max_120_dias CHECK (DATEDIFF(day, desde, hasta) <= 120),
	CONSTRAINT fechas_validas CHECK (desde < hasta),
	FOREIGN KEY (profesional) REFERENCES mario_killers.Profesional(persona)
)

CREATE TABLE mario_killers.Rango (
	id int IDENTITY,
	dia int NOT NULL, -- domingo = 1, valor default de DATEFIRST
	profesional int NOT NULL,
	hora_desde time NOT NULL,
	hora_hasta time NOT NULL,
	PRIMARY KEY (id),
	CONSTRAINT horarios_validos CHECK (
	mario_killers.horario_atencion(CONVERT(TIME,hora_desde)) = 1 AND
	mario_killers.horario_atencion(CONVERT(TIME,hora_hasta)) = 1 AND
	hora_desde < hora_hasta
	),
	CONSTRAINT max_horas_por_semana CHECK (mario_killers.horas_por_semana(profesional) <= 48),
	CONSTRAINT horas_no_se_pisan CHECK (mario_killers.horas_se_pisan(profesional) = 0),
	FOREIGN KEY (profesional) REFERENCES mario_killers.Profesional(persona)
)

CREATE TABLE mario_killers.Especialidad_Profesional (
	profesional int,
	especialidad int,
	PRIMARY KEY (profesional, especialidad)
)

CREATE TABLE mario_killers.Tipo_Especialidad (
	codigo numeric(18, 0) IDENTITY,
	descripcion varchar(255) NOT NULL,
	PRIMARY KEY (codigo)
)

CREATE TABLE mario_killers.Especialidad (
	codigo numeric(18, 0) IDENTITY,
	descripcion varchar(255) NOT NULL,
	tipo numeric(18, 0) NOT NULL,
	PRIMARY KEY (codigo),
	FOREIGN KEY (tipo) REFERENCES mario_killers.Tipo_Especialidad(codigo)
)

CREATE TABLE mario_killers.Turno (
	id int IDENTITY,
	persona int NOT NULL,
	profesional int NOT NULL,
	horario datetime NOT NULL,
	especialidad numeric(18, 0) NOT NULL,
	activo bit
		CONSTRAINT turno_activo DEFAULT 1,
	horario_llegada datetime,
	sintomas text,
	diagnostico text,
	PRIMARY KEY (id),
	FOREIGN KEY (persona) REFERENCES mario_killers.Persona(id),
	FOREIGN KEY (profesional) REFERENCES mario_killers.Profesional(persona),
	FOREIGN KEY (especialidad) REFERENCES mario_killers.Especialidad(codigo)
)

CREATE TABLE mario_killers.Bono_Consulta (
	id int IDENTITY,
	compra int,
	turno int,
	plan_medico numeric(18, 0),
	PRIMARY KEY (id),
	FOREIGN KEY (plan_medico) REFERENCES mario_killers.Plan_Medico(codigo),
	FOREIGN KEY (compra) REFERENCES mario_killers.Compra(id),
	FOREIGN KEY (turno) REFERENCES mario_killers.Turno(id)
)

CREATE TABLE mario_killers.Receta (
	id int IDENTITY,
	turno int,
	activo bit
		CONSTRAINT receta_activa DEFAULT 1,
	PRIMARY KEY (id),
	FOREIGN KEY (turno) REFERENCES mario_killers.Turno(id)
)

CREATE TABLE mario_killers.Bono_Farmacia (
	id int IDENTITY,
	compra int,
	receta int,
	plan_medico numeric(18, 0),
	PRIMARY KEY (id),
	FOREIGN KEY (plan_medico) REFERENCES mario_killers.Plan_Medico(codigo),
	FOREIGN KEY (compra) REFERENCES mario_killers.Compra(id),
	FOREIGN KEY (receta) REFERENCES mario_killers.Receta(id)
)

CREATE TABLE mario_killers.Medicamento (
	id int IDENTITY,
	detalle varchar(255) NOT NULL,
	PRIMARY KEY (id)
)

CREATE TABLE mario_killers.Medicamento_Receta (
	medicamento int,
	receta int,
	cantidad int,
	PRIMARY KEY (medicamento, receta),
	FOREIGN KEY (medicamento) REFERENCES mario_killers.Medicamento(id),
	FOREIGN KEY (receta) REFERENCES mario_killers.Receta(id),
	CONSTRAINT max_3 CHECK (cantidad <= 3)
)

--------------------------------- DATOS INICIALES -----------------------------

INSERT INTO mario_killers.Estado_Civil (estado)
	VALUES ('Soltero/a'),
	       ('Casado/a'),
	       ('Viudo/a'),
	       ('Concubinato'),
	       ('Divorciado/a');

INSERT INTO mario_killers.Tipo_Documento (tipo)
	VALUES ('DNI'), ('CI'), ('LC'), ('LE');

INSERT INTO mario_killers.Rol (nombre)
	VALUES ('Administrativo'),
	       ('Profesional'),
	       ('Afiliado');
	       
INSERT INTO mario_killers.Funcionalidad (nombre)
	VALUES ('Administrar roles'),
	       ('Ver afiliados'),
	       ('Administrar afiliados'),
	       ('Ver profesionales'),
	       ('Administrar profesionales'),
	       ('Consultar listado estadístico'),
	       ('Registrar llegada'),
	       ('Registrar agenda'),
	       ('Registrar diagnóstico'),
	       ('Cancelar atención médica'),
	       ('Crear receta médica'),
	       ('Comprar bonos'),
	       ('Ver turnos'),
	       ('Pedir turno');

EXEC mario_killers.agregar_funcionalidad
	@rol = 'Administrativo', @func = 'Administrar roles';
EXEC mario_killers.agregar_funcionalidad
	@rol = 'Administrativo', @func = 'Ver afiliados';
EXEC mario_killers.agregar_funcionalidad
	@rol = 'Administrativo', @func = 'Administrar afiliados';
EXEC mario_killers.agregar_funcionalidad
	@rol = 'Administrativo', @func = 'Ver profesionales';
EXEC mario_killers.agregar_funcionalidad
	@rol = 'Administrativo', @func = 'Administrar profesionales';
EXEC mario_killers.agregar_funcionalidad
	@rol = 'Administrativo', @func = 'Consultar listado estadístico';
EXEC mario_killers.agregar_funcionalidad
	@rol = 'Administrativo', @func = 'Registrar llegada';
EXEC mario_killers.agregar_funcionalidad
	@rol = 'Administrativo', @func = 'Ver turnos';
EXEC mario_killers.agregar_funcionalidad
	@rol = 'Profesional', @func = 'Ver turnos';
EXEC mario_killers.agregar_funcionalidad
	@rol = 'Profesional', @func = 'Registrar agenda';
EXEC mario_killers.agregar_funcionalidad
	@rol = 'Profesional', @func = 'Registrar diagnóstico';
EXEC mario_killers.agregar_funcionalidad
	@rol = 'Profesional', @func = 'Cancelar atención médica';
EXEC mario_killers.agregar_funcionalidad
	@rol = 'Profesional', @func = 'Crear receta médica';
EXEC mario_killers.agregar_funcionalidad
	@rol = 'Afiliado', @func = 'Comprar bonos';
EXEC mario_killers.agregar_funcionalidad
	@rol = 'Afiliado', @func = 'Pedir turno';
	
INSERT INTO mario_killers.Usuario (nombre, pw)
	VALUES ('admin', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7'),
	       ('cormillot', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7'),
	       ('tomi', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7');

INSERT INTO mario_killers.Rol_Usuario
	VALUES ('admin', 1),
	       ('admin', 2),
	       ('admin', 3),
	       ('cormillot', 2),
	       ('tomi', 3);
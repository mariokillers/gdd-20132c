CREATE SCHEMA mario_killers AUTHORIZATION gd
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

CREATE TABLE mario_killers.Tipo_Documento (
	id int IDENTITY,
	tipo varchar(10),
	PRIMARY KEY (id)
)

CREATE TABLE mario_killers.Persona (
	id int IDENTITY,
	nombre varchar(255),
	apellido varchar(255),
	documento numeric(18, 0),
	fecha_nac datetime,
	direccion varchar(255),
	telefono numeric(18, 0),
	mail varchar(255),

    -- Campos faltantes
	tipo_doc int,
	sexo char(1),
	
	PRIMARY KEY (id),
	FOREIGN KEY (tipo_doc) REFERENCES mario_killers.Tipo_Documento(id)
)

CREATE TABLE mario_killers.Usuario (
	nombre varchar(255),
	persona int,
	pw char(64), -- SHA256
	intentos_login int,
	activo bit,
	PRIMARY KEY (nombre),
	FOREIGN KEY (persona) REFERENCES mario_killers.Persona(id)
)

CREATE TABLE mario_killers.Rol (
	id int IDENTITY,
	rol varchar(255) NOT NULL,
	activo bit,
	PRIMARY KEY (id)
)

CREATE TABLE mario_killers.Funcionalidad (
	id int IDENTITY,
	nombre varchar(255) NOT NULL,
	PRIMARY KEY (id)
)

CREATE TABLE mario_killers.Funcionalidad_Rol (
	rol int,
	funcionalidad int,
	FOREIGN KEY (rol) REFERENCES mario_killers.Rol(id),
	FOREIGN KEY (funcionalidad) REFERENCES mario_killers.Funcionalidad(id)
)

CREATE TABLE mario_killers.Roles_Usuario (
	usuario varchar(255),
	rol int,
	FOREIGN KEY (usuario) REFERENCES mario_killers.Usuario(nombre),
	FOREIGN KEY (rol) REFERENCES mario_killers.Rol(id)
)

CREATE TABLE mario_killers.Plan_Medico (
	codigo numeric(18, 0),
	descripcion varchar(255),
	precio_bono_consulta numeric(18, 0),
	precio_bono_farmacia numeric(18, 0),
	PRIMARY KEY (codigo)
)

CREATE TABLE mario_killers.Compra (
	id int IDENTITY,
	fecha datetime,
	persona int,
	plan_medico int,
	PRIMARY KEY (id)
)

CREATE TABLE mario_killers.Estado_Civil (
	id int IDENTITY,
	estado varchar(255),
	PRIMARY KEY (id)
)

CREATE TABLE mario_killers.Grupo_Familia (
	codigo numeric(18, 0),
	plan_medico numeric(18, 0),
	PRIMARY KEY (codigo),
	-- FOREIGN KEY (plan_medico) REFERENCES mario_killers.Plan_Med(codigo)
)

CREATE TABLE mario_killers.Afiliado (
	persona int,
	estado_civil int,
	grupo_familia numeric(18,0),
	nro_familiar int,
	cant_hijos int,
	activo bit,
	PRIMARY KEY (persona),
	-- UNIQUE (grupo_familia, nro_familiar) No es UNIQUE para la migracion
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
	activo bit,
	PRIMARY KEY (persona),
	FOREIGN KEY (persona) REFERENCES mario_killers.Persona(id)
	-- UNIQUE (matricula)
)

CREATE TABLE mario_killers.Agenda (
	profesional int,
	desde date NOT NULL,
	hasta date NOT NULL,
	PRIMARY KEY (profesional),
	CONSTRAINT max_120_dias CHECK (DATEDIFF(day, desde, hasta) <= 120),
	CONSTRAINT fechas_validas CHECK (desde < hasta),
	FOREIGN KEY (profesional) REFERENCES mario_killers.Profesional(persona)
)

CREATE TABLE mario_killers.Rango (
	id int IDENTITY,
	dia int, -- domingo = 1, valor default de DATEFIRST
	profesional int,
	hora_desde time,
	hora_hasta time,
	PRIMARY KEY (id),
	CONSTRAINT horarios_validos CHECK (
	CASE
		WHEN dia BETWEEN 2 AND 6
		     AND hora_desde BETWEEN '07:00:00' AND '20:00:00'
		     AND hora_hasta BETWEEN '07:00:00' AND '20:00:00'
		THEN 1
		WHEN dia = 7
		     AND hora_desde BETWEEN '10:00:00' AND '15:00:00'
		     AND hora_hasta BETWEEN '10:00:00' AND '15:00:00'
		THEN 1
	END = 1
	AND hora_desde < hora_hasta
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
	descripcion varchar(255),
	PRIMARY KEY (codigo)
)

CREATE TABLE mario_killers.Especialidad (
	codigo numeric(18, 0) IDENTITY,
	descripcion varchar(255),
	tipo numeric(18, 0),
	PRIMARY KEY (codigo),
	FOREIGN KEY (tipo) REFERENCES mario_killers.Tipo_Especialidad(codigo)
)

CREATE TABLE mario_killers.Turno (
	id int IDENTITY,
	persona int,
	profesional int,
	horario datetime,
	especialidad numeric(18, 0),
	activo bit,
	horario_llegada datetime,
	PRIMARY KEY (id),
	FOREIGN KEY (persona) REFERENCES mario_killers.Persona(id),
	FOREIGN KEY (profesional) REFERENCES mario_killers.Profesional(persona),
	FOREIGN KEY (especialidad) REFERENCES mario_killers.Especialidad(codigo)
)

CREATE TABLE mario_killers.Atencion (
	turno int,
	fecha datetime,
	diagnostico varchar(255),
	PRIMARY KEY (turno),
	FOREIGN KEY (turno) REFERENCES mario_killers.Turno(id)
)

CREATE TABLE mario_killers.Bono_Consulta (
	id int IDENTITY,
	compra int,
	contador int,
	turno int,
	plan_medico numeric(18, 0),
	PRIMARY KEY (id),
	FOREIGN KEY (plan_medico) REFERENCES mario_killers.Plan_Medico(codigo),
	FOREIGN KEY (compra) REFERENCES mario_killers.Compra(id),
	FOREIGN KEY (turno) REFERENCES mario_killers.Turno(id)
)

CREATE TABLE mario_killers.Receta (
	id int IDENTITY,
	atencion int,
	activo bit,
	PRIMARY KEY (id),
	-- FOREIGN KEY (atencion) REFERENCES mario_killers.Atencion(turno)
)

CREATE TABLE mario_killers.Bono_Farmacia (
	id int,
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
	detalle varchar(255),
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

CREATE TABLE mario_killers.Sintoma (
	atencion int,
	detalle varchar(255),
	PRIMARY KEY (atencion),
	FOREIGN KEY (atencion) REFERENCES mario_killers.Atencion(turno)
)

--------------------------------- MIGRACION ---------------------------------
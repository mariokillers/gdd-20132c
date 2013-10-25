CREATE SCHEMA mario_killers AUTHORIZATION gd

CREATE TABLE Persona (
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
	usuario int,
	
	PRIMARY KEY (id)
	-- FOREIGN KEY (tipo_doc) REFERENCES Tipo_Documento(id)
	-- FOREIGN KEY (usuario) REFERENCES Usuario(id)
) GO

CREATE TABLE Tipo_Documento (
	id int IDENTITY,
	tipo varchar(10),
	PRIMARY KEY (id)
) GO

CREATE TABLE Usuario (
	nombre varchar(255),
	persona int,
	pw char(64), -- SHA256
	intentos_login int,
	activo bit,
	PRIMARY KEY (nombre),
	-- FOREIGN KEY (persona) REFERENCES Persona(id)
) GO

CREATE TABLE Rol (
	id int IDENTITY,
	rol varchar(255) NOT NULL,
	PRIMARY KEY (id)
)

CREATE TABLE Roles_Usuario (
	usuario int,
	rol int,
	-- FOREIGN KEY (usuario) REFERENCES Usuario(nombre)
	-- FOREIGN KEY (rol) REFERENCES Rol(id)
)

CREATE TABLE Plan_Medico (
	codigo numeric(18, 0),
	descripcion varchar(255),
	precio_bono_consulta numeric(18, 0),
	precio_bono_farmacia numeric(18, 0),
	PRIMARY KEY (codigo)
) GO

CREATE TABLE Compra (
	id int IDENTITY,
	fecha datetime,
	persona int,
	plan_medico int,
	PRIMARY KEY (id)
) GO

CREATE TABLE Afiliado (
	persona int,
	estado_civil int,
	grupo_familia numeric(18,0),
	nro_familiar int,
	cant_hijos int,
	activo bit,
	PRIMARY KEY (persona),
	-- UNIQUE (grupo_familia, nro_familiar) No es UNIQUE para la migracion
	-- FOREIGN KEY (persona) REFERENCES Persona(id)
	-- FOREIGN KEY (estado_civil) REFERENCES Estado_Civil(id)
	-- FOREIGN KEY (grupo_familia) REFERENCES Grupo_Familia(codigo)
) GO

CREATE TABLE Bajas_Afiliado (
	persona int NOT NULL,
	fecha datetime NOT NULL,
	FOREIGN KEY (persona) REFERENCES Afiliado(persona)
)

CREATE TABLE Estado_Civil (
	id int IDENTITY,
	estado varchar(255),
	PRIMARY KEY (id)
) GO

CREATE TABLE Grupo_Familia (
	codigo numeric(18, 0),
	plan_medico numeric(18, 0),
	PRIMARY KEY (codigo),
	-- FOREIGN KEY (plan_medico) REFERENCES Plan_Med(codigo)
) GO

CREATE TABLE Modificaciones_Grupo (
	grupo_familia numeric(18, 0) NOT NULL,
	plan_medico numeric(18, 0) NOT NULL,
	fecha datetime NOT NULL,
	motivo varchar(255) NOT NULL,
	FOREIGN KEY (grupo_familia) REFERENCES Grupo_Familia(codigo),
	FOREIGN KEY (plan_medico) REFERENCES Plan_medico(codigo)
) GO

CREATE TABLE Profesional (
	persona int,
	matricula int,
	activo bit,
	PRIMARY KEY (persona),
	-- FOREIGN KEY (persona) REFERENCES Persona(id)
	-- UNIQUE (matricula)
) GO

CREATE TABLE Agenda (
	profesional int,
	desde date NOT NULL,
	hasta date NOT NULL,
	PRIMARY KEY (profesional),
	CONSTRAINT max_120_dias CHECK (DATEDIFF(day, desde, hasta) <= 120),
	CONSTRAINT fechas_validas CHECK (desde < hasta)
	-- FOREIGN KEY (profesional) REFERENCES Profesional(persona)
) GO

CREATE FUNCTION mario_killers.horas_por_semana(@profesional int) RETURNS int AS
BEGIN
	RETURN (SELECT SUM(DATEDIFF(HOUR, hora_desde, hora_hasta))
	FROM mario_killers.Rango
	WHERE Rango.profesional = @profesional)
END
GO

CREATE TABLE Rango (
	dia int, -- domingo = 1, valor default de DATEFIRST
	profesional int,
	hora_desde time,
	hora_hasta time,
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
	-- FOREIGN KEY (profesional) REFERENCES Profesional(persona)
	-- TODO: Ver fechas que se pisen
) GO

CREATE TABLE Especialidad_Profesional (
	profesional int,
	especialidad int,
	PRIMARY KEY (profesional, especialidad)
) GO

CREATE TABLE Tipo_Especialidad (
	codigo numeric(18, 0) IDENTITY,
	descripcion varchar(255),
	PRIMARY KEY (codigo)
) GO

CREATE TABLE Especialidad (
	codigo numeric(18, 0) IDENTITY,
	descripcion varchar(255),
	tipo numeric(18, 0),
	PRIMARY KEY (codigo),
	-- FOREIGN KEY (tipo) REFERENCES Tipo_Especialidad(codigo)
) GO

CREATE TABLE Turno (
	id int IDENTITY,
	persona int,
	profesional int,
	horario datetime,
	especialidad int,
	activo bit,
	horario_llegada datetime,
	PRIMARY KEY (id),
	-- FOREIGN KEY (persona) REFERENCES Persona(id),
	-- FOREIGN KEY (profesional) REFERENCES Profesional(persona),
	-- FOREIGN KEY (especialidad) REFERENCES Especialidad(codigo)
) GO

CREATE TABLE Atencion (
	turno int,
	fecha datetime,
	diagnostico varchar(255),
	PRIMARY KEY (turno),
	-- FOREIGN KEY (turno) REFERENCES Turno(id)
) GO

CREATE TABLE Bono_Consulta (
	id int IDENTITY,
	compra int,
	contador int,
	turno int,
	plan_medico int,
	PRIMARY KEY (id),
	-- FOREIGN KEY (plan_medico) REFERENCES Plan_Medico(codigo),
	-- FOREIGN KEY (compra) REFERENCES Compra(id),
	-- FOREIGN KEY (turno) REFERENCES Turno(id)
) GO

CREATE TABLE Bono_Farmacia (
	id int,
	compra int,
	receta int,
	plan_medico int,
	PRIMARY KEY (id),
	-- FOREIGN KEY (plan_medico) REFERENCES Plan_Medico(codigo),
	-- FOREIGN KEY (compra) REFERENCES Compra(id),
	-- FOREIGN KEY (receta) REFERENCES Receta(id)
) GO

CREATE TABLE Medicamento_Receta (
	medicamento int,
	receta int,
	cantidad int,
	PRIMARY KEY (medicamento, receta),
	-- FOREIGN KEY (medicamento) REFERENCES Medicamento(id),
	-- FOREIGN KEY (receta) REFERENCES Receta(id)
	CONSTRAINT max_3 CHECK (cantidad <= 3)
)GO

CREATE TABLE Medicamento (
	id int IDENTITY,
	detalle varchar(255),
	PRIMARY KEY (id)
) GO

CREATE TABLE Receta (
	id int IDENTITY,
	atencion int,
	activo bit,
	PRIMARY KEY (id),
	-- FOREIGN KEY (atencion) REFERENCES Atencion(turno)
) GO

CREATE TABLE Sintoma (
	atencion int,
	detalle varchar(255),
	PRIMARY KEY (atencion),
	-- FOREIGN KEY (atencion) REFERENCES Atencion(turno)
) GO

--------------------------------- MIGRACION ---------------------------------

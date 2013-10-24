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
	-- FOREIGN KEY (tipo_doc) REFERENCES TipoDocumento(id)
	-- FOREIGN KEY (usuario) REFERENCES Usuario(id)
)

CREATE TABLE TipoDocumento (
	id int IDENTITY,
	tipo varchar(10),
	PRIMARY KEY (id)
)	

CREATE TABLE Usuario (
	nombre varchar(255),
	persona int,
	pw char(64), -- SHA256
	intentos_login int,
	activo bit,
	PRIMARY KEY (nombre),
	-- FOREIGN KEY (persona) REFERENCES Persona(id)
) 

CREATE TABLE Plan_Medico (
	codigo numeric(18, 0),
	descripcion varchar(255),
	precio_bono_consulta numeric(18, 0),
	precio_bono_farmacia numeric(18, 0),
	PRIMARY KEY (codigo)
)

CREATE TABLE Compra (
	id int IDENTITY,
	fecha datetime,
	persona int,
	plan_medico int,
	PRIMARY KEY (id)
)

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
	-- FOREIGN KEY (estado_civil) REFERENCES EstadoCivil(id)
	-- FOREIGN KEY (grupo_familia) REFERENCES GrupoFamiliar(codigo)
)

CREATE TABLE EstadoCivil (
	id int IDENTITY,
	estado varchar(255),
	PRIMARY KEY (id)
)

CREATE TABLE GrupoFamilia (
	codigo numeric(18, 0),
	plan_medico numeric(18, 0),
	PRIMARY KEY (codigo),
	-- FOREIGN KEY (plan_medico) REFERENCES Plan_Med(codigo)
)

CREATE TABLE Profesional (
	persona int,
	matricula int,
	activo bit,
	PRIMARY KEY (persona),
	-- UNIQUE (matricula)
)

CREATE TABLE Especialidad_Profesional (
	profesional int,
	especialidad int,
	PRIMARY KEY (profesional, especialidad)
)

CREATE TABLE Tipo_Especialidad (
	codigo numeric(18, 0) IDENTITY,
	descripcion varchar(255),
	PRIMARY KEY (codigo)
)

CREATE TABLE Especialidad (
	codigo numeric(18, 0) IDENTITY,
	descripcion varchar(255),
	tipo numeric(18, 0),
	PRIMARY KEY (codigo),
	-- FOREIGN KEY (tipo) REFERENCES Tipo_Especialidad(codigo)
)

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
)

CREATE TABLE Atencion (
	turno int,
	fecha datetime,
	diagnostico varchar(255),
	PRIMARY KEY (turno),
	-- FOREIGN KEY (turno) REFERENCES Turno(id)
)

CREATE TABLE Bono_Consulta (
	id int IDENTITY,
	compra int,
	contador int,
	turno int,
	plan_medico int,
	PRIMARY KEY (id),
	-- FOREIGN KEY (compra) REFERENCES Compra(id),
	-- FOREIGN KEY (turno) REFERENCES Turno(id)
)

CREATE TABLE Bono_Farmacia (
	id int,
	compra int,
	receta int,
	plan_medico int,
	PRIMARY KEY (id),
	-- FOREIGN KEY (compra) REFERENCES Compra(id),
	-- FOREIGN KEY (receta) REFERENCES Receta(id)
)

CREATE TABLE Medicamento_Receta (
	medicamento int,
	receta int,
	cantidad int, -- constraint  <= 3
	PRIMARY KEY (medicamento, receta),
	-- FOREIGN KEY (medicamento) REFERENCES Medicamento(id),
	-- FOREIGN KEY (receta) REFERENCES Receta(id)
)

CREATE TABLE Medicamento (
	id int IDENTITY,
	detalle varchar(255),
	PRIMARY KEY (id)
)

CREATE TABLE Receta (
	id int IDENTITY,
	atencion int,
	PRIMARY KEY (id),
	-- FOREIGN KEY (atencion) REFERENCES Atencion(turno)
)

CREATE TABLE Sintoma (
	atencion int,
	detalle varchar(255),
	PRIMARY KEY (atencion),
	-- FOREIGN KEY (atencion) REFERENCES Atencion(turno)
)

--------------------------------- MIGRACION ---------------------------------


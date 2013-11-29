CREATE SCHEMA mario_killers AUTHORIZATION gd
GO

CREATE PROCEDURE mario_killers.agregarAtencion (@horario_atencion datetime, @sintomas text, @diagnostico text, @turno numeric(18,0), @ret numeric(18,0) output)
AS BEGIN
	INSERT INTO mario_killers.Atencion (horario_atencion, sintomas, diagnostico, turno)
	VALUES (@horario_atencion, @sintomas, @diagnostico, @turno)
	SET @ret = SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE mario_killers.anularRango(@profesional numeric(18,0),
										 @fechaInicio date,
										 @fechaFin date,
										 @ret numeric(18,0) output)
AS BEGIN
	UPDATE mario_killers.Turno SET activo = 0 WHERE profesional = @profesional AND horario BETWEEN CONVERT(DATE,@fechaInicio) AND CONVERT(DATE,@fechaFin)
END
GO

CREATE PROCEDURE mario_killers.anularDia(@profesional numeric(18,0),
										 @horario date,
										 @ret numeric(18,0) output)
AS BEGIN
	UPDATE mario_killers.Turno SET activo = 0 WHERE profesional = @profesional AND CONVERT(DATE,horario) =  CONVERT(DATE,@horario)
	SET @ret = 0
END
GO

CREATE PROCEDURE mario_killers.agregarTurno(@persona numeric(18,0),
											@profesional numeric(18,0),
											@horario varchar(255),
											@especialidad numeric(18,0),
											@ret numeric(18,0) output)
AS BEGIN
	INSERT INTO mario_killers.Turno(persona, profesional, horario, especialidad)
			VALUES (@persona, @profesional, CONVERT(DATETIME, @horario), @especialidad)
	SET @ret = SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE mario_killers.verificarTurno(@fecha date,
											  @horario time,
											  @profesional numeric(18,0),
											  @ret numeric(18,0) output)
AS BEGIN
	IF(EXISTS(SELECT * FROM mario_killers.Turno WHERE profesional = @profesional AND 
														CONVERT(DATE, horario) = CONVERT(DATE,@fecha) AND 
														CONVERT(TIME, horario) = CONVERT(TIME, @horario))) BEGIN SET @ret = 0 END
	ELSE BEGIN SET @ret = 1 END
END
GO

CREATE PROCEDURE mario_killers.modificarProfesional(@id numeric(18,0),
													@sexo char(1),
												   @direccion varchar(255),
												   @telefono numeric(18,0),
												   @mail varchar(255),
												   @matricula numeric(18,0),
												   @ret numeric(18,0) output)
AS BEGIN
UPDATE mario_killers.Persona SET sexo = @sexo, direccion = @direccion, telefono = @telefono, mail = @mail
WHERE id = @id
UPDATE mario_killers.Profesional SET matricula = @matricula
WHERE persona = @id
SET @ret = @id
END
GO

CREATE PROCEDURE mario_killers.agregarProfesional(@nombre varchar(255),
												   @apellido varchar(255),
												   @fecha_nac datetime,
												   @sexo char(1),
												   @tipo_doc numeric(18,0),
												   @documento numeric(18,0),
												   @direccion varchar(255),
												   @telefono numeric(18,0),
												   @mail varchar(255),
												   @matricula numeric(18,0),
												   @ret numeric(18,0) output)
AS BEGIN
INSERT INTO mario_killers.Persona (nombre, apellido, documento,
                                   fecha_nac, direccion, telefono,
                                   mail, tipo_doc, sexo)
	VALUES (@nombre, @apellido, @documento,
			@fecha_nac, @direccion, @telefono,
			@mail, @tipo_doc, @sexo)
DECLARE @pers numeric(18,0)
SET @pers = SCOPE_IDENTITY()
INSERT INTO mario_killers.Profesional (persona, matricula)
	VALUES (@pers, @matricula) SET @ret = @pers
END
GO

CREATE PROCEDURE mario_killers.registrarCambioPlan(@grupo numeric(18,0),
												   @plan numeric(18,0),
												   @date datetime,
												   @desc varchar(255),
												   @ret numeric(18,0) output)
AS BEGIN
INSERT INTO mario_killers.Modificaciones_Grupo (grupo_familia, plan_medico, fecha, motivo)
	VALUES (@grupo, @plan, @date, @desc)
	SET @ret = @grupo
END
GO

CREATE PROCEDURE mario_killers.agregarAfiliadoFamilia(@nombre varchar(255),
                                               @apellido varchar(255),
                                               @fecha_nac datetime,
                                               @sexo char(1),
                                               @tipo_doc numeric(18,0),
                                               @documento numeric(18,0),
                                               @direccion varchar(255),
                                               @telefono numeric(18,0),
                                               @estado_civil numeric(18,0),
                                               @mail varchar(255),
                                               @cant_hijos numeric(18,0),
                                               @plan_medico numeric(18,0),
                                               @nro_flia numeric(18,0),
                                               @grupo_familia numeric(18,0),
                                               @ret numeric(18,0) output)
AS BEGIN
INSERT INTO mario_killers.Persona (nombre, apellido, documento,
                                   fecha_nac, direccion, telefono,
                                   mail, tipo_doc, sexo)
	VALUES (@nombre, @apellido, @documento,
			@fecha_nac, @direccion, @telefono,
			@mail, @tipo_doc, @sexo)
DECLARE @pers numeric(18,0)
SET @pers = SCOPE_IDENTITY()

IF(@nro_flia = 0) BEGIN SET @nro_flia = (SELECT COUNT(nro_familiar)+1 FROM mario_killers.Afiliado WHERE grupo_familia = @grupo_familia) END

INSERT INTO mario_killers.Afiliado (persona, estado_civil, grupo_familia, nro_familiar, cant_hijos)
	VALUES (@pers, @estado_civil, @grupo_familia, @nro_flia, @cant_hijos) SET @ret = @grupo_familia
END
GO


CREATE PROCEDURE mario_killers.agregarAfiliado(@nombre varchar(255),
                                               @apellido varchar(255),
                                               @fecha_nac datetime,
                                               @sexo char(1),
                                               @tipo_doc numeric(18,0),
                                               @documento numeric(18,0),
                                               @direccion varchar(255),
                                               @telefono numeric(18,0),
                                               @estado_civil numeric(18,0),
                                               @mail varchar(255),
                                               @cant_hijos numeric(18,0),
                                               @plan_medico numeric(18,0),
                                               @nro_flia numeric(18,0),
                                               @ret numeric(18,0) output)
AS BEGIN
INSERT INTO mario_killers.Persona (nombre, apellido, documento,
                                   fecha_nac, direccion, telefono,
                                   mail, tipo_doc, sexo)
	VALUES (@nombre, @apellido, @documento,
			@fecha_nac, @direccion, @telefono,
			@mail, @tipo_doc, @sexo)
DECLARE @pers numeric(18,0)
SET @pers = SCOPE_IDENTITY()
INSERT INTO mario_killers.Grupo_Familia (plan_medico)
	VALUES (@plan_medico)
DECLARE @grupo numeric(18,0) SET @grupo = SCOPE_IDENTITY()
INSERT INTO mario_killers.Afiliado (persona, estado_civil, grupo_familia, nro_familiar, cant_hijos)
	VALUES (@pers, @estado_civil, @grupo, @nro_flia, @cant_hijos) SET @ret = @grupo
END
GO

CREATE PROCEDURE mario_killers.agregarPlanAlGrupo (@plan_medico numeric(18,0), @afil_viejo numeric(18,0), @ret numeric(18,0) output)
AS BEGIN
	INSERT INTO mario_killers.Grupo_Familia (plan_medico) VALUES (@plan_medico)
	DECLARE @aux numeric(18,0)
	SET @aux = SCOPE_IDENTITY()
	
	UPDATE mario_killers.Afiliado
	SET grupo_familia = @aux, nro_familiar = 01
	WHERE persona = @afil_viejo
	
	SET @ret = @aux
END
GO

CREATE PROCEDURE mario_killers.agregarRol(@nombreRol varchar(255), @ret numeric(18,0) output)
AS BEGIN
	INSERT INTO mario_killers.Rol (nombre, activo) VALUES (@nombreRol, 1)
	SET @ret = SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE mario_killers.hacerCompra(@persona numeric(18, 0),@fecha datetime, @plan_medico numeric(18, 0) , @ret numeric(18,0) output)
AS BEGIN
	INSERT INTO mario_killers.Compra (fecha, persona, plan_medico) VALUES ( @fecha, @persona,@plan_medico )
	SET @ret = SCOPE_IDENTITY()
END
GO

CREATE FUNCTION mario_killers.Turno_Valido(@fecha datetime)
RETURNS BIT
AS BEGIN
	IF DATEPART(weekday, @fecha) = 1
		RETURN 0
	RETURN 1
END
GO

CREATE FUNCTION mario_killers.bono_farmacia_valido(@fecha datetime, @vencimiento datetime, @medicamento varchar(255)) RETURNS bit
AS BEGIN
	IF @vencimiento < @fecha OR @medicamento IS NOT NULL
		RETURN 0
	RETURN 1
END
GO

CREATE FUNCTION mario_killers.horario_atencion(@hora datetime) returns numeric(18, 0)
AS BEGIN
	DECLARE @result numeric(18, 0)
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

CREATE FUNCTION mario_killers.horas_por_semana(@profesional numeric(18, 0)) RETURNS numeric(18, 0) AS
BEGIN
	RETURN (SELECT SUM(DATEDIFF(HOUR, hora_desde, hora_hasta))
	FROM mario_killers.Rango
	WHERE Rango.profesional = @profesional)
END
GO

CREATE FUNCTION mario_killers.horas_se_pisan(@profesional numeric(18, 0)) RETURNS bit AS
BEGIN
	RETURN (
		SELECT COUNT(1)
		FROM mario_killers.Rango r1 JOIN mario_killers.Rango r2 ON r1.dia = r2.dia
		WHERE r1.hora_desde < r2.hora_hasta AND r2.hora_desde < r1.hora_hasta
		      AND r1.id <> r2.id
	)
END
GO

CREATE FUNCTION mario_killers.roles_usuario(@username varchar(255))
RETURNS @roles TABLE (rol int, nombre varchar(255)) AS
BEGIN
	INSERT INTO @roles
		SELECT id, nombre
		FROM
			mario_killers.Rol_Usuario JOIN mario_killers.Rol
			ON Rol_Usuario.rol = Rol.id
		WHERE Rol_Usuario.usuario = @username
	RETURN
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
	id numeric(18, 0) IDENTITY,
	tipo varchar(10) NOT NULL,
	PRIMARY KEY (id)
)

CREATE TABLE mario_killers.Persona (
	id numeric(18, 0) IDENTITY,
	nombre varchar(255) NOT NULL,
	apellido varchar(255) NOT NULL,
	documento numeric(18, 0) NOT NULL,
	fecha_nac datetime NOT NULL,
	direccion varchar(255) NOT NULL,
	telefono numeric(18, 0) NOT NULL,
	mail varchar(255) NOT NULL,

    -- Campos faltantes
	tipo_doc numeric(18, 0),
	sexo char(1),
	
	PRIMARY KEY (id),
	FOREIGN KEY (tipo_doc) REFERENCES mario_killers.Tipo_Documento(id),
	UNIQUE (tipo_doc, documento)
)

CREATE TABLE mario_killers.Usuario (
	nombre varchar(255),
	persona numeric(18, 0),
	pw char(64) NOT NULL, -- SHA256
	intentos_login numeric(18, 0) NOT NULL
		CONSTRAINT "intentos_login_0" DEFAULT 0,
	activo bit NOT NULL
		CONSTRAINT "usuario_activo" DEFAULT 1,
	PRIMARY KEY (nombre),
	FOREIGN KEY (persona) REFERENCES mario_killers.Persona(id),
)

CREATE TABLE mario_killers.Rol (
	id numeric(18, 0) IDENTITY,
	nombre varchar(255) NOT NULL,
	activo bit NOT NULL
		CONSTRAINT rol_activo DEFAULT 1,
	PRIMARY KEY (id)
)

CREATE TABLE mario_killers.Funcionalidad (
	id numeric(18, 0) IDENTITY,
	nombre varchar(255) NOT NULL,
	PRIMARY KEY (id)
)

CREATE TABLE mario_killers.Funcionalidad_Rol (
	rol numeric(18, 0) NOT NULL,
	funcionalidad numeric(18, 0) NOT NULL,
	FOREIGN KEY (rol) REFERENCES mario_killers.Rol(id),
	FOREIGN KEY (funcionalidad) REFERENCES mario_killers.Funcionalidad(id)
)

CREATE TABLE mario_killers.Rol_Usuario (
	usuario varchar(255),
	rol numeric(18, 0),
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

CREATE TABLE mario_killers.Estado_Civil (
	id numeric(18, 0) IDENTITY,
	estado varchar(255) NOT NULL,
	PRIMARY KEY (id)
)

CREATE TABLE mario_killers.Grupo_Familia (
	codigo numeric(18, 0) IDENTITY,
	plan_medico numeric(18, 0) NOT NULL,
	PRIMARY KEY (codigo),
	FOREIGN KEY (plan_medico) REFERENCES mario_killers.Plan_Medico(codigo)
)

CREATE TABLE mario_killers.Afiliado (
	-- Cantidad de consultas se calcula
	persona numeric(18, 0),
	estado_civil numeric(18, 0),
	grupo_familia numeric(18,0) NOT NULL,
	nro_familiar numeric(18, 0) NOT NULL,
	cant_hijos numeric(18, 0),
	activo bit NOT NULL
		CONSTRAINT afiliado_activo DEFAULT 1,
	PRIMARY KEY (persona),
	UNIQUE (grupo_familia, nro_familiar),
	FOREIGN KEY (persona) REFERENCES mario_killers.Persona(id),
	FOREIGN KEY (estado_civil) REFERENCES mario_killers.Estado_Civil(id),
	FOREIGN KEY (grupo_familia) REFERENCES mario_killers.Grupo_Familia(codigo)
)

CREATE TABLE mario_killers.Bajas_Afiliado (
	persona numeric(18, 0) NOT NULL,
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
	persona numeric(18, 0),
	matricula numeric(18, 0),
	activo bit NOT NULL
		CONSTRAINT profesional_activo DEFAULT 1,
	PRIMARY KEY (persona),
	FOREIGN KEY (persona) REFERENCES mario_killers.Persona(id)
	-- UNIQUE (matricula)
)

CREATE TABLE mario_killers.Agenda (
	profesional numeric(18, 0) NOT NULL,
	desde date NOT NULL,
	hasta date NOT NULL,
	PRIMARY KEY (profesional),
	CONSTRAINT max_120_dias CHECK (DATEDIFF(day, desde, hasta) <= 120),
	CONSTRAINT fechas_validas CHECK (desde < hasta),
	FOREIGN KEY (profesional) REFERENCES mario_killers.Profesional(persona)
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

CREATE TABLE mario_killers.Rango (
	id numeric(18, 0) IDENTITY,
	dia numeric(18, 0) NOT NULL, -- domingo = 1, valor default de DATEFIRST
	profesional numeric(18, 0) NOT NULL,
	hora_desde time NOT NULL,
	hora_hasta time NOT NULL,
	especialidad numeric(18, 0) NOT NULL,
	PRIMARY KEY (id),
	CONSTRAINT horarios_validos CHECK (
	mario_killers.horario_atencion(CONVERT(TIME,hora_desde)) = 1 AND
	mario_killers.horario_atencion(CONVERT(TIME,hora_hasta)) = 1 AND
	hora_desde < hora_hasta
	),
	CONSTRAINT max_horas_por_semana CHECK (mario_killers.horas_por_semana(profesional) <= 48),
	--CONSTRAINT horas_no_se_pisan CHECK (mario_killers.horas_se_pisan(profesional) = 0),
	FOREIGN KEY (profesional) REFERENCES mario_killers.Profesional(persona),
	FOREIGN KEY (especialidad) REFERENCES mario_killers.Especialidad(codigo)
)

CREATE TABLE mario_killers.Especialidad_Profesional (
	profesional numeric(18, 0),
	especialidad numeric(18, 0),
	PRIMARY KEY (profesional, especialidad),
	FOREIGN KEY (profesional) REFERENCES mario_killers.Profesional(persona),
	FOREIGN KEY (especialidad) REFERENCES mario_killers.Especialidad(codigo)
)

CREATE TABLE mario_killers.Turno (
	id numeric(18, 0) IDENTITY,
	persona numeric(18, 0) NOT NULL,
	profesional numeric(18, 0) NOT NULL,
	horario datetime NOT NULL,
	horario_llegada datetime,
	especialidad numeric(18, 0) NOT NULL,
	activo bit
		CONSTRAINT turno_activo DEFAULT 1,
	PRIMARY KEY (id),
	FOREIGN KEY (persona) REFERENCES mario_killers.Persona(id),
	FOREIGN KEY (profesional) REFERENCES mario_killers.Profesional(persona),
	FOREIGN KEY (especialidad) REFERENCES mario_killers.Especialidad(codigo),
	UNIQUE (horario, profesional)
)

CREATE TABLE mario_killers.Compra (
	id numeric(18, 0) IDENTITY,
	fecha datetime,
	persona numeric(18, 0),
	plan_medico numeric(18, 0) NOT NULL,
	PRIMARY KEY (id),
	FOREIGN KEY (plan_medico) REFERENCES mario_killers.Plan_Medico(codigo),
	FOREIGN KEY (persona) REFERENCES mario_killers.Afiliado(persona)
)

CREATE TABLE mario_killers.Bono_Consulta (
	id numeric(18, 0) IDENTITY,
	compra numeric(18, 0),
	plan_medico numeric(18, 0),
	cant_consultas numeric(18,0),
	activo bit NOT NULL
		CONSTRAINT bono_consulta_activo DEFAULT 1,
	PRIMARY KEY (id),
	FOREIGN KEY (plan_medico) REFERENCES mario_killers.Plan_Medico(codigo),
	FOREIGN KEY (compra) REFERENCES mario_killers.Compra(id)
)

CREATE TABLE mario_killers.Atencion (
	id numeric(18, 0),
	horario_atencion datetime,
	sintomas text,
	diagnostico text,
	bono_consulta numeric(18, 0),
	PRIMARY KEY (id),
	FOREIGN KEY (id) REFERENCES mario_killers.Turno(id),
	FOREIGN KEY (bono_consulta) REFERENCES mario_killers.Bono_Consulta(id)
)

CREATE TABLE mario_killers.Bono_Farmacia (
	codigo numeric(18, 0) IDENTITY,
	compra numeric(18, 0),
	plan_medico numeric(18, 0),
	activo bit
		CONSTRAINT bono_nuevo DEFAULT 1,
	PRIMARY KEY (codigo),
	FOREIGN KEY (plan_medico) REFERENCES mario_killers.Plan_Medico(codigo),
	FOREIGN KEY (compra) REFERENCES mario_killers.Compra(id)
)

CREATE TABLE mario_killers.Medicamento (
	detalle varchar(255) NOT NULL,
	PRIMARY KEY (detalle)
)
GO

CREATE FUNCTION mario_killers.cant_medicamentos(@historia_id numeric(18, 0)) returns int
AS BEGIN
	RETURN (
			SELECT COUNT(DISTINCT medicamento)
			FROM mario_killers.Medicamento_Atencion
			WHERE Atencion = @historia_id
			GROUP BY Atencion
			HAVING COUNT(DISTINCT medicamento) > 5
	)
END
GO

CREATE TABLE mario_killers.Medicamento_Atencion (
	id numeric(18, 0) IDENTITY,
	medicamento varchar(255),
	Atencion numeric(18, 0),
	cantidad numeric(18, 0)
		CONSTRAINT default_1_med DEFAULT 1,
	bono_farmacia numeric(18, 0),
	activo bit
		CONSTRAINT activo DEFAULT 1,
	PRIMARY KEY (id),
	FOREIGN KEY (Atencion) REFERENCES mario_killers.Atencion(id),
	FOREIGN KEY (bono_farmacia) REFERENCES mario_killers.Bono_Farmacia(codigo),
	FOREIGN KEY (medicamento) REFERENCES mario_killers.Medicamento(detalle),
	CONSTRAINT max_3_medicamento CHECK (cantidad <= 3)
)
GO

CREATE TABLE mario_killers.Tipo_Cancelacion (
	id numeric(18,0) IDENTITY,
	descripcion varchar(255),
	PRIMARY KEY (id)
)
GO

CREATE TABLE mario_killers.Cancelacion (
	tipo numeric(18,0),
	motivo varchar(255),
	persona numeric(18,0),
	turno numeric(18,0)
	FOREIGN KEY (persona) REFERENCES mario_killers.Persona,
	FOREIGN KEY (tipo) REFERENCES mario_killers.Tipo_Cancelacion(id),
	FOREIGN KEY (turno) REFERENCES mario_killers.Turno
)
GO

--------------------------------- DATOS INICIALES -----------------------------

INSERT INTO mario_killers.Estado_Civil (estado)
	VALUES ('Soltero/a'),
	       ('Casado/a'),
	       ('Viudo/a'),
	       ('Concubinato'),
	       ('Divorciado/a'),
	       ('X');

INSERT INTO mario_killers.Tipo_Documento (tipo)
	VALUES ('DNI'), ('CI'), ('LC'), ('LE'), ('X');

INSERT INTO mario_killers.Rol (nombre)
	VALUES ('Administrativo'),
	       ('Profesional'),
	       ('Afiliado');
	       
INSERT INTO mario_killers.Funcionalidad (nombre)
	VALUES ('ABM de roles'),
	       ('ABM de afiliados'),
	       ('ABM de profesionales'),
	       ('ABM de especialidades medicas'),
	       ('ABM de planes'),
	       ('Registrar agenda profesional'),
	       ('Registro de resultado para atencion medica'),
	       ('Registro de llegada para atencion medica'),
	       ('Registrar diagnostico'),
	       ('Cancelar atencion medica'),
	       ('Confeccionar receta medica'),
	       ('Consultar listado estadistico'),
	       ('Compra de bonos'),
	       ('Pedido de turno');

EXEC mario_killers.agregar_funcionalidad
	@rol = 'Administrativo', @func = 'ABM de roles';
EXEC mario_killers.agregar_funcionalidad
	@rol = 'Administrativo', @func = 'ABM de afiliados';
EXEC mario_killers.agregar_funcionalidad
	@rol = 'Administrativo', @func = 'ABM de profesionales';
EXEC mario_killers.agregar_funcionalidad
	@rol = 'Administrativo', @func = 'ABM de especialidades medicas';
EXEC mario_killers.agregar_funcionalidad
	@rol = 'Administrativo', @func = 'ABM de planes';
EXEC mario_killers.agregar_funcionalidad
	@rol = 'Profesional', @func = 'Registrar agenda profesional';
EXEC mario_killers.agregar_funcionalidad
	@rol = 'Afiliado', @func = 'Compra de bonos';
EXEC mario_killers.agregar_funcionalidad
	@rol = 'Administrativo', @func = 'Compra de bonos';	
EXEC mario_killers.agregar_funcionalidad
	@rol = 'Afiliado', @func = 'Pedido de turno';
EXEC mario_killers.agregar_funcionalidad
	@rol = 'Administrativo', @func = 'Registro de llegada para atencion medica';
EXEC mario_killers.agregar_funcionalidad
	@rol = 'Profesional', @func = 'Registro de resultado para atencion medica';
EXEC mario_killers.agregar_funcionalidad
	@rol = 'Profesional', @func = 'Cancelar atencion medica';
EXEC mario_killers.agregar_funcionalidad
	@rol = 'Afiliado', @func = 'Cancelar atencion medica';
EXEC mario_killers.agregar_funcionalidad
	@rol = 'Profesional', @func = 'Confeccionar receta medica';
EXEC mario_killers.agregar_funcionalidad
	@rol = 'Administrativo', @func = 'Consultar listado estadistico';
	
INSERT INTO mario_killers.Usuario (nombre, pw)
	VALUES ('admin', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7');

INSERT INTO mario_killers.Rol_Usuario
	VALUES ('admin', 1),
	       ('admin', 2),
	       ('admin', 3)	       
GO

SET IDENTITY_INSERT mario_killers.Tipo_Cancelacion ON
INSERT INTO mario_killers.Tipo_Cancelacion (id, descripcion) VALUES (1, 'Evento Imprevisto')
INSERT INTO mario_killers.Tipo_Cancelacion (id, descripcion) VALUES (2, 'Problemas Laborales')
INSERT INTO mario_killers.Tipo_Cancelacion (id, descripcion) VALUES (3, 'Problema Personal')
INSERT INTO mario_killers.Tipo_Cancelacion (id, descripcion) VALUES (4, 'Factor Climatico')
INSERT INTO mario_killers.Tipo_Cancelacion (id, descripcion) VALUES (5, 'Otro')
SET IDENTITY_INSERT mario_killers.Tipo_Cancelacion OFF
GO

CREATE FUNCTION mario_killers.mes(@m int)
RETURNS varchar(100)
AS BEGIN
	RETURN (CASE @m
		WHEN 1 THEN 'Enero'
		WHEN 2 THEN 'Febrero'
		WHEN 3 THEN 'Marzo'
		WHEN 4 THEN 'Abril'
		WHEN 5 THEN 'Mayo'
		WHEN 6 THEN 'Junio'
		WHEN 7 THEN 'Julio'
		WHEN 8 THEN 'Agosto'
		WHEN 9 THEN 'Septiembre'
		WHEN 10 THEN 'Octubre'
		WHEN 11 THEN 'Noviembre'
		WHEN 12 THEN 'Diciembre'
	END)
END
GO


-- Vistas ABM

-------------- Listado 1
CREATE VIEW mario_killers.cancelaciones_por_especialidad AS
SELECT Turno.id ID_Turno,
       YEAR(Turno.horario) Anio,
       MONTH(Turno.horario) Mes,
       Especialidad.descripcion Desc_Especialidad,
       Tipo_Especialidad.descripcion Desc_Tipo_Especialidad
       
FROM mario_killers.Cancelacion
	JOIN mario_killers.Turno ON Cancelacion.turno = Turno.id
	JOIN mario_killers.Especialidad ON Turno.especialidad = Especialidad.codigo
	JOIN mario_killers.Tipo_Especialidad ON Tipo_Especialidad.codigo = Especialidad.tipo
GO

CREATE VIEW mario_killers.listado_1_view AS
SELECT *, [1]+[2]+[3]+[4]+[5]+[6] Total_Primer_Semestre, [7]+[8]+[9]+[10]+[11]+[12] Total_Segundo_Semestre
FROM mario_killers.cancelaciones_por_especialidad
-- Mucha magia
PIVOT (COUNT(ID_Turno) FOR Mes IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12])) AS Cancelaciones_Pivot
GO
-------------------- Listado 2 (ver archivo)

-------------------- Listado 3

CREATE VIEW mario_killers.bonos_farmacia_por_especialidad AS
SELECT Bono_Farmacia.codigo AS Codigo_Bono,
       YEAR(Atencion.horario_atencion) Anio,
       MONTH(Atencion.horario_atencion) Mes,
       Especialidad.descripcion Desc_Especialidad,
       Tipo_Especialidad.descripcion Desc_Tipo_Especialidad
FROM mario_killers.Medicamento_Atencion
	JOIN mario_killers.Atencion ON Atencion.id = Medicamento_Atencion.Atencion
	JOIN mario_killers.Bono_Farmacia ON Medicamento_Atencion.bono_farmacia = Bono_Farmacia.codigo
	JOIN mario_killers.Turno ON Turno.id = Atencion.id
	JOIN mario_killers.Especialidad ON Turno.especialidad = Especialidad.codigo
	JOIN mario_killers.Tipo_Especialidad ON Tipo_Especialidad.codigo = Especialidad.tipo
GO

CREATE VIEW mario_killers.listado_3_view AS
SELECT *, [1]+[2]+[3]+[4]+[5]+[6] Total_Primer_Semestre, [7]+[8]+[9]+[10]+[11]+[12] Total_Segundo_Semestre
FROM mario_killers.bonos_farmacia_por_especialidad
PIVOT (COUNT(Codigo_Bono) FOR Mes IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12])) as Bonos_Farmacia_Por_Mes
GO

----------- Listado 4

CREATE VIEW mario_killers.bonos_consulta_distinto_comprador AS
	SELECT Bono_Consulta.id AS ID_Bono,
	       Persona.nombre Nombre,
	       Persona.apellido Apellido,
	       Persona.documento Documento,
	       MONTH(Turno.horario) Mes,
	       YEAR(Turno.horario) Anio
	FROM mario_killers.Atencion
		JOIN mario_killers.Turno ON Turno.id = Atencion.id
		JOIN mario_killers.Bono_Consulta ON Bono_Consulta.id = Atencion.bono_consulta
		JOIN mario_killers.Compra ON Compra.id = Bono_Consulta.compra
		JOIN mario_killers.Afiliado ON Turno.persona = Afiliado.persona
		JOIN mario_killers.Persona ON Persona.id = Afiliado.persona
	WHERE Turno.persona <> Compra.persona
GO

CREATE VIEW mario_killers.bonos_farmacia_distinto_comprador AS
	SELECT Bono_Farmacia.codigo ID_Bono,
	       Persona.nombre Nombre,
	       Persona.apellido Apellido,
	       Persona.documento Documento,
	       MONTH(Turno.horario) Mes,
	       YEAR(Turno.horario) Anio
	FROM mario_killers.Turno
		JOIN mario_killers.Atencion ON Atencion.id = Turno.id
		JOIN mario_killers.Medicamento_Atencion ON Medicamento_Atencion.Atencion = Atencion.id
		JOIN mario_killers.Bono_Farmacia ON Medicamento_Atencion.bono_farmacia = Bono_Farmacia.codigo
		JOIN mario_killers.Compra ON Compra.id = Bono_Farmacia.compra
		JOIN mario_killers.Afiliado ON Afiliado.persona = Turno.persona
		JOIN mario_killers.Persona ON Afiliado.persona = Persona.id
	WHERE Compra.persona <> Turno.persona
GO

CREATE VIEW mario_killers.bonos_distinto_comprador AS
	SELECT ID_Bono, Nombre, Apellido, Documento, Mes, Anio
	FROM mario_killers.bonos_consulta_distinto_comprador
	UNION
	SELECT ID_Bono, Nombre, Apellido, Documento, Mes, Anio
	FROM mario_killers.bonos_farmacia_distinto_comprador
GO

CREATE VIEW mario_killers.listado_4_view AS
	SELECT *, [1]+[2]+[3]+[4]+[5]+[6] Total_Primer_Semestre, [7]+[8]+[9]+[10]+[11]+[12] Total_Segundo_Semestre
	FROM mario_killers.bonos_distinto_comprador
	PIVOT (COUNT(ID_Bono) FOR Mes IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12])) AS Bonos_Pivot
GO

CREATE VIEW mario_killers.AfiliadosABM AS 
SELECT A.persona AS persona, A.grupo_familia AS grupo_familia, A.nro_familiar AS nro_familiar, P.apellido AS apellido, P.nombre AS nombre, P.documento AS documento, GF.plan_medico AS plan_medico, 
		P.direccion AS direccion, P.fecha_nac AS fecha_nac, P.mail AS mail, TD.id AS tipo_doc, P.sexo AS sexo, P.telefono AS telefono, A.cant_hijos AS cant_hijos, A.estado_civil AS estado_civil
FROM mario_killers.Afiliado A JOIN mario_killers.Persona P ON A.persona = P.id
							  JOIN mario_killers.Grupo_Familia GF ON A.grupo_familia = GF.codigo
							  JOIN mario_killers.Tipo_Documento TD ON P.tipo_doc = TD.id
WHERE A.activo = 1
GO

CREATE VIEW mario_killers.ProfesionalABM AS
SELECT PRO.persona AS persona, PRO.matricula AS matricula, P.nombre AS nombre, P.apellido AS apellido, P.documento AS documento, 
		p.direccion AS direccion, P.fecha_nac AS fecha_nac, P.mail AS mail, TD.id AS tipo_doc, P.sexo AS sexo, P.telefono AS telefono
FROM mario_killers.Profesional PRO JOIN mario_killers.Persona P ON PRO.persona = P.id
									JOIN mario_killers.Especialidad_Profesional EP ON EP.profesional = PRO.persona
									JOIN mario_killers.Especialidad E ON E.codigo = EP.especialidad
									JOIN mario_killers.Tipo_Documento TD ON TD.id = P.tipo_doc
WHERE PRO.activo = 1
GROUP BY PRO.persona, PRO.matricula, P.nombre, P.apellido, P.documento, P.direccion, P.fecha_nac, P.mail, TD.id, P.sexo, P.telefono
GO

CREATE VIEW mario_killers.ProfesionalYPersona AS
SELECT pro.matricula AS matricula, per.apellido AS apellido, per.nombre AS nombre, per.id AS codigoPersona, per.direccion AS direccion, per.documento AS documento, per.fecha_nac AS fechaNac, per.mail AS mail, per.sexo AS sexo, per.telefono AS tel, per.tipo_doc AS tipo_doc
FROM mario_killers.Profesional pro JOIN mario_killers.Persona per ON pro.persona = per.id
GO 

CREATE VIEW mario_killers.AfiliadosParaCompra AS 
SELECT A.persona AS persona, A.grupo_familia AS grupo_familia, A.nro_familiar AS nro_familiar, P.apellido AS apellido, P.nombre AS nombre, P.documento AS documento, GF.plan_medico AS plan_medico, 
  P.direccion AS direccion, P.fecha_nac AS fecha_nac, P.mail AS mail, TD.id AS tipo_doc, P.sexo AS sexo, P.telefono AS telefono, A.cant_hijos AS cant_hijos, A.estado_civil AS estado_civil, A.activo AS activo
FROM mario_killers.Afiliado A JOIN mario_killers.Persona P ON A.persona = P.id
         JOIN mario_killers.Grupo_Familia GF ON A.grupo_familia = GF.codigo
         JOIN mario_killers.Tipo_Documento TD ON P.tipo_doc = TD.id
GO

CREATE VIEW mario_killers.BonoYcompra AS
SELECT c.id AS compra, c.fecha AS fecha, bf.codigo AS codigo, bf.plan_medico AS plan_medico, a.grupo_familia AS grupo, bf.activo AS activo, precio_bono_consulta, precio_bono_farmacia
FROM mario_killers.Bono_Farmacia bf
	join mario_killers.Compra c on c.id = bf.compra
	join mario_killers.Afiliado a on a.persona = c.persona
	join mario_killers.Grupo_Familia on Grupo_Familia.codigo = a.grupo_familia
	join mario_killers.Plan_Medico on Plan_Medico.codigo = Grupo_Familia.codigo
GO

CREATE VIEW mario_killers.BonoConsultaYcompra AS
SELECT Compra.id AS compra, Compra.fecha AS fecha, Bono_Consulta.id AS codigo, Bono_Consulta.plan_medico AS plan_medico, Afiliado.grupo_familia AS grupo, Bono_Consulta.activo AS activo, precio_bono_consulta, precio_bono_farmacia
FROM mario_killers.Bono_Consulta
	join mario_killers.Compra ON Compra.id = Bono_Consulta.compra
	join mario_killers.Afiliado on Afiliado.persona = Compra.persona
	join mario_killers.Grupo_Familia on Grupo_Familia.codigo = Afiliado.grupo_familia
	join mario_killers.Plan_Medico on Plan_Medico.codigo = Grupo_Familia.codigo
GO

CREATE VIEW mario_killers.TurnosPorPaciente AS
SELECT T.id AS id, T.persona AS paciente_id, PA.nombre + ' ' + PA.apellido AS paciente, 
	   T.profesional AS profesional_id, PP.nombre + ' ' + PP.apellido AS profesional, T.horario AS fecha, T.especialidad AS especialidad
FROM mario_killers.Turno T JOIN mario_killers.Persona PA ON T.persona = PA.id
						   JOIN mario_killers.Persona PP ON T.profesional = PP.id
WHERE activo = 1
GO
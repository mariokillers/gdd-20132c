----------------------LOGIN------------------------------------------------------
--STORE PROCEDURE PARA LOGIN
CREATE PROCEDURE mario_killers.login (@userName varchar, @password char(64), @ret int)
AS
	BEGIN
		IF(db.mario_killers.intentoLogin(@userName, @password) = 1)
			BEGIN
				UPDATE mario_killers.Usuario
				SET intentos_login = 0	
				WHERE @userName = nombre
				SET @ret = 1
		END
		ELSE
			BEGIN
			UPDATE mario_killers.Usuario
			SET intentos_login = intentos_login + 1
			WHERE @userName = nombre
			SET @ret = 0
		END
END

--INTENTA LOGEARSE
CREATE FUNCTION mario_killers.intentoLogin(@userName varchar, @password char(64))
RETURNS bit
	BEGIN
		IF(EXISTS(SELECT nombre, pw
				  FROM mario_killers.Usuario
				  WHERE nombre = @userName AND pw =@password)) RETURN 1
		ELSE RETURN 0
END
	
--SE EJECUTA CADA VEZ QUE SE ACTUALIZAN LOS INTENTOS DE LOGIN
CREATE TRIGGER mario_killers.intentosLogin
ON mario_killers.Usuario
FOR UPDATE
AS
	BEGIN
		IF(update(intentos_login))
			BEGIN
				UPDATE mario_killers.Usuario
				SET activo = 0, intentos_login = 0
				WHERE inserted.activo = 0
		END
END

----------------------------------------------------------------------------

---------------------QUERY QUE PIDE URI--------------------------------		

--OBTENER TODOS LOS ROLES Y FUNCIONALIDADES
SELECT R.id, R.rol, F.id, F.nombre
FROM mario_killers.Rol R JOIN mario_killers.Funcionalidad_Rol FM ON R.id = FM.rol
								   JOIN mario_killers.Funcionalidad F ON FM.funcionalidad = F.id
WHERE R.activo = 1

--OBTENER TODOS LOS ROLES (SOLO ID, NOMBRE)
SELECT id, rol
FROM mario_killers.Rol
WHERE activo = 1

--TRAER TODAS LAS FUNCIONALIDADES A PARTIR DE UN ID DE ROL (@rol)
SELECT F.id, F.nombre
FROM mario_killers.Rol R JOIN mario_killers.Funcionalidad_Rol FM ON R.id = FM.rol
								   JOIN mario_killers.Funcionalidad F ON FM.funcionalidad = F.id
WHERE R.id = @rol


--DESCRIPCION DE UN TIPO DE ESPECIALIDAD A PARTIR DE UN CODIGO DE TIPO DE ESP (@codigo)
SELECT descripcion
FROM mario_killers.Tipo_Especialidad
WHERE @codigo = codigo		

--INSERT PERSONA
INSERT INTO mario_killers.Persona
VALUES (@id, @nombre, @apellido, @documento, @fecha_nac, @direccion, @telefono, @mail)

--TRAER MEDICAMENTOS
SELECT *
FROM mario_killers.Medicamento

--BAJA LOGICA AFILIADO A PARTIR DE UN AFILIADO (@persona)
UPDATE mario_killers.Afiliado
SET activo = 0
WHERE persona = @persona

--BAJA LOGICA PROFESIONAL A PARTIR DE UN PROFESIONAL (@persona)
UPDATE mario_killers.Profesional
SET activo = 0
WHERE persona = @persona

--BUSCAR ROLES A PARTIR DE ALGUN PATRON DE CARACTERES (@txt)
SELECT rol
FROM mario_killers.Rol
WHERE rol LIKE '%' + @txt + '%' AND activo = 1

--PRECIO BONO CONSULTA A PARTIR DE UN AFILIADO (@persona)
SELECT PM.precio_bono_consulta
FROM mario_killers.Plan_Medico PM JOIN mario_killers.Grupo_Familia GF ON GF.plan_medico = PM.codigo
								  JOIN mario_killers.Afiliado A ON A.grupo_familia = GF.codigo
WHERE A.persona = @persona

--PRECIO BONO FARMACIA A PARTIR DE UN AFILIADO (@persona)
SELECT PM.precio_bono_farmacia
FROM mario_killers.Plan_Medico PM JOIN mario_killers.Grupo_Familia GF ON GF.plan_medico = PM.codigo
								  JOIN mario_killers.Afiliado A ON A.grupo_familia = GF.codigo
WHERE A.persona = @persona

--PROFESIONALES A PARTIR DE UNA ESPECIALIDAD (@esp)
SELECT PRO.persona, PRO.matricula, E.descripcion
FROM mario_killers.Profesional PRO JOIN mario_killeres.Especialidad_Profesional EP ON PRO.persona = EP.profesional 
				JOIN mario_killers.Especialidad E ON EP.especialidad = E.codigo
WHERE E.codigo = @esp

----------------------------------------------------------------------------

--TRIGGER BAJA LOGICA AFILIADO
CREATE TRIGGER mario_killers.bajaAfiliado
ON mario_killers.Afiliado
FOR UPDATE
AS
	BEGIN
		IF(update(activo))
			BEGIN
				--REGISTRO LA BAJA LOGICA
				INSERT INTO mario_killers.Baja_Afiliado
				SELECT persona, getdate()
				FROM inserted i
				WHERE i.activo = 0
				
				--BAJA LOGICA DE LOS TURNOS DEL AFILIADO
				UPDATE mario_killers.Turno
				SET activo = 0
				WHERE inserted.persona = persona
				
				--BAJA LOGICA DE LAS RECETAS DEL AFILIADO
				UPDATE mario_killers.Receta
				SET activo = 0
				WHERE inserted.persona = (SELECT T.persona
										  FROM mario_killers.Receta R JOIN mario_killers.Atencion A ON R.atencion = A.turno
										  JOIN mario_killers.Turno T ON A.turno = T.id)
		END
END			


--TRIGGER BAJA LOGICA PROFESIONAL
CREATE TRIGGER mario_killers.bajaProfesional
ON mario_killers.Profesional
FOR UPDATE
AS
	BEGIN
		IF(update(activo))
			BEGIN
				--BAJA LOGICA DE LOS TURNOS DEL PROFESIONAL
				UPDATE mario_killers.Turno
				SET activo = 0
				WHERE inserted.persona = profesional			
		END
END 


--STORE PROCEDURE DE MODIFICACION DE PLAN DEL GRUPO
CREATE PROCEDURE mario_killers.modificacionPlan (@grupo_familia numeric, @plan int, @motivo varchar)
AS
	BEGIN
		UPDATE mario_killers.Grupo_Familia
		SET plan_medico = @plan
		WHERE grupo_familia = @grupo_familia
		
		SET @fecha = getdate()
		INSERT INTO mario_killers.Modificaciones_Grupo
		VALUES (@grupo_familia, @plan, @fecha, @motivo)		
END


--CALCULO DE GASTO TOTAL DE LA COMPRA
CREATE FUNCTION mario_killers.costoCompra(@compra int)
RETURNS int
	BEGIN
		RETURN (SELECT SUM(PM.precio_bono_consulta)+SUM(PM.precio_bono_farmacia)
				FROM mario_killers.Bono_Consulta BC JOIN mario_killers.Bono_Farmacia BF ON BC.compra = BF.compra
					JOIN mario_killer.Plan_Medico PM ON PM.codigo = BF.plan_medico AND PM.codigo = BC.plan_medico
				WHERE BC.compra = @compra AND BF.compra = @compra
				GROUP BY PM.precio_bono_consulta, PM.precio_bono_farmacia)
END

--CALCULO CANTIDAD BONOS COMPRADOS
CREATE FUNCTION mario_killers.cantidadCompra(@compra int)
RETURNS int
	BEGIN
		RETURN (SELECT COUNT(*)
				FROM mario_killers.Bono_Consulta BC JOIN mario_killers.Bono_Farmacia BF ON BC.compra = BF.compra
				WHERE BC.compra = @compra AND BF.compra = @compra)
END


--TRIGGER REGISTRO COMPRA
CREATE TRIGGER mario_killers.registrarCompra
ON mario_killers.Compra
FOR INSERT
AS
	BEGIN
		SET @compra = (SELECT id FROM mario_killers.Compra WHERE id = inserted.id)
		SET @persona = (SELECT persona FROM inserted i WHERE i.compra = @compra)
		UPDATE mario_killers.Registro_Compras
		SET monto = db.mario_killers.costoCompra(@compra), cant = db.mario_killers.cantidadCompra(@compra), persona = @persona
		WHERE grupo_familia = @grupo_familia
END


--VER SI UN AFILIADO PUEDE USAR UN BONO EN PARTICULAR (BONO CONSULTA)
--CONSIDERAR: que no haya cambiado de plan, que pertenezca al mismo grupo que el que lo compro.
--USAR: (SELECT GF.plan_medico FROM mario_killers.Grupo_Familia GF JOIN mario_killers.Afiliado A ON A.grupo_familia = GF.id WHERE A.id = @persona)
--(SELECT plan_medico FROM mario_killers.Bono_Consulta WHERE id = @bono)
CREATE FUNCTION puedeUsarBonoConsulta(@persona int, @bono int)
RETURNS bit
	BEGIN
		--ToDo
END

--FUNCTION VALIDACION TURNO CON PROFESIONAL
CREATE FUNCTION mario_killers.validarTurno (@persona int, @profesional int, @fecha datetime)
RETURNS bit
	BEGIN
		RETURN (NOT EXISTS(SELECT * FROM mario_killers.Turno WHERE persona = @persona 		AND profesional = @profesional AND horario = @fecha))
END

--STORE PROCEDURE REGISTRAR BONO CONSULTA
CREATE PROCEDURE mario_killers.registrarBono (@bono int, @persona int, @profesional int, @fecha datetime)
	BEGIN
		SET @turno = (SELECT id FROM mario_killers.Turno WHERE id = (SELECT id FROM mario_killers.Turno WHERE persona = @persona AND profesional = @profesional AND horario = @fecha))
		UPDATE mario_killers.Bono_Consulta
		SET turno = @turno
		WHERE id = @bono
		
		
END

--TRIGGER REGISTRO LLEGADA
CREATE TRIGGER mario_killers.registrarLlegada
ON mario_killers.Bono_Consulta
FOR UPDATE
AS
	BEGIN
		IF(update(turno))
			BEGIN
				SET @turno = (SELECT id FROM mario_killers.Turno WHERE id = inserted.turno)		
				UPDATE mario_killers.Turno
				SET horario_llegada = getdate()
				WHERE turno = @turno
		END
END


--ToDo
--FUNCTION puedeUsarBonoFarmacia(@persona int, @bono int)
--TRIGGER LLEGADA A LA CONSULTA (ToDo COMPLETAR BONO CONSULTA)
--TRIGGER VALIDAR COMPRA (SI EL AFILIADO ESTA ACTIVO O NO) (INSTEAD OF O BEFOR??)
--FECHAS DE LA AGENDA DEL PROFESIONAL A PARTIR DE UN PROFESIONAL (@persona) (VER TEMA FECHAS)
--VER SI CONVIENE UNIFICAR EL REGISTRO DE LA LLEGADA Y EL REGISTRO DEL BONO



				 
							 
							 
							 
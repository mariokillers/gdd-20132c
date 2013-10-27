CREATE FUNCTION mario_killers.roles_usuario(@username varchar(255))
RETURNS @roles TABLE (rol int, nombre varchar(255)) AS
BEGIN
	INSERT INTO @roles
		SELECT id, nombre
		FROM
			mario_killers.Roles_Usuario JOIN mario_killers.Rol
			ON Roles_Usuario.rol = Rol.id
		WHERE Roles_Usuario.usuario = @username
	RETURN
END
GO
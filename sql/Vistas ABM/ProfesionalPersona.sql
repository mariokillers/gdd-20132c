CREATE VIEW mario_killers.ProfesionalYPersona AS
SELECT pro.matricula AS matricula, per.apellido AS apellido, per.nombre AS nombre, per.id AS codigoPersona
FROM mario_killers.Profesional pro JOIN mario_killers.Persona per ON pro.persona = per.id
GO 


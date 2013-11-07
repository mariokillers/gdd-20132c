CREATE VIEW mario_killers.ProfesionalYPersona AS
SELECT pro.matricula AS matricula, per.apellido AS apellido, per.nombre AS nombre, per.id AS codigoPersona, per.direccion AS direccion, per.documento AS documento, per.fecha_nac AS fechaNac, per.mail AS mail, per.sexo AS sexo, per.telefono AS tel, per.tipo_doc AS tipo_doc
FROM mario_killers.Profesional pro JOIN mario_killers.Persona per ON pro.persona = per.id
GO 


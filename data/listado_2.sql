SELECT *, [1]+[2]+[3]+[4]+[5]+[6] Total_Primer_Semestre, [7]+[8]+[9]+[10]+[11]+[12] Total_Segundo_Semestre
FROM ( SELECT Bono_Farmacia.codigo AS ID_Bono_Farmacia,
       MONTH(Compra.fecha) Mes,
       YEAR(Compra.fecha) AS Anio,
       Persona.nombre Nombre,
       Persona.apellido Apellido,
       Persona.documento Documento
       FROM mario_killers.Bono_Farmacia
		JOIN mario_killers.Compra ON Bono_Farmacia.compra = Compra.id
		JOIN mario_killers.Afiliado ON Compra.persona = Afiliado.persona
		JOIN mario_killers.Persona ON Persona.id = Afiliado.persona 
	   --WHERE GETDATE() < Compra.fecha + 60 PONER ESTO EN LA APP
	   ) AS Pivot_source
PIVOT (COUNT(ID_Bono_Farmacia) FOR Mes IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12])) as Bonos_Por_Mes
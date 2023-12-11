create procedure insertarAlumno
@Name nvarchar(50),
@Email nvarchar(50),
@Foto nvarchar(50),
@curso int
as
begin
	insert into Alumnos (Nombre, Email, Foto , CursoId)
	values (@Name, @Email, @Foto, @curso)
end
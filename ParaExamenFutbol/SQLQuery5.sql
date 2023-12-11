create procedure GetEquipoById
@Id int
as begin
	select * from Equipo
	where Id = @Id
end

execute GetEquipoById 2
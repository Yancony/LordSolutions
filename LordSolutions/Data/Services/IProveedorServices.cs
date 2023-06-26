using LordSolutions.Data.Request;
using LordSolutions.Data.Response;

namespace LordSolutions.Data.Services
{
	public interface IProveedorServices
	{
		Task<Result<List<ProveedorResponse>>> Consultar(string filtro);
		Task<Result> Crear(ProveedorRequest request);
		Task<Result> Eliminar(ProveedorRequest request);
		Task<Result> Modificar(ProveedorRequest request);
	}
}
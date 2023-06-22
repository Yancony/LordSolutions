using LordSolutions.Data.Request;

namespace LordSolutions.Data.Services
{
	public interface IFacturaServices
	{
		Task<Result<List<FacturaResponse>>> Consultar(string filtro);
		Task<Result> Crear(FacturaRequest request);
		Task<Result> Eliminar(FacturaRequest request);
		Task<Result> Modificar(FacturaRequest request);
	}
}
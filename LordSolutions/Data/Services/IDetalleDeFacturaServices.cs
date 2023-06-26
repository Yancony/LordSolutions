using LordSolutions.Data.Request;
using LordSolutions.Data.Response;

namespace LordSolutions.Data.Services
{
	public interface IDetalleDeFacturaServices
	{
		Task<Result<List<DetalleDeFacturaResponse>>> Consultar(string filtro);
		Task<Result> Crear(DetalleDeFacturaRequest request);
		Task<Result> Eliminar(DetalleDeFacturaRequest request);
		Task<Result> Modificar(DetalleDeFacturaRequest request);
	}
}
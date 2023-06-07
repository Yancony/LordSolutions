using LordSolutions.Data.Request;
using LordSolutions.Data.Resquest;

namespace LordSolutions.Data.Services
{
    public interface IClienteServices
    {
        Task<Result<List<ClienteResponse>>> Consultar(string filtro);
        Task<Result> Crear(ClienteRequest request);
        Task<Result> Eliminar(ClienteRequest request);
        Task<Result> Modificar(ClienteRequest request);
    }
}
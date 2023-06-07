using System.Net.WebSockets;
using LordSolutions.Data.Context;
using LordSolutions.Data.Entities;
using LordSolutions.Data.Request;
using LordSolutions.Data.Resquest;
using Microsoft.EntityFrameworkCore;

namespace LordSolutions.Data.Services
{
    public class Result
    {
        public bool Success{ get; set; }
        public string? Message{ get; set; }

    }
    public class Result<T>
    {
        public bool Success{ get; set; }
        public string? Message{ get; set; }
        public T? Data { get; set; }

    }
    public class ClienteServices : IClienteServices
    {
        private readonly ILordSolutionsDbContext dbContext;

        public ClienteServices(ILordSolutionsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result> Crear(ClienteRequest request)
        {
            try
            {
                var cliente = Cliente.Crear(ClienteRequest);
                dbContext.Clientes.Add(cliente);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result { Message = E.Message, Success = false };

            }
        }
        public async Task<Result> Modificar(ClienteRequest request)
        {
            try
            {
                var cliente = dbContext.Clientes.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (cliente == null)
                    return new Result { Message = "No se encontro el cliente", Success = false };

                if (cliente.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result { Message = E.Message, Success = false };

            }
        }
        public async Task<Result> Eliminar(ClienteRequest request)
        {
            try
            {
                var cliente = dbContext.Clientes.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (cliente == null)
                    return new Result { Message = "No se encontro el cliente", Success = false };

                dbContext.Clientes.Remove(cliente);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result { Message = E.Message, Success = false };

            }
        }
        public async Task<Result<List<ClienteResponse>>> Consultar(string filtro)
        {
            try
            {
                var clientes = await dbContext.Clientes.Where(c =>
                (c.Nombre + " " + c.Telefono + " " + c.Direccion).ToLower()
                .Contains(filtro.ToLower))
                    )
                    .Select(c => c.ToResponse())
                    .ToListAsync();
                return new Result<List<ClienteResponse>>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = clientes
                };
            }
            catch (Exception E)
            {
                return new Result<List<ClienteResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }
    }
}

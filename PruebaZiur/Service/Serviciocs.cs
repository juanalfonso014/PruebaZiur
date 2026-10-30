using System.Net.Http.Headers;
using System.Net.Http.Json;
using PruebaZiur.Models;

namespace PruebaZiur.Service
{
    public class Serviciocs
    {
        private readonly HttpClient _httpClient;

        public Serviciocs(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;

            var token = configuration["ZiurApi:Token"];

            if (string.IsNullOrWhiteSpace(token))
            {
                throw new InvalidOperationException(
                    "No se encontró el token. Configúralo en User Secrets como ZiurApi:Token.");
            }

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<List<InventarioDto>> ObtenerMovimientosAsync(
            CancellationToken cancellationToken = default)
        {
            var movimientos = await _httpClient.GetFromJsonAsync<List<InventarioDto>>(
                string.Empty,
                cancellationToken);

            return movimientos ?? [];
        }
    }
}

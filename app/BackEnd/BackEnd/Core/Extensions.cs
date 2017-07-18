using BackEnd.Service;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BackEnd.Core
{
    public static class Extensions
    {
        public static void AdicionarPaginacao(this HttpResponse response, Paginacao paginacao)
        {
            response.Headers.Add("Paginacao", Newtonsoft.Json.JsonConvert.SerializeObject(paginacao));

            response.Headers.Add("access-control-expose-headers", "Paginacao");
        }

        public static Paginacao ObterPaginacao(this HttpRequest request)
        {
            if (!string.IsNullOrEmpty(request.Headers["Paginacao"]))
                return JsonConvert.DeserializeObject<Paginacao>(request.Headers["Paginacao"]);
            return null;
        }
    }
}

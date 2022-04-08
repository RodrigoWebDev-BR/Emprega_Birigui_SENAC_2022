// Licenciado para a .NET Foundation sob um ou mais contratos.
// A .NET Foundation licencia este arquivo para você sob a licença do MIT.
#nullable disable

using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Emprega.Areas.Identity.Pages
{
    /// <resumo>
    /// Estas APIs oferecem suporte à infraestrutura de interface do usuário padrão do ASP.NET Core Identity e não se destinam a serem usadas
    /// diretamente do seu código. Estas APIs podem ser alteradas ou removidas em versões futuras.
    /// <resumo>

    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {

        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}

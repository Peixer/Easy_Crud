using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BackEnd.Model;

namespace BackEnd.ViewModel
{
    public class CandidatoViewModel : IValidatableObject
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Skype { get; set; }
        public string Telefone { get; set; }
        public string Linkedin { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Portfolio { get; set; }

        //Disponibilidade
        public bool AteQuatroHoras { get; set; }
        public bool AteSeisHoras { get; set; }
        public bool AteOitoHoras { get; set; }
        public bool MaisDeOitoHoras { get; set; }
        public bool FinaisDeSemana { get; set; }
        //HorarioDeTrabalho
        public bool Manha { get; set; }
        public bool Tarde { get; set; }
        public bool Noite { get; set; }
        public bool Madrugada { get; set; }
        public bool Comercial { get; set; }

        public double PretensaoSalarial { get; set; }
        public string InformacoesBanco { get; set; }
        public string LinkCrud { get; set; }

        public TipoNivelConhecimento ConhecimentoEmIonic { get; set; }
        public TipoNivelConhecimento ConhecimentoEmAndroid { get; set; }
        public TipoNivelConhecimento ConhecimentoEmIOS { get; set; }
        public TipoNivelConhecimento ConhecimentoEmHtml { get; set; }
        public TipoNivelConhecimento ConhecimentoEmCss { get; set; }
        public TipoNivelConhecimento ConhecimentoEmBootstrap { get; set; }
        public TipoNivelConhecimento ConhecimentoEmJQuery { get; set; }
        public TipoNivelConhecimento ConhecimentoEmAngularJS { get; set; }
        public TipoNivelConhecimento ConhecimentoEmJava { get; set; }
        public TipoNivelConhecimento ConhecimentoEmAspNetMvc { get; set; }
        public TipoNivelConhecimento ConhecimentoEmC { get; set; }
        public TipoNivelConhecimento ConhecimentoEmCPlusPlus { get; set; }
        public TipoNivelConhecimento ConhecimentoEmCake { get; set; }
        public TipoNivelConhecimento ConhecimentoEmDJango { get; set; }
        public TipoNivelConhecimento ConhecimentoEmMajento { get; set; }
        public TipoNivelConhecimento ConhecimentoEmPHP { get; set; }
        public TipoNivelConhecimento ConhecimentoEmWordpress { get; set; }
        public TipoNivelConhecimento ConhecimentoEmPython { get; set; }
        public TipoNivelConhecimento ConhecimentoEmRuby { get; set; }
        public TipoNivelConhecimento ConhecimentoEmSQLServer { get; set; }
        public TipoNivelConhecimento ConhecimentoEmMySql { get; set; }
        public TipoNivelConhecimento ConhecimentoEmSalesforce { get; set; }
        public TipoNivelConhecimento ConhecimentoEmPhotoshop { get; set; }
        public TipoNivelConhecimento ConhecimentoEmIllustrator { get; set; }
        public TipoNivelConhecimento ConhecimentoEmSEO { get; set; }
        public string ConhecimentoEmOutroFramework { get; set; }

        public IEnumerable<ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            var validator = new CandidatoViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}

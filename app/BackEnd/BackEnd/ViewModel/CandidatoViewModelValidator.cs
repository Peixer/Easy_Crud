using FluentValidation;

namespace BackEnd.ViewModel
{
    public class CandidatoViewModelValidator : AbstractValidator<CandidatoViewModel>
    {
        public CandidatoViewModelValidator()
        {
            RuleFor(s => s.Nome).NotEmpty().WithMessage("Nome precisa ser informado");
            RuleFor(s => s.Email).NotEmpty().WithMessage("Email precisa ser informado");
            RuleFor(s => s.Skype).NotEmpty().WithMessage("Skype precisa ser informado");
            RuleFor(s => s.Telefone).NotEmpty().WithMessage("Telefone precisa ser informado");
            RuleFor(s => s.Cidade).NotEmpty().WithMessage("Cidade precisa ser informado");
            RuleFor(s => s.Estado).NotEmpty().WithMessage("Estado precisa ser informado");
            RuleFor(s => s.Disponibilidade).NotEmpty().WithMessage("Disponibilidade de trabalho precisa ser informado");
            RuleFor(s => s.HorarioDeTrabalho).NotEmpty().WithMessage("Horário de trabalho precisa ser informado");
            RuleFor(s => s.PretensaoSalarial).NotEmpty().WithMessage("Pretensão salarial precisa ser informado");

            RuleFor(s => s.ConhecimentoEmIonic).NotEmpty().WithMessage("Ionic precisa ser informado");
            RuleFor(s => s.ConhecimentoEmAndroid).NotEmpty().WithMessage("Android precisa ser informado");
            RuleFor(s => s.ConhecimentoEmIOS).NotEmpty().WithMessage("IOS precisa ser informado");
            RuleFor(s => s.ConhecimentoEmBoostrap).NotEmpty().WithMessage("Boostrap precisa ser informado");
            RuleFor(s => s.ConhecimentoEmJQuery).NotEmpty().WithMessage("JQuery precisa ser informado");
            RuleFor(s => s.ConhecimentoEmAngularJS).NotEmpty().WithMessage("AngularJS precisa ser informado");
            RuleFor(s => s.ConhecimentoEmAspNetMvc).NotEmpty().WithMessage("Asp.net MVC precisa ser informado");
            RuleFor(s => s.ConhecimentoEmPHP).NotEmpty().WithMessage("PHP precisa ser informado");
            RuleFor(s => s.ConhecimentoEmWordpress).NotEmpty().WithMessage("Wordpress precisa ser informado");
        }
    }
}

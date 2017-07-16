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
            RuleFor(s => s.PretensaoSalarial).NotEmpty().WithMessage("Pretensão salarial precisa ser informado");                      
        }
    }
}

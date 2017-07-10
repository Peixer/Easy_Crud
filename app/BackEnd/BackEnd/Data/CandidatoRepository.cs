using BackEnd.Model;

namespace BackEnd.Data
{
    public class CandidatoRepository : EntityBaseRepository<Candidato>, ICandidatoRepository
    {
        public CandidatoRepository(CandidatoContext context) : base(context)
        {
        }
    }
}

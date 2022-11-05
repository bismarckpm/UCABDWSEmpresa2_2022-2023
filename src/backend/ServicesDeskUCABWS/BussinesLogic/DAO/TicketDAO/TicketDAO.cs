using ServicesDeskUCABWS.BussinesLogic.Mappers;
using ServicesDeskUCABWS.Data;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO
{
    public class TicketDAO : ITicketDAO
    {
        private readonly DataContext _dataContext;
        private readonly TicketMapper _mapper;

        public TicketDAO(DataContext dataContext, TicketMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
    }
}

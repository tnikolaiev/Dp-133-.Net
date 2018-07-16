

//using Ras.Infastructure.Mapping;

//namespace Ras.BLL.Implementation
//{
//    internal class GroupHistoryService : Service, IGroupHistoryService
//    {
//        private readonly ITypeMapper<History, GroupHistoryDTO> _mapper;

//        public GroupHistoryService(IUnitOfWork unitOfWork, ITypeMapper<History, GroupHistoryDTO> mapper)
//            : base(unitOfWork)
//        {
//            _mapper = mapper;
//        }

//        public IEnumerable<GroupHistoryDTO> GetAll(int academyId)
//        {
//            var entities = unitOfWork.HistoryRepository.All.Where(h => h.AcademyId == academyId).ToArray();
//            var dtos = _mapper.Map(entities);
//            return dtos;
//        }
//    }
//}
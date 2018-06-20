using Ras.DAL;

namespace Ras.BLL.Implementation
{
    internal class Service
    {
        protected IUnitOfWork unitOfWork;

        public Service(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
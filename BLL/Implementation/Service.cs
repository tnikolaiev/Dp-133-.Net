using Ras.DAL;

namespace Ras.BLL.Implementation
{
    public abstract class Service
    {
        protected IUnitOfWork unitOfWork;

        public Service(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
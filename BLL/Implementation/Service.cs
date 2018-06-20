using System;
using System.Collections.Generic;
using System.Text;
using Ras.DAL;

namespace Ras.BLL.Implementation
{
    class Service
    {
        protected IUnitOfWork unitOfWork;

        public Service(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}

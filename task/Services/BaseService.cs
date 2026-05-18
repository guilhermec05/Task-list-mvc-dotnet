using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using task.Repositories.Impl;

namespace task.Services
{
   
    public abstract class BaseService
    {
        protected readonly IUnityOfWork _unitOfWork;

        public BaseService(IUnityOfWork unityOfWork)
        {
            _unitOfWork = unityOfWork;
        }
    }
}
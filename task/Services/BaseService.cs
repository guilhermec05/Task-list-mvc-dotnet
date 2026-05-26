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
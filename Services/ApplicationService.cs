using log4net;

namespace Backend.Services
{
    public class ApplicationService : IApplicationService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ApplicationService));
        IBusinessLogic _buisnessLogic;

        public ApplicationService(IBusinessLogic buisnessLogic)
        {
            _buisnessLogic = buisnessLogic;
        }

        public void Run()
        {
            _buisnessLogic.Execution();
        }

        
    }
}


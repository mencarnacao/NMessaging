using metitus.NMessaging.Service.Contracts;

namespace metitus.NMessaging.Service.Worker
{
    public class WorkerGateway : IWorkerGateway
    {
        //////////////////////////////////
        //            MEMBERS           //
        //////////////////////////////////

        private IQueueRepository _oQueueRepository = default(IQueueRepository);


        //////////////////////////////////
        //           PROPERTIES         //
        //////////////////////////////////

        private IQueueRepository QueueRepository
        {
            set
            {
                _oQueueRepository = value;
            }
        }

        //////////////////////////////////
    }
}
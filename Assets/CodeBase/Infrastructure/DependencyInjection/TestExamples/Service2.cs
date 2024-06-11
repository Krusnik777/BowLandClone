using UnityEngine;

namespace CodeBase.Infrastructure.DependencyInjection
{
    public class Service2 : IService
    {
        public Service2(Service1 service1)
        {
            Debug.Log("Service2 Created with dependency of " + service1);
        }
    }
}

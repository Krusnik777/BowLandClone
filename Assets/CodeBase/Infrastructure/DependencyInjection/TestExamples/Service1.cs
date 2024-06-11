using UnityEngine;

namespace CodeBase.Infrastructure.DependencyInjection
{
    public class Service1 : IService
    {
        public Service1()
        {
            Debug.Log("Service1 Created");
        }
    }
}

using CodeBase.Infrastructure.DependencyInjection;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.Purchasing;

namespace CodeBase.Services
{
    public interface IIAPService : IService
    {
        event UnityAction EventOnInitialized;

        bool IsInitialized { get; }

        List<ProductDescription> GetProductDescriptions();

        void Initialize();
        void StartPurchase(string purchaseId);
        void ProcessPurchase(Product purchasedProduct);
    }
}

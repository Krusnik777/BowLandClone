using CodeBase.Data;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.Purchasing;

namespace CodeBase.Services
{
    public class IAPService : IIAPService
    {
        private const string _NoAdsId = "no_ads";
        private const string _SmallCoinsPackId = "small_coins_pack";

        public event UnityAction EventOnInitialized;

        private IProgressProvider progressProvider;
        private IProgressSaver progressSaver;

        private UnityIAPProvider unityIAPProvider;

        public bool IsInitialized => unityIAPProvider.IsInitialized;

        public IAPService(IProgressProvider progressProvider, IProgressSaver progressSaver)
        {
            this.progressProvider = progressProvider;
            this.progressSaver = progressSaver;
        }

        public List<ProductDescription> GetProductDescriptions()
        {
            List<ProductDescription> productDescriptions = new List<ProductDescription>();

            for (int i = 0; i < unityIAPProvider.ProductConfigs.Count; i++)
            {
                ProductConfig config = unityIAPProvider.ProductConfigs[i];

                BoughtIAP boughtIAP = progressProvider.PlayerProgress.PurchaseData.BoughtIAPs.Find(x => x.ProductId == config.Id);

                if (boughtIAP != null && config.Type == ProductType.NonConsumable) continue;

                ProductDescription productDescription = new ProductDescription()
                {
                    Id = config.Id,
                    Product = unityIAPProvider.Products[i],
                    ProductConfig = config
                };

                productDescriptions.Add(productDescription);
            }

            return productDescriptions;
        }

        public void Initialize()
        {
            unityIAPProvider = new UnityIAPProvider();
            unityIAPProvider.Initialize(this);
            unityIAPProvider.EventOnInitialized += () => EventOnInitialized?.Invoke();
        }

        public void StartPurchase(string purchaseId)
        {
            unityIAPProvider.StartPurchase(purchaseId);
        }

        public void ProcessPurchase(Product product)
        {
            ProductConfig productConfig = unityIAPProvider.ProductConfigs.Find(x => x.Id == product.definition.id);

            progressProvider.PlayerProgress.PurchaseData.AddPurchase(productConfig.Id);

            PurchaseProcessing(productConfig);

            progressSaver.SaveProgress();
        }

        private void PurchaseProcessing(ProductConfig config)
        {
            if (config.Id == _NoAdsId)
            {
                // TODO
            }

            if (config.Id == _SmallCoinsPackId)
            {
                progressProvider.PlayerProgress.HeroWallet.AddCoins(config.Quantity);
            }
        }
    }
}

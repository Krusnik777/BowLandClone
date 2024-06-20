using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

namespace CodeBase.Services
{
    public class UnityIAPProvider : IDetailedStoreListener
    {
        public event UnityAction EventOnInitialized;

        public List<ProductConfig> ProductConfigs = new List<ProductConfig>();
        public List<Product> Products = new List<Product>();

        private IStoreController storeController;
        private IExtensionProvider extensionProvider;
        private IIAPService iAPservice;

        public bool IsInitialized => storeController != null && extensionProvider != null;

        public void Initialize(IIAPService iAPservice)
        {
            this.iAPservice = iAPservice;

            ConfigurationBuilder builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

            ProductCatalog productCatalog = ProductCatalog.LoadDefaultCatalog();

            foreach(ProductCatalogItem item in productCatalog.allProducts)
            {
                builder.AddProduct(item.id,item.type);

                ProductConfigs.Add(new ProductConfig()
                {
                    Id = item.id,
                    Type = item.type,
                    Quantity = GetQuantity(item),
                    Price = item.googlePrice.value,
                    Title = item.defaultDescription.Title
                });
            }

            UnityPurchasing.Initialize(this, builder);
        }

        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            storeController = controller;
            extensionProvider = extensions;

            for (int i = 0; i < controller.products.all.Length; i++)
            {
                Products.Add(controller.products.all[i]);
            }

            EventOnInitialized?.Invoke();

            Debug.Log("IAP Initialized");
        }

        public void StartPurchase(string productId)
        {
            storeController.InitiatePurchase(productId);
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
        {
            Debug.Log("Process Purchase");

            iAPservice.ProcessPurchase(purchaseEvent.purchasedProduct);

            return PurchaseProcessingResult.Complete;
        }

        public void OnInitializeFailed(InitializationFailureReason error)
        {
            Debug.Log("Initialize Failed");
        }

        public void OnInitializeFailed(InitializationFailureReason error, string message)
        {
            Debug.Log("Initialize Failed: " + message);
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
        {
            Debug.Log("Purchase of " + product.definition.id + " Failed: " + failureDescription.message);
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            Debug.Log("Purchase of " + product.definition.id + " Failed");
        }

        private int GetQuantity(ProductCatalogItem item)
        {
            int quantity = 0;

            foreach (var payout in item.Payouts)
            {
                quantity = (int)payout.quantity;
            }

            return quantity;
        }
    }
}

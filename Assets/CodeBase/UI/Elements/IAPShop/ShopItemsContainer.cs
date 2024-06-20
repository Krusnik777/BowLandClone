using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Services;
using CodeBase.UI.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace CodeBase.UI.Elements
{
    public class ShopItemsContainer : MonoBehaviour
    {
        [SerializeField] private GameObject[] m_unavailableObjects;
        [SerializeField] private Transform m_parent;

        private IIAPService iAPService;
        private IProgressProvider progressProvider;
        private IUIFactory uIFactory;

        [Inject]
        public void Construct(IIAPService iAPService, IProgressProvider progressProvider, IUIFactory uIFactory)
        {
            this.iAPService = iAPService;
            this.progressProvider = progressProvider;
            this.uIFactory = uIFactory;
        }

        private void Start()
        {
            progressProvider.PlayerProgress.PurchaseData.EventOnChanged += UpdateAvailableItems;

            UpdateAvailableItems();
        }

        private void OnDestroy()
        {
            progressProvider.PlayerProgress.PurchaseData.EventOnChanged -= UpdateAvailableItems;
        }

        private void UpdateAvailableItems()
        {
            for (int i = 0; i < m_unavailableObjects.Length; i++)
            {
                m_unavailableObjects[i].SetActive(!iAPService.IsInitialized);
            }

            if (!iAPService.IsInitialized) return;

            foreach(Transform child in m_parent)
            {
                Destroy(child.gameObject);
            }

            ProductDescription[] productDescriptions = iAPService.GetProductDescriptions().ToArray();

            CreateShopItemAsync(productDescriptions);
        }

        private async void CreateShopItemAsync(ProductDescription[] productDescriptions)
        {
            for (int i = 0; i < productDescriptions.Length; i++)
            {
                ShopItem shopItem = await uIFactory.CreateShopItemAsync();
                shopItem.transform.SetParent(m_parent);

                shopItem.Initialize(productDescriptions[i]);
            }
        }
    }
}

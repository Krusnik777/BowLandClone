using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Services;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements
{
    public class ShopItem : MonoBehaviour
    {
        [SerializeField] private Button m_buyItemButton;
        [SerializeField] private Text m_titleText;
        [SerializeField] private Text m_priceText;
        [SerializeField] private Text m_quantityText;

        private IIAPService iAPService;
        private string productId;

        [Inject]
        public void Construct(IIAPService iAPService)
        {
            this.iAPService = iAPService;
        }

        public void Initialize(ProductDescription productDescription)
        {
            productId = productDescription.Id;
            m_titleText.text = productDescription.ProductConfig.Title;
            m_priceText.text = productDescription.ProductConfig.Price.ToString() + "$";
            m_quantityText.text = productDescription.ProductConfig.Quantity.ToString();

            m_buyItemButton.onClick.AddListener(OnBuyButtonClicked);
        }

        private void OnDestroy()
        {
            m_buyItemButton.onClick.RemoveListener(OnBuyButtonClicked);
        }

        private void OnBuyButtonClicked()
        {
            iAPService.StartPurchase(productId);
        }
    }
}

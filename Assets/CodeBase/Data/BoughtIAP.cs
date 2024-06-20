namespace CodeBase.Data
{
    [System.Serializable]
    public class BoughtIAP
    {
        public string ProductId;
        public int Amount;

        public BoughtIAP(string productId, int amount)
        {
            ProductId = productId;
            Amount = amount;
        }
    }
}

using System.Collections.Generic;
using UnityEngine.Events;

namespace CodeBase.Data
{
    [System.Serializable]
    public class PurchaseData
    {
        public List<BoughtIAP> BoughtIAPs = new List<BoughtIAP>();

        public event UnityAction EventOnChanged;

        public void AddPurchase(string id)
        {
            BoughtIAP boughtIAP = BoughtIAPs.Find(x => x.ProductId == id);

            if (boughtIAP != null)
            {
                boughtIAP.Amount++;
            }
            else
            {
                BoughtIAPs.Add(new BoughtIAP(id,1));
            }

            EventOnChanged?.Invoke();
        }
    }
}

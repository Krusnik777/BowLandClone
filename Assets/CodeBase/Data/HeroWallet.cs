using UnityEngine.Events;

namespace CodeBase.Data
{
    [System.Serializable]
    public class HeroWallet
    {
        public event UnityAction<int> EventOnCoinsValueChanged;
        public int Coins;

        public HeroWallet(int coins)
        {
            Coins = coins;
        }

        public void AddCoins(int coins)
        {
            Coins += coins;
            EventOnCoinsValueChanged?.Invoke(Coins);
        }
    }
}

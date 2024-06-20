using UnityEngine.Events;

namespace CodeBase.Data
{
    [System.Serializable]
    public class HeroWallet
    {
        public event UnityAction<int> EventOnCoinsValueChanged;
        public int Coins;

        public static HeroWallet GetDefaultWalletStatus()
        {
            HeroWallet wallet = new HeroWallet();
            wallet.Coins = 0;

            return wallet;
        }

        public void AddCoins(int coins)
        {
            Coins += coins;
            EventOnCoinsValueChanged?.Invoke(Coins);
        }
    }
}

using UnityEngine.Events;

namespace CodeBase.Data
{
    [System.Serializable]
    public class HeroWallet
    {
        public event UnityAction<int> EventOnCoinsValueChanged;

        private int coins;
        public int Coins => coins;

        public static HeroWallet GetDefaultWalletStatus()
        {
            HeroWallet wallet = new HeroWallet();
            wallet.coins = 0;

            return wallet;
        }

        public void AddCoins(int coins)
        {
            this.coins += coins;
            EventOnCoinsValueChanged?.Invoke(this.coins);
        }
    }
}

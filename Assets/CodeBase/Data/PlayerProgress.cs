namespace CodeBase.Data
{
    [System.Serializable]
    public class PlayerProgress
    {
        public int CurrentLevelIndex;
        public HeroStats HeroStats;
        public HeroWallet HeroWallet;
        public PurchaseData PurchaseData;

        public static PlayerProgress GetDefaultProgress()
        {
            PlayerProgress playerProgress = new PlayerProgress();

            playerProgress.CurrentLevelIndex = 0;

            playerProgress.HeroStats = HeroStats.GetDefaultStats();

            playerProgress.HeroWallet = new HeroWallet(0);

            playerProgress.PurchaseData = new PurchaseData();

            return playerProgress;
        }
    }
}

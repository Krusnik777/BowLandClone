namespace CodeBase.Data
{
    [System.Serializable]
    public class PlayerProgress
    {
        public int CurrentLevelIndex;
        public HeroStats HeroStats;
        public HeroWallet HeroWallet;

        public static PlayerProgress GetDefaultProgress()
        {
            PlayerProgress playerProgress = new PlayerProgress();

            playerProgress.CurrentLevelIndex = 0;
            playerProgress.HeroStats = HeroStats.GetDefaultStats();
            playerProgress.HeroWallet = HeroWallet.GetDefaultWalletStatus();

            return playerProgress;
        }
    }
}

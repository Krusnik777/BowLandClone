namespace CodeBase.Data
{
    [System.Serializable]
    public class HeroStats
    {
        public int Damage;
        public float MaxHealth;
        public float MovementSpeed;

        public static HeroStats GetDefaultStats()
        {
            HeroStats heroStats = new HeroStats();

            heroStats.Damage = 60;
            heroStats.MaxHealth = 100;
            heroStats.MovementSpeed = 5;

            return heroStats;
        }
    }
}

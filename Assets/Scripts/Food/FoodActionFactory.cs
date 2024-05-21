namespace Food
{
    public interface FoodActionFactory
    {
        public ScoreFoodAction GetScoreFoodAction(int score);
        public GhostFoodAction GetGhostFoodAction();
        public PowerUpAction GetPowerUpAction();
    }
}
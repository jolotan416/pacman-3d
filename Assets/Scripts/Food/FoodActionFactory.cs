namespace Food
{
    public interface FoodActionFactory
    {
        public ScoreFoodAction GetScoreFoodAction(int score);
    }
}
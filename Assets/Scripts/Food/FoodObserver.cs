namespace Food
{
    public interface FoodObserver
    {
        public abstract void NotifyFoodEaten(int foodValue);
    }
}

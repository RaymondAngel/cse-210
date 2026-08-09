class Program
{
    // Exceeds the core requirements by adding a gamified level-and-title system.
    // The player's title changes every 500 points, and the menu shows progress
    // toward the next level to provide an additional short-term reward.
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video(
            "How to Make the Perfect Chocolate Chip Cookie",
            "The Home Baker",
            485
        );
        video1.AddComment(new Comment("Maria", "These cookies turned out perfectly!"));
        video1.AddComment(new Comment("James", "I added walnuts and loved the result."));
        video1.AddComment(new Comment("Taylor", "The baking tips were very helpful."));
        videos.Add(video1);

        Video video2 = new Video(
            "Beginner's Guide to Landscape Photography",
            "Creative Camera",
            732
        );
        video2.AddComment(new Comment("Andre", "I finally understand the rule of thirds."));
        video2.AddComment(new Comment("Priya", "Could you make a video about night photography?"));
        video2.AddComment(new Comment("Sofia", "The example photos were beautiful."));
        videos.Add(video2);

        Video video3 = new Video(
            "Build a Simple Bookshelf in One Afternoon",
            "Weekend Woodworker",
            916
        );
        video3.AddComment(new Comment("Noah", "This was a great first woodworking project."));
        video3.AddComment(new Comment("Emily", "What type of finish did you use?"));
        video3.AddComment(new Comment("Carlos", "The measurements were easy to follow."));
        video3.AddComment(new Comment("Aisha", "Mine looks great in my living room!"));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}

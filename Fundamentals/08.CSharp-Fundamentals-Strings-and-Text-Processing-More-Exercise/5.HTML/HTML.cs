using System;

namespace _5.HTML
{
    class HTML
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            string article = Console.ReadLine();

            title = "<h1>\n" + title + "\n</h1>";
            article = "<article>\n" + article + "\n</article>";

            Console.WriteLine(title);
            Console.WriteLine(article);

            string comment = Console.ReadLine();
            while (comment != "end of comments")
            {
                comment = "<div>\n" + comment + "\n</div>";
                Console.WriteLine(comment);
                comment = Console.ReadLine();
            }
        }
    }
}

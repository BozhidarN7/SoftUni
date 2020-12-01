using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();

            int numberOfArticles = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfArticles; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                articles.Add(new Article(input[0], input[1], input[2]));
            }

            string orderCriteria = Console.ReadLine();

            articles = articles.OrderBy(x => { if (orderCriteria == "title") return x.Title; else if (orderCriteria == "content") return x.Content; else return x.Author; }).ToList();
            foreach (Article article in articles)
            {
                Console.WriteLine(article.ToString());
            }
        }
    }
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }

    }
}

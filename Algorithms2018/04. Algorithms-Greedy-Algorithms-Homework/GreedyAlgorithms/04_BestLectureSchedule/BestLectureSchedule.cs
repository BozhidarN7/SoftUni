using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_BestLectureSchedule
{
    class BestLectureSchedule
    {
        static void Main(string[] args)
        {
            int numberOfLecture = int.Parse(Console.ReadLine().Split(' ')[1]);

            List<Lecture> lectures = new List<Lecture>();

            for (int i = 0; i < numberOfLecture; i++)
            {
                var line = Console.ReadLine().Split(new char[] { ':', ' ', '-' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = line[0];
                int startTime = int.Parse(line[1]);
                int endTime = int.Parse(line[2]);

                Lecture lecture = new Lecture(name, startTime, endTime);
                lectures.Add(lecture);

            }

            List<Lecture> result =  FindOptimalProgram(lectures).ToList();

            Console.WriteLine("Lectures ({0}):",result.Count);
            foreach (var lecture in result)
            {
                Console.WriteLine($"{lecture.StartTime}-{lecture.EndTime} -> {lecture.Name}");
            }
        }

        private static List<Lecture> FindOptimalProgram(List<Lecture> lectures)
        {
            List<Lecture> result = new List<Lecture>();

            lectures = lectures.OrderBy(x => x.EndTime).ToList();

            Lecture currentLecture = lectures[0];
            result.Add(currentLecture);

            for (int i = 1; i < lectures.Count; i++)
            {
                if (lectures[i].EndTime >= currentLecture.EndTime && lectures[i].StartTime >= currentLecture.EndTime)
                {
                    result.Add(lectures[i]);
                    currentLecture = lectures[i];
                }
            }

            return result;
        }
    }

    class Lecture
    {
        public string Name { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }

        public Lecture(string name, int startTime, int EndTime)
        {
            this.Name = name;
            this.StartTime = startTime;
            this.EndTime = EndTime;
        }
    }
}

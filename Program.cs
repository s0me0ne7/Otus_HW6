namespace Otus_HW6
{
    
    class Program
    {
        public static void Main(string[] args)
        {
            string path = @"C:\Users\s0me0\Desktop\Otus\DZ_6\Otus_HW6\";

            Random random = new Random();
            int maxVal = 10000;

            var firstGetMaxTest = new List<int>()
            {   random.Next(-maxVal, maxVal),
                random.Next(-maxVal, maxVal),
                random.Next(-maxVal, maxVal),
                random.Next(-maxVal, maxVal),
                random.Next(0, maxVal),
                random.Next(0, maxVal)
            };

            var secondGetMaxTest = new List<ClassForGetMax>()
            {
                {new ClassForGetMax(random.Next(-maxVal, maxVal))},
                {new ClassForGetMax(random.Next(-maxVal, maxVal))},
                {new ClassForGetMax(random.Next(-maxVal, maxVal))},
                {new ClassForGetMax(random.Next(-maxVal, maxVal))},
                {new ClassForGetMax(random.Next(-maxVal, maxVal))},
            };
            var thirdGetMaxTest = new List<string>()
            {   random.Next(-maxVal, maxVal).ToString(),
                random.Next(-maxVal, maxVal).ToString(),
                random.Next(-maxVal, maxVal).ToString(),
                random.Next(-maxVal, maxVal).ToString(),
                random.Next(0, maxVal).ToString(),
                random.Next(0, maxVal).ToString()
            };
            var firstResult = firstGetMaxTest.GetMax<int>(item => item);
            var secondResult = secondGetMaxTest.GetMax<ClassForGetMax>(item => item.I1);
            var thirdResult = thirdGetMaxTest.GetMax<string>(item => int.Parse(item));

            var fileSearcher = new FileSearcher();
            fileSearcher.FileFound += fileSearcher_FileFound;
            fileSearcher.Search(path);
            
            Console.ReadLine();
        }

        private static void fileSearcher_FileFound(object? sender, FileFoundArgs e)
        {
            Console.WriteLine($"Найден файл {e.FoundFile.ToString()}");
        }
    }
}
using System.Collections;
using System;

namespace Otus_HW6
{
    public class FileSearcher
    {
        public event EventHandler<FileFoundArgs> FileFound;

        public void Search(string directory)
        {
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            bool ifCanceled = false;
            Console.WriteLine($"Запускается поиск файлов в директории");
            Console.WriteLine($"Нажмите ''Esc'' чтобы выйти");

            foreach (var file in Directory.EnumerateFiles(directory))
            {
                if (Console.KeyAvailable == true)
                {
                    cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Escape)
                    {
                        ifCanceled = true;
                        Console.WriteLine($"Поиск остановлен");
                        break;
                    }
                }

                FileFound?.Invoke(this, new FileFoundArgs(file));

                Thread.Sleep(2000);
            }
            if (!ifCanceled)
            {
                Console.WriteLine($"Поиск окончен");
            }
        }
    }
    public class FileFoundArgs : EventArgs
    {
        public string FoundFile { get; }

        public FileFoundArgs(string fileName)
        {
            FoundFile = fileName;
        }


    }
}

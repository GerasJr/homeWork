using System;

namespace hm27
{
    class HomeWork27
    {
        static void Main(string[] args)
        {
            string text = "Пельмени – знаменитое блюдо русской кухни, имеющее древние китайские, финно-угорские, тюркские и славянские корни.";
            string[] words = text.Split(' ');

            Console.WriteLine(text);

            foreach(string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}

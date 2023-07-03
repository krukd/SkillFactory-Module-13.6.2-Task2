namespace SkillFactory_Module_13._6._2_Task2
{
    internal class Program
    {
        public static Dictionary<string, int> usualDict = new Dictionary<string, int>();
        public static List<int> val = new List<int>();

        static void Main(string[] args)
        {

            
            string text = File.ReadAllText("\\\\Mac\\Home\\Desktop\\Text1.txt");

           
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

            
            char[] delimiters = new char[] { ' ', '\t', '\n' };

            
            var words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            //Подсчитываем количество встречаемости каждого слова в тексте, сохраняем в словарь Слово - Частота
            for (int i = 0; i < words.Length; i++)
            {
                if (!usualDict.ContainsKey(words[i])) 
                {
                    usualDict.Add(words[i], 1);
                }
                else
                {
                    usualDict[words[i]]++;           
                }
            }


            foreach (KeyValuePair<string, int> p in usualDict)  
            {
                val.Add(p.Value);
            }

            val.Sort();    

            val.Reverse(); 

            for (int i = 0; i < 10; i++)   //Для 10 первых (наибольших значений встречаемости) выводим слово (ключ)
                                           // из словаря и соответствующее значение
            {
                foreach (KeyValuePair<string, int> p in usualDict)  //Перебираем весь словарь на случай,
                                                                    //когда разные слова имеют одинаковую частоту встречаемости
                {
                    if (p.Value == val[i])
                        Console.WriteLine($"{p.Key} = {p.Value}");
                }

               
            }

        }
    }
}
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace exception_handle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Write a C# program that reads a list of integers from the user and throws an exception if any numbers are duplicates.
            int i;
            Console.WriteLine("please enter the numbers");
            int n = Convert.ToInt32(Console.ReadLine());
            List<int> numbers = new List<int>();
            try
            {
                for (i = 0; i < n; i++)
                {
                    int number = Convert.ToInt32(Console.ReadLine());
                    if (numbers.Contains(number))
                    {
                        throw new Exception("numbers are duplicates");
                    }
                    numbers.Add(number);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("good bye");
            }
            //2. Write a C# program to create a method that takes a string as input and throws an exception if the string does not contain vowels.
            string s = Console.ReadLine();
            try
            {
                st(s);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("good bye");
            }
        }
        public static void st(string st)
        {
            for(int i=0; i<st.Length; i++)
            {
                if(!st.Contains('a') && !st.Contains('e')&&!st.Contains('i')&&!st.Contains('o')&& !st.Contains('u'))
                {
                    throw new Exception("the string does not contain vowels");
                }
            }
        }
    }
}

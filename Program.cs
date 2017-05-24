using System;

namespace ZooImitation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}

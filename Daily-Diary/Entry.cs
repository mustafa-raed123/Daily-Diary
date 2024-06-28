using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily_Diary
{
    public class Entry
    {
        public string Time { get; set; }
        public string Content { get; set; }


        public void CheckDate()
        {

            bool IsCorrect = false;
                    Console.Write("Enter a date (e.g., YYYY-M-D): ");
            while (!IsCorrect)
            {
                try
                {
                    string dates = Console.ReadLine();
                    DateTime parsedDate = DateTime.ParseExact(dates, "yyyy-M-d", CultureInfo.CurrentCulture);
                     Time = parsedDate.ToString("yyyy-M-d");
                 
                    IsCorrect = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("The date is not valid. Enter a valid date such as (2012-2-23).");
                }
            }
        }
        public void CheckContent()
        {

            Console.Write("Enter a Diary:");
            
            bool IsCorrect = false;
            while (!IsCorrect)
            {
              
                
                    string diary = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(diary))
                {
                    Content = diary;
                    IsCorrect = true;
                }
                else { Console.Write("The diary is empty. Please enter a correct diary entry: "); 
                }

                
                
                
               
            }
        }


    }
}

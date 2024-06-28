using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily_Diary
{
    public class DailyDiary
    {
        
        public string? path;
        public string[] diary;
        public int count;


        Entry entry = new Entry();
        public DailyDiary()
        {
            
        }

        public void CheckContent()
        {
            string paths = Path.Combine(Environment.CurrentDirectory, "diary.txt");
            if (!File.Exists(paths))
            {
                Console.WriteLine("The diary file does not exist.");
                return;
            }
            path = paths;
            diary = File.ReadAllLines(path);
            
            if (diary.Length == 0)
            {

                Console.WriteLine(" the Daily Diary is Empty");
                Console.WriteLine("adding a Firs Diary:");
                CheckingInput();
                AddNewDiary(entry);
            }
            else
            {
                Console.WriteLine("What Do you Need: (Reading All Diary (Press 1)," +
                    " Adding a New Diary (Press 2),\n" +
                    " Deleting a Diary (Press 3)," +
                    " Get Diary Date (Press 4))");
                bool Press = false;
                while (!Press)
                {
                    string Enter = Console.ReadLine();
                    if (Enter == "1")
                    {
                        
                        GetDiary(diary);
                    }
                    else if (Enter == "2")
                    {
                        CheckingInput();
                        AddNewDiary(entry);



                    }
                    else if (Enter == "3")
                    {
                        DeletingDiary();
                    }
                    else if(Enter == "4")
                    {

                        GetDiaryDate();
                    }
                    else
                    {
                        Console.WriteLine("Enter Valid Number");
                        continue;
                    }
                    Press = true;
                }
            }
        }

        public string AddNewDiary(Entry entry)
        {
            
            List<string> lines = new List<string>
        {
            entry.Time,
            entry.Content,
            
        };

            File.AppendAllLines(path, lines);
            string[] diary2 = File.ReadAllLines(path);
            GetDiary(diary2);
            Console.WriteLine("Successfuly Adding");
            return ("Successfuly Adding");
        }
        public void CheckingInput()
        {
            entry.CheckDate();
            entry.CheckContent();
            
        }
        public void DeletingDiary()
        {
                GetDiary(diary);
                Console.Write("Enter the number of the Diary to remove: ");
                if (!int.TryParse(Console.ReadLine(), out int num))
                {
                    Console.WriteLine("Invalid number format");
                    return;
                }

                int numrem = GetDiary(num);
                if (numrem == -1)
                {
                    Console.WriteLine("Invalid diary number. Please enter a valid number.");
                    return;
                }

                string[] diary2 = new string[diary.Length - 1];
                int count = 0;

                for (int i = 0; i < diary.Length; i++)
                {
                    if (i == numrem )
                    {
                    i++;
                        continue;
                    } else if (string.IsNullOrWhiteSpace(diary[i]))
                    continue;
                    else
                    diary2[count++] = diary[i];
                }

                File.WriteAllLines(path, diary2);
                Console.WriteLine("Diary entry deleted successfully.");


            }
        public int GetDiary(int id)
        {
            
            int count = 0;
            
            for (int i = 0; i < diary.Length; i++)
            {
                if (DateTime.TryParse(diary[i], out DateTime dt))
                {
                    if(id-1 == count)
                    {
                        
                        return i;
                    }
                    count++;

                }               
            }
            return -1;
        }
        public int GetDiary(string[] diary)
        {
            
             count = 0;
            for (int i = 0; i < diary.Length; i++)

            {
                if (DateTime.TryParse(diary[i], out DateTime dt))
                {
                    
                    Console.WriteLine($"{++count}- {diary[i]}");
                }
                else if (string.IsNullOrWhiteSpace (diary[i])) continue;
                  else{
                    
                    Console.WriteLine(diary[i]);
                    Console.WriteLine("\n");
                }

            }
            Console.WriteLine($"you have {count} diary");
            return count;
        }
        public void GetDiaryDate()
        {
            Console.Write("Enter a Date: ");
            string Date = Console.ReadLine();
            string[] diary = File.ReadAllLines(path);
            string[] diary2 = new string[] { }; 
             
                int count = 0;

            for (int i = 0; i < diary.Length   ; i++)
            {
                if (diary[i] == Date)
                {
                    count++;
                    Console.WriteLine(diary[i]);
                    Console.WriteLine(diary[i+1]);                
                }
            }
            if(count == 0)
            {
                Console.WriteLine("No diary entries found for the specified date.");
                return;
            }else
            Console.WriteLine($"you have {count} diary entries on the date: {Date}");
            

        }
        public void LoadDiary( string path)
        {
           
            
            if (File.Exists(path))
            {
                diary = File.ReadAllLines(path);
                count = diary.Length;
            }
            else
            {
                diary = new string[0];
                count = 0;
            }
        }

    }
}

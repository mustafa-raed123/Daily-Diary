
using System;
using System.IO;
using Xunit;
using Daily_Diary;
using System.Threading.Tasks;
using System.Reflection.Metadata;
namespace DailyDiaryTest
{
    public class UnitTest1
    {



        private string path = Path.Combine(Environment.CurrentDirectory, "diary.txt");

        [Fact]
        public void AddingDiary()
        {
            
            // Arrange
            DailyDiary diary = new DailyDiary { path = path };
            Entry entry = new Entry { Time = "2001-2-1", Content = "good day" };

            // Act
            string result = diary.AddNewDiary(entry);

            // Assert
            Assert.Equal("Successfuly Adding", result);
            File.Delete(path);

        }

        [Fact]
        public void ReadingDiary()
        {
            // Arrange
            string path = @"C:\Users\LTUC\source\repos\Daily-Diary\Daily-Diary\diary.txt";
           DailyDiary diary = new DailyDiary { path = path };
            Entry entry = new Entry { Time = "2001-2-1", Content = "good day" };
            diary.AddNewDiary(entry);

           // Act
            diary.LoadDiary(path);
            int count = diary.count;
            string[] diaries = diary.diary;

           // Assert
            
            Assert.Contains("2001-2-1", diaries);
            Assert.Contains("good day", diaries);
        }
    }
}
using System;
using Xunit;
using System.IO;
using System.ComponentModel;
using System.Reflection;

namespace Exercise_1.Test
{
    public class Exercise1Test
    {

        // Retrieved from https://stackoverflow.com/a/62852186
        private static bool IsPropertyReadOnly<T>(string PropertyName)
        {
            return typeof(T).GetField(PropertyName).IsInitOnly;
            /*PropertyInfo info = typeof(T).GetMember(PropertyName)[0] as PropertyInfo;
            return info.GetSetMethod() == null;
            */
        }

        [Fact]
        public void Status_Cant_Be_Changed()
        {            
            Assert.True(IsPropertyReadOnly<Student>("Status"));
        }
        
        [Fact]
        public void ID_Cant_Be_Set_After_Created()
        {            
            Assert.True(IsPropertyReadOnly<Student>("Status"));
        }

        [Fact]
        public void ToString_Returns_Complete_Object() 
        {
            // Arrange
            var student = new Student(1, "Rasmus", "Lysstrøm", new DateTime(2021, 9, 16), new DateTime(2024, 7, 20), new DateTime(2024, 7, 20));

            // Act
            var actual = student.ToString();
            string expected = (
                $"Id={student.Id}, " +
                $"Name={student.GivenName}, " + 
                $"Surname={student.Surname}, " + 
                $"Status={student.Status}, " +
                $"StartDate={student.StartDate.ToString()}, " +
                $"EndDate={student.EndDate.ToString()}, " +
                $"GraduationDate={student.GraduationDate.ToString()}"
            );

            // Assert
            Assert.Equal(expected, actual);
        }
    
        [Theory]
        [InlineData("2021-9-16", "2024-7-20", "2024-7-20", Status.New)]
        [InlineData("2019-9-16", "2022-7-20", "2022-7-20", Status.Active)]
        [InlineData("2019-9-16", "2020-7-20", null,        Status.Dropout)]
        [InlineData("2019-9-16", "2020-7-20", "2020-7-20", Status.Graduated)]
        public void Status_Returns_Correctly(string start, string end, string? graduation, Status expected) 
        {
            var startDate = DateTime.Parse(start);
            var endDate = DateTime.Parse(end);
            DateTime? graduationDate = graduation != null ? DateTime.Parse(graduation) : null;

            var student = new Student(1, "Name", "Surname", startDate, endDate, graduationDate);
            
            var actual = student.Status;

            Assert.Equal(expected, actual);
        }
    }
}

using System;

namespace Exercise_1
{
    public enum Status {
        New, 
        Dropout, 
        Active, 
        Graduated
    }
    
    public class Student
    {
        public Student(int id, string givenName, string surname, DateTime startDate, DateTime endDate, DateTime? graduationDate) {
            Id = id;
            GivenName = givenName;
            Surname = surname;
            StartDate = startDate;
            EndDate = endDate;
            GraduationDate = graduationDate;
            if(GraduationDate == null) 
            {
                Status = Status.Dropout;
            } 
            else if(GraduationDate < DateTime.Now) 
            {
                Status = Status.Graduated;
            } 
            else if(DateTime.Now.AddMonths(-6) < StartDate)
            {
                Status = Status.New;
            } else
            {
                Status = Status.Active;
            }
        }
        
        public int Id {get; init;} 
        public string GivenName{get;}
        public string Surname {set; get;}
        public readonly Status Status;
        
        public DateTime StartDate {get; init;}
        public DateTime EndDate {get; init;}
        public DateTime? GraduationDate {get; init;}

        public override string ToString() {

            return (
                $"Id={Id}, " +
                $"Name={GivenName}, " + 
                $"Surname={Surname}, " + 
                $"Status={Status.ToString()}, " +
                $"StartDate={StartDate.ToString()}, " +
                $"EndDate={EndDate.ToString()}, " +
                $"GraduationDate={GraduationDate.ToString()}"
            );
        }
    }
}

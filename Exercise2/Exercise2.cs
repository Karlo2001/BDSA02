using System;

namespace Exercise2
{
    public enum Status {
        New, 
        Dropout, 
        Active, 
        Graduated
    }
    public record ImmutableStudent
    {
        public ImmutableStudent(int id, string givenName, string surname, DateTime startDate, DateTime endDate, DateTime? graduationDate) {
            Id = id;
            GivenName = givenName;
            Surname = surname;
            StartDate = startDate;
            EndDate = endDate;
            GraduationDate = graduationDate;
        }
        public int Id {get; init;} 
        public string GivenName{get; init;}
        public string Surname {get; init;}
        public Status Status {
            get{
            if(GraduationDate == null) 
            {
                return Status.Dropout;
            } 
            else if(GraduationDate < DateTime.Now) 
            {
                return Status.Graduated;
            } 
            else if(DateTime.Now.AddMonths(-6) < StartDate)
            {
                return Status.New;
            } 

            return Status.Active;
        }}
        
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

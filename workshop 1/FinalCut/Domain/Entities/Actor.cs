using System;

namespace ITVerket.FinalCut.Domain.Entities
{
    public class Actor
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string ImageUrl { get; set; }

        public Actor(string firstName, string lastName, DateTime birthDate, string imageUrl)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            ImageUrl = imageUrl;
        }
    }
}
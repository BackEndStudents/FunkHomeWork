using System;
using System.Collections.Generic;

namespace FuncHW
{
    public class Program
    {
        static void Main()
        {
            Person vasya = new Person() { Name = "Vasya", PhoneNumber = 12345, BirthDate = new DateTime(1999, 12, 12), IsActive = true };
            Person petya = new Person() { Name = "Petya", PhoneNumber = 57348, BirthDate = new DateTime(2015, 11, 11), IsActive = true };
            Person gosha = new Person() { Name = "Gosha", PhoneNumber = 34825, BirthDate = new DateTime(1991, 10, 10), IsActive = false };
            Person grisha = new Person() { Name = "Grisha", PhoneNumber = 78136, BirthDate = new DateTime(1964, 9, 9), IsActive = true };
            Person sveta = new Person() { Name = "Sveta", PhoneNumber = 75381, BirthDate = new DateTime(2010, 8, 8), IsActive = false };
            Person nika = new Person() { Name = "Nika", PhoneNumber = 22387, BirthDate = new DateTime(2015, 7, 7), IsActive = true };
            Person ira = new Person() { Name = "Ira", PhoneNumber = 96346, BirthDate = new DateTime(1988, 6, 6), IsActive = false };

            List<Person> persons = new() { vasya, petya, gosha, grisha, sveta, nika, ira };

            Cat barsik = new Cat() { Name = "Barsik", Color = "white", IsDomestic = false };
            Cat pushok = new Cat() { Name = "Pushok", Color = "white", IsDomestic = true };
            Cat murzik = new Cat() { Name = "Murzik", Color = "red", IsDomestic = false };
            Cat dymok = new Cat() { Name = "Dymok", Color = "black", IsDomestic = false };
            Cat murka = new Cat() { Name = "Murka", Color = "grey", IsDomestic = true };

            List<Cat> cats = new() { barsik, pushok, murzik, dymok, murka };

            //Func*** funcPersonIsActive = ***;

            Func<Person, bool> funcPersonPhoneNumberStartsWith7 = (Person person) => 
            {
                int phoneNumber = person.PhoneNumber;

                while (phoneNumber > 10)
                {
                    phoneNumber /= 10;
                }

                return phoneNumber == 7;
            };

            //Func*** funcPersonIsChild = ***;
            //Func*** funcPersonPhoneNumberStartsWith7 = ***;

            Func<Person, bool> funcPersonIsChild = (Person person) => DateTime.Now.Year - person.BirthDate.Year < 17;

            //Func*** funcPersonHasShortName = ***;

            Func<Person, bool> funcPersonHasShortName = (Person persons) => persons.Name.Length < 5;

            //Func*** funcCatIsDomestic = ***;
            Func<Cat, bool> funcCatIsDomestic = (Cat cat) => cat.IsDomestic;


            Func<Cat, bool> funcCatColorIsDark = (Cat cat) => 
                string.Equals(cat.Color, "grey", StringComparison.OrdinalIgnoreCase) 
                || string.Equals(cat.Color, "black", StringComparison.OrdinalIgnoreCase);
            
            //Func*** funcCatNameConteinsU = ***;
            //Func*** funcCatIsDomesticAndWhite = ***;
            
            List<Person> personsPhoneNumberDontStartsWith7 = persons.SelectWhereNot(funcPersonPhoneNumberStartsWith7);

            List<Cat> catsColorNotDark = cats.SelectWhereNot(funcCatColorIsDark);

            Func<Cat, bool> funcCatIsDomesticAndWhite = (Cat cat) => cat.Color == "white" && cat.IsDomestic;
            
            //write result to variable
            //check using debug and breakpoint

            Person personHasShortName = persons.GetLast(funcPersonHasShortName);
            Cat catIsDomesticAndWhite = cats.GetLast(funcCatIsDomesticAndWhite);

            int countPersonIsChild = ListExtensions.CountElements(persons, funcPersonIsChild);
            int countCatIsDomestic = ListExtensions.CountElements(cats, funcCatIsDomestic);

            Console.WriteLine($"Количество персон младше 17 лет: {countPersonIsChild}\n" +
                              $"Количество домашних котиков: {countCatIsDomestic}");
        }
    }
}

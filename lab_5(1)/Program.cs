using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5_1_
{
    abstract class GeneralInfo
    {
        public string Country { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        public string Cover { get; set; }
    }
    interface ICommentable
    {
        void Comment();
    }
    abstract class Comments
    {
        public abstract void Comment();
    }
    class PrintEdition
    {
        public string NameOfEdition { get; set; }
        public int HashCode { get; set; }
        public PrintEdition(string name)
        {
            NameOfEdition = name;
            HashCode = GetHashCode();
        }
        public override string ToString()
        {
            return NameOfEdition + "(hash code: " + HashCode + ")";
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            PrintEdition print = (PrintEdition)obj;
            return (this.NameOfEdition == print.NameOfEdition);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        //Get type переписать нельзя
    }
    class Book : GeneralInfo
    {
        public string TitleOfBook { get; set; }
        public Book(string title, string country, int year, int pages, string cover)
        {
            TitleOfBook = title;
            Country = country;
            Year = year;
            Pages = pages;
            Cover = cover;
        }
        public override string ToString()
        {
            return "~~~~~~~~~~Information about book~~~~~~~~~~\nTitle: " + TitleOfBook + "\nYear: " + Year + "\nPages: " + Pages + "\nCountry: " + Country;
        }
    }
    class Magazin : GeneralInfo
    {
        public string TitleOfMagazin { get; set; }
        public Magazin(string title, string country, int year, int pages, string cover)
        {
            TitleOfMagazin = title;
            Country = country;
            Year = year;
            Pages = pages;
            Cover = cover;
        }
        public override string ToString()
        {
            return "~~~~~~~~~~Information about magazin~~~~~~~~~~\nTitle: " + TitleOfMagazin + "\nYear: " + Year + "\nPages: " + Pages + "\nCountry: " + Country;
        }
    }
    class SchoolBook : GeneralInfo
    {
        public string TitleOfSchoolBook { get; set; }
        public SchoolBook(string title, string country, int year, int pages, string cover)
        {
            TitleOfSchoolBook = title;
            Country = country;
            Year = year;
            Pages = pages;
            Cover = cover;
        }
        public override string ToString()
        {
            return "~~~~~~~~~~Information about school book~~~~~~~~~~\nTitle: " + TitleOfSchoolBook + "\nYear: " + Year + "\nPages: " + Pages + "\nCountry: " + Country;
        }
    }
    sealed class Author : Comments, ICommentable
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Author(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
        public override string ToString()
        {
            return "Author: " + Name + " " + Surname;
        }
        public override void Comment()
        {
            Console.WriteLine("The famous author!");
        }
    }
    class Publishing : Comments, ICommentable
    {
        public string NamePublish { get; set; }
        public Publishing(string publish)
        {
            NamePublish = publish;
        }
        public override string ToString()
        {
            return "Publishing house: " + NamePublish;
        }
        public override void Comment()
        {
            Console.WriteLine("The best publishing house!");
        }
    }
    public class Printer
    {
        public string IAmPrinting(Object obj)
        {
            return obj.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PrintEdition printEdition1 = new PrintEdition("Book");
            Book book1 = new Book("Harry Potter and the Prisoner of Azkaban", "United Kingdom", 1999, 464, "hard");
            Author author1 = new Author("Joanne", "Rowling");
            Publishing publishing1 = new Publishing("Bloomsbury");

            PrintEdition printEdition2 = new PrintEdition("Magazin");
            Magazin magazin2 = new Magazin("Vogue", "USA", 1998, 73, "soft");
            Author author2 = new Author("Alena", "Doletskaya");
            Publishing publishing2 = new Publishing("Condé Nast");

            PrintEdition printEdition3 = new PrintEdition("School Book");
            SchoolBook schoolBook3 = new SchoolBook("Upstream: Elementary A2 Student's Book", "United Kingdom", 2005, 128, "soft");
            Author author3 = new Author("Virginia", "Evans");
            Publishing publishing3 = new Publishing("Express Publishing");

            Printer Printer = new Printer();
            Object[] arr = new Object[] { printEdition1, book1, author1, publishing1, printEdition2, magazin2, author2, publishing2, printEdition3, schoolBook3, author3, publishing3 };

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(Printer.IAmPrinting(arr[i]));
                Console.WriteLine();
            }
            author1.Comment();
            publishing3.Comment();

            Console.WriteLine();
            Console.Write(author1.Name + " " + author1.Surname);
            if (author1 is ICommentable)
                Console.WriteLine(" is a very famous author");
            else
                Console.WriteLine("is a начинающий автор");

            Console.WriteLine();
            printEdition1.Equals(magazin2);
        }
    }
}
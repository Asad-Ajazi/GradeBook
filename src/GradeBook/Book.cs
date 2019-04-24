using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);


    public class InMemoryBook : Book
    {
        //Book is a NamedObject


        private List<double> grades;
        // public string Name 
        // { 
        //     get;
        //     //private to make the name unchangeable publically from outside of the class once created.
        //     set;
        // }

        public const string CATEGORY = "Science";

        // Constructor.
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            this.Name = name;
        }

        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                case 'E':
                    AddGrade(50);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }
        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            //vs grades being added to book.
            var result = new Statistics();
            for (int i = 0; i < grades.Count; i++)
            {
                result.Add(grades[i]);
            }
            return result;
        }
    }
}
namespace GradeBook
{
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        // must have it, but let the derived class take care of the implementation.
        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }
}
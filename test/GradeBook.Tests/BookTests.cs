using System;
using Xunit;


namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // arrange
            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(85.2);
            book.AddGrade(70.3);

            // act
            var result = book.GetStatistics();
            
            
            // assert
            Assert.Equal(81.53, result.Average, 2);
            Assert.Equal(89.1, result.High,2);
            Assert.Equal(70.3, result.Low,2);
            Assert.Equal('B', result.Letter);      
        }
    }
}

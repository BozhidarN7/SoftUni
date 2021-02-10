using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class LibraryIterator : IEnumerator<Book>
    {
        private List<Book> books;

        private int currentIndex;
        public LibraryIterator(List<Book> books)
        {
            this.Reset();
            this.books = books;
        }

        public Book Current => books[currentIndex];

        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            currentIndex++;
            return currentIndex < books.Count;
        }

        public void Reset()
        {
            currentIndex = -1;
        }
    }
}
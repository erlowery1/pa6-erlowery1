using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pa6_erlowery1
{
    class Book
    {
        /*all of the instance variables along with their 
         getters and setters*/
        public string cwid { get; set; }
        public string isbn { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string cover { get; set; }
        public string genre { get; set; }
        public int length { get; set; }
        public int copies { get; set; }
        public string _id { get; set; }

        //instructor
        public Book(string cwid, string isbn, string title, string author, string cover, string genre, int length, int copies, string id)
        {
            this.cwid = cwid;
            this.isbn = isbn;
            this.title = title;
            this.author = author;
            this.cover = cover;
            this.genre = genre;
            this.length = length;
            this.copies = copies;
            _id = id;
        }

        //no arg contructor
        public Book()
        {

        }
        public override string ToString()
        {
            return this.title;
        }
    }
}

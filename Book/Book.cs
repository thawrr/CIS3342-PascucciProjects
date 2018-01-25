using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary //Data Transfer Object
{
    //should have bookItem constructor to create a bookItem
    //BookItem(book, quantity) creates a BookItem for the specified book and quantity
    //book and quantity Property, the get and set, that's in book.cs
    //AddQuantity(quantity) method-adds quant passed to it to the quant for a bookItem. Only called when the item os already in the cart..

    /*
     b.	This class should contain class properties that will be used to be display in the output GridView (in Part 5). 
     The properties pertain to a single book that is ordered.
            i.	Title, Authors, ISBN, BookType, Quantity, Price, and TotalCost.
     */

    //reference GridViewsExample6 from profs website if confused
    // http://cis-iis2.temple.edu/Users/Pascucci/CIS3342/

    public class Book //book object
    {
        private string isbn;
        private string title;
        private string author;
        private double price;
        private string bookType;
        private string purchaseOption;
        private double totalCost;
        private int quantity;
        private int totalQuantityRented;
        private int totalQuantitySold;


        public string ISBN
        {
            get { return isbn; }
            set { isbn = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public string BookType
        {
            get { return bookType; }
            set { bookType = value; }
        }

        public string PurchaseOption
        {
            get { return purchaseOption; }
            set { purchaseOption = value; }
        }

        public double TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public int TotalQuantityRented
        {
            get { return totalQuantityRented; }
            set { totalQuantityRented = value; }
        }

        public int TotalQuantitySold
        {
            get { return totalQuantitySold; }
            set { totalQuantitySold = value; }
        }

        public Book() //empty Book Object
        {
        }

        public Book(string isbn, string title, string author, double price, string bookType, string purchaseOption, double totalCost, int quantity, int totalQuantityRented, int totalQuantitySold)//loaded book with everything in it
        {
            this.ISBN = isbn;
            this.Title = title;
            this.Author = author;
            this.Price = price;
            this.BookType = bookType;
            this.PurchaseOption = purchaseOption;
            this.TotalCost = totalCost;
            this.Quantity = quantity;
            this.TotalQuantityRented = totalQuantityRented;
            this.TotalQuantitySold = totalQuantitySold;
        }

        public virtual string getDisplayText(string sep)
        {
            return ISBN + sep + Title + sep + Author + sep + price + sep + BookType + sep + PurchaseOption + sep + TotalCost +
                sep + Quantity;
        }

        public override string ToString()
        {
            return this.getDisplayText("\r\n");
        }

        public virtual string ToCSV()
        {
            return this.getDisplayText(",");
        }
        
        
    }//end class
}//end name space

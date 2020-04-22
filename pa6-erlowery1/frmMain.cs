using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pa6_erlowery1
{
    public partial class frmMain : Form
    {
        //instance variables

        string cwid;
        List<Book> myBooks;

        //constructor
        public frmMain(string tempCwid)
        {
            this.cwid = tempCwid;

            InitializeComponent();

            //sizes picture to fit our picture box we placed on the form 
            pbCover.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        //loads all books to main form
        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadList();
        }
        //loads all book data
        private void LoadList()
        {
            myBooks = BookFile.GetAllBooks(cwid);
            lstBooks.DataSource = myBooks;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //closes form is close is clicked
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstBooks_SelectedIndexChanged(object sender, EventArgs e)
        {//cast what is selected from the list box into a book
            Book myBook = (Book)lstBooks.SelectedItem;

            //setting the text property to the corresponding book property
            txtTitleData.Text = myBook.title;
            txtAuthorData.Text = myBook.author;
            txtGenreData.Text = myBook.genre;
            txtIsbnData.Text = myBook.isbn;
            txtCopiesData.Text = myBook.copies.ToString();
            txtLengthData.Text = myBook.length.ToString();

            //load the picture
            try
            {
                pbCover.Load(myBook.cover);
            }
            catch
            {

            }
        }

        //casts the selected book to a book
        //removes one copy
        private void btnRent_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;

            //subtracts a copy
            myBook.copies--;

            //saves book
            BookFile.SaveBook(myBook, cwid, "edit");

            //reloads list and displays new data
            LoadList();
        }

        //adds a copy available back to the book you are returning
        private void btnReturn_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;

            //adds a copy
            myBook.copies++;

            //saves book
            BookFile.SaveBook(myBook, cwid, "edit");

            //reloads list and displays new data
            LoadList();
        }

        //removes a book from the main form all together
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;

            //makes sure the user really wants to delete a book
            DialogResult  dialogResult = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo);

            //if they chose to delete it, remove it from the list
            if (dialogResult == DialogResult.Yes)
            {
                BookFile.DeleteBook(myBook, cwid);
                LoadList();
            }

        }

        //passes book the user chose to edit into the edit form
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;
            frmEdit myForm = new frmEdit(myBook, "edit", cwid);
            if (myForm.ShowDialog() == DialogResult.OK)
            {

            }
            else
            {
                LoadList();
            }
        }

        /*calls default constructor, passes it into the form with mode
         type of new*/
        private void btnNew_Click(object sender, EventArgs e)
        {
            Book myBook = new Book();
            frmEdit myForm = new frmEdit(myBook, "new", cwid);
            if (myForm.ShowDialog() == DialogResult.OK)
            {

            }
            else
            {
                LoadList();
            }
        }
    }
}

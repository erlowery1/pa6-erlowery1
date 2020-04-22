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
    public partial class frmEdit : Form
    {
        //instance variables
        private Book myBook;
        private string cwid;
        private string mode;

        //constructor
        public frmEdit(Object tempBook, string tempMode, string tempCwid)
        {
            myBook = (Book) tempBook;
            cwid = tempCwid;
            mode = tempMode;
            InitializeComponent();

            //fits image to box size
            pbCover.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        //loads all text fields & cover of the book you want to edit
        
        private void frmEdit_Load(object sender, EventArgs e)
        {
            //set all text fields
            if (mode == "edit")
            {
                txtTitleData.Text = myBook.title;
                txtAuthorData.Text = myBook.author;
                txtGenreData.Text = myBook.genre;
                txtCopiesData.Text = myBook.copies.ToString();
                txtIsbnData.Text = myBook.isbn;
                txtCoverData.Text = myBook.cover;
                txtLengthData.Text = myBook.length.ToString();

                //load picture
                pbCover.Load(myBook.cover);

            }
        }

        //closes form
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //updating objects and saving it to a database
        private void btnSave_Click(object sender, EventArgs e)
        {
            //updating object
            myBook.title = txtTitleData.Text;
            myBook.author = txtAuthorData.Text;
            myBook.genre = txtGenreData.Text;
            myBook.copies = int.Parse(txtCopiesData.Text);
            myBook.isbn = txtIsbnData.Text;
            myBook.cover = txtCoverData.Text;
            myBook.length = int.Parse(txtLengthData.Text);
            myBook.cwid = cwid;

            //saving record to data base
            BookFile.SaveBook(myBook, cwid, mode);

            //message box letting them know the book has been saved
            MessageBox.Show("Content was saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //close the edit form
            this.Close();
        }
    }
}

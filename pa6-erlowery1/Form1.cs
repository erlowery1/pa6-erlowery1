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
    public partial class frmCWID : Form
    {
        public frmCWID()
        {
            InitializeComponent();
        }
        /*closes form if they hit the close button*/
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btbOK_Click(object sender, EventArgs e)
        {
            //if you hit okay it passes the cwid to the main form
            this.Hide();
            frmMain myForm = new frmMain(txtCWID.Text);
            if(myForm.ShowDialog() == DialogResult.OK)
            {

            }
            else //close app
            {
                this.Close();
            }
        }
    }
}

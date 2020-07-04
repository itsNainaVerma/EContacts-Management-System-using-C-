using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp.econtactClasses;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ContactClass c = new ContactClass();
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtboxContactID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtboxGender_Click(object sender, EventArgs e)
        {

        }

        private void lblContactID_Click(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //get the value from the input fields
            c.Firstname = txtboxFirstName.Text;
            c.Lastname = txtboxLastName.Text;
            c.ContactNo = txtboxContactNumber.Text;
            c.Address = txtboxAddress.Text;
            c.Gender = cmbGender.Text;

            //inserting data into databse
            bool success = c.Insert(c);
            if (success == true)
            {
                //success
                MessageBox.Show("New Contact Successfully Inserted");

                //calling clear method here
                clear();
            }
            else
            {
                MessageBox.Show("Failed to add New Contact. Try Again !");
            }

            //load data on DataGridView
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //load data on DataGridView
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //method to clear field
        public void clear()
        {
            txtboxFirstName.Text = "";
            txtboxLastName.Text = "";
            txtboxContactNumber.Text = "";
            txtboxAddress.Text = "";
            cmbGender.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //getting th data from textboxes
            c.ContactID = int.Parse(txtboxContactID.Text);
            c.Firstname = txtboxFirstName.Text;
            c.ContactNo = txtboxContactNumber.Text;
            c.Address = txtboxAddress.Text;
            c.Gender = cmbGender.Text;

            //update data in the database
            bool success = c.Update(c);
            if (success == true)
            {
                //success
                MessageBox.Show("Contact has been Successfully updated");

                //load data on DataGridView
                DataTable dt = c.Select();
                dgvContactList.DataSource = dt;

                //clear
                clear();
            }
            else
            {
                MessageBox.Show("Failed to update Contact. Try Again !");
            
            }
        }

        private void dgvContactList_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Getting the data from DataGrid View and loading it to the text boxes
            //Identify the row in which the mouse is clicked
            int rowIndex = e.RowIndex;
            txtboxContactID.Text = dgvContactList.Rows[rowIndex].Cells[0].Value.ToString();
            txtboxFirstName.Text = dgvContactList.Rows[rowIndex].Cells[1].Value.ToString();
            txtboxLastName.Text = dgvContactList.Rows[rowIndex].Cells[2].Value.ToString();
            txtboxContactNumber.Text = dgvContactList.Rows[rowIndex].Cells[3].Value.ToString();
            txtboxAddress.Text = dgvContactList.Rows[rowIndex].Cells[4].Value.ToString();
            cmbGender.Text = dgvContactList.Rows[rowIndex].Cells[5].Value.ToString();

        }

        private void dgvContactList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Getting the data from DataGrid View and loading it to the text boxes
            //Identify the row in which the mouse is clicked
            int rowIndex = e.RowIndex;
            txtboxContactID.Text = dgvContactList.Rows[rowIndex].Cells[0].Value.ToString();
            txtboxFirstName.Text = dgvContactList.Rows[rowIndex].Cells[1].Value.ToString();
            txtboxLastName.Text = dgvContactList.Rows[rowIndex].Cells[2].Value.ToString();
            txtboxContactNumber.Text = dgvContactList.Rows[rowIndex].Cells[3].Value.ToString();
            txtboxAddress.Text = dgvContactList.Rows[rowIndex].Cells[4].Value.ToString();
            cmbGender.Text = dgvContactList.Rows[rowIndex].Cells[5].Value.ToString();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //call clear here
            clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //get the data from datagrid view
            c.ContactID = Convert.ToInt32(txtboxContactID.Text);
            bool success = c.Delete(c);
            if (success == true)
            {
                //success
                MessageBox.Show("Contact Successfully Deleted");

                //load data on DataGridView
                DataTable dt = c.Select();
                dgvContactList.DataSource = dt;

                //clear
                clear();
            }
            else
            {
                MessageBox.Show("Failed to Delete Contact. Try Again !");

            }

        }

        private void lblContactNumber_Click(object sender, EventArgs e)
        {

        }

        public static string myconnstr = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        private void txtboxSearch_TextChanged(object sender, EventArgs e)
        {
            //get the value from text box
            string keyword = txtboxSearch.Text;
            
            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT *FROM contact WHERE FirstName LIKE '%" + keyword + "%' OR LastName LIKE '%" + keyword + "%' OR Address LIKE '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvContactList.DataSource = dt;

        }
    }
}

using System.Data.SqlClient;
using System.Data;

namespace LibraryUn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=MAHMOUD-LAPTOP\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.CommandText = "select   s.STUDENTID,    s.NAME,    count(b.BOOKID) as NumberOfBooksBorrowed from    STUDENT s left join    BORROW b on s.STUDENTID = b.STUDENTID group by   s.STUDENTID,  s.NAME order by  NumberOfBooksBorrowed desc";
            DataTable dt = new DataTable();
            dt.Load(sqlCommand.ExecuteReader());
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=MAHMOUD-LAPTOP\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.CommandText = "INSERT INTO BOOK (BOOKID , TITLE) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "');";
            sqlCommand.ExecuteNonQuery();
            sqlCommand.CommandText = "INSERT INTO AUTHOR (AUTHOR_NAME , AUTHOR_ID) VALUES ('" + textBox4.Text + "', '" + textBox3.Text + "');";
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=MAHMOUD-LAPTOP\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.CommandText = "UPDATE BOOK SET TITLE = '"+textBox2.Text+"'where BOOKID = '"+textBox1.Text+"'";
            sqlCommand.ExecuteNonQuery();
            sqlCommand.CommandText = "UPDATE AUTHOR SET AUTHOR_NAME = '" + textBox4.Text + "'where AUTHOR_ID = '" + textBox3.Text + "'";
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=MAHMOUD-LAPTOP\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.CommandText = " DELETE FROM BOOK WHERE BOOKID = '" + textBox1.Text + "' AND TITLE = '" + textBox2.Text + "'";
            sqlCommand.ExecuteNonQuery();
            sqlCommand.CommandText = " DELETE FROM AUTHOR WHERE AUTHOR_ID = '" + textBox3.Text + "' AND AUTHOR_NAME = '" + textBox4.Text + "'";
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=MAHMOUD-LAPTOP\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.CommandText = "SELECT * FROM STUDENT";
            DataTable dtStudent = new DataTable();
            dtStudent.Load(sqlCommand.ExecuteReader());
            dataGridView1.DataSource = dtStudent;
            sqlConnection.Close();

            System.Threading.Thread.Sleep(1000);

            sqlConnection.Open();
            sqlCommand.CommandText = @"
                SELECT
                    s.STUDENTID,
                    s.NAME AS StudentName,
                    b.SERIAL_NO_,
                    bk.BOOKID,
                    bk.TITLE AS BookTitle
                FROM
                    BORROW b
                JOIN
                    STUDENT s ON b.STUDENTID = s.STUDENTID
                JOIN
                    BOOK bk ON b.BOOKID = bk.BOOKID
                ORDER BY
                    s.STUDENTID, b.SERIAL_NO_";
            DataTable dtBorrowedBooks = new DataTable();
            dtBorrowedBooks.Load(sqlCommand.ExecuteReader());
            dataGridView1.DataSource = dtBorrowedBooks;
            sqlConnection.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }



    }
}

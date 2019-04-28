using System;
using System.Data.Common;
using System.Windows.Forms;
using SalesDB.DataAccess;

namespace SalesDB.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (listBox2.Items != null)
                listBox2.Items.Clear();

            SalesDBDataService service = new SalesDBDataService();
            DbDataReader dataReader = null;
            using (var connection = service.providerFactory.CreateConnection())
                using(var command = connection.CreateCommand())
            {
                try
                {
                    connection.ConnectionString = service.connectionString;
                    connection.Open();

                    command.CommandText = "Select * from Customers";
                    dataReader = command.ExecuteReader();

                    listBox2.Items.Add("Id\tИмя\t\tФамилия");
                    while (dataReader.Read())
                    {
                        listBox2.Items.Add(dataReader["Id"] + "\t" +
                            dataReader["Name"] + "\t\t" +
                            dataReader["Surname"]);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, exception.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (dataReader != null)
                        dataReader.Close();
                }
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (listBox2.Items != null)
                listBox2.Items.Clear();

            SalesDBDataService service = new SalesDBDataService();
            DbDataReader dataReader = null;
            using (var connection = service.providerFactory.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.ConnectionString = service.connectionString;
                    connection.Open();

                    command.CommandText = "Select * from Sellers";
                    dataReader = command.ExecuteReader();

                    listBox2.Items.Add("Id\tИмя\t\tФамилия");
                    while (dataReader.Read())
                    {
                        listBox2.Items.Add(dataReader["Id"] + "\t" +
                            dataReader["Name"] + "\t\t" +
                            dataReader["Surname"]);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, exception.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (dataReader != null)
                        dataReader.Close();
                }
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (listBox2.Items != null)
                listBox2.Items.Clear();

            SalesDBDataService service = new SalesDBDataService();
            DbDataReader dataReader = null;
            using (var connection = service.providerFactory.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.ConnectionString = service.connectionString;
                    connection.Open();
                    
                    command.CommandText = "Select sn.id, c.[surname] cSurname, s.[surname] sSurname, sn.trade_amount, sn.trade_date " +
                        "from SalesNote sn " +
                        "join Customers c on c.id = sn.customer_id " +
                        "join Sellers s on s.id = sn.seller_id";

                    dataReader = command.ExecuteReader();

                    listBox2.Items.Add(String.Format("{0,5} | {1,20}  {2,25} \t {3,15} \t {4,20}",
                           "Id", "Покупатель", "Продавец", "Сумма оплаты", "Дата покупки"));
                    while (dataReader.Read())
                    {
                        listBox2.Items.Add(String.Format("{0,5} | {1,20}  {2,25} \t {3,20} \t {4,20}",
                            dataReader["Id"], dataReader["cSurname"], dataReader["sSurname"], dataReader["Trade_Amount"], dataReader["Trade_Date"]));
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, exception.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (dataReader != null)
                        dataReader.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

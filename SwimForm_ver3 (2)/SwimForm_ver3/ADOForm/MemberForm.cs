using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
namespace ADOForm
{
    public partial class MemberForm : Form
    {

        private void ClearTextBoxes()
        {
            txtdate.Clear();
            txtid.Clear();
            txtName.Clear();
            txtadd.Clear();
            txtPhone.Clear();
        }

        DBClass dbc = new DBClass(); //*****DBClass 객체 생성


        public MemberForm()
        {
            InitializeComponent();
          //  dbc.DB_ObjCreate(); //*****
           // dbc.DB_Open_class();//*****
        }

        private void DAOpenBtn_Click(object sender, EventArgs
       e)
        { //전체 보기
            try
            {
                dbc.DB_ObjCreate(); //*****
                dbc.DB_Open();//*****
                dbc.DS.Clear();
              
                dbc.DBAdapter.Fill(dbc.DS, "member");
                DBGrid.DataSource = dbc.DS.Tables["member"].DefaultView;
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }
        }


        private void AppendBtn_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("텍스트 상자에 모든 데이터 입력 하셨으면 추가합니다!");
                // DS.Clear();//*
                // DBAdapter.Fill(DS, "Phone");//*
                dbc.PhoneTable = dbc.DS.Tables["member"];//*
                DataRow newRow = dbc.PhoneTable.NewRow();
                newRow["mem_date"] = txtdate.Text;
                newRow["mem_id"] = txtid.Text;
                newRow["mem_add"] = txtadd.Text;
                newRow["mem_name"] = txtName.Text;
                newRow["mem_phone"] = txtPhone.Text;
                newRow["mem_rrn"] = txtrrn.Text;
                dbc.PhoneTable.Rows.Add(newRow);
                dbc.DBAdapter.Update(dbc.DS, "member");
                dbc.DS.AcceptChanges();//*
                ClearTextBoxes(); //*
                DBGrid.DataSource = dbc.DS.Tables["member"].DefaultView;
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }
        }
        private void dataGridView1_CellClick(object sender,
       DataGridViewCellEventArgs e)
        {
            try
            {
                // DataSet DS = new DataSet();//*
                //DBAdapter.Fill(DS, "Phone");
                DataTable phoneTable = dbc.DS.Tables["member"];
                if (e.RowIndex < 0)
                {
                    // DBGrid의 컬럼 헤더를 클릭하면 컬럼을 정렬하므로
                    // 아무 메시지도 띄우지 않습니다. return;
                }
                else if (e.RowIndex > phoneTable.Rows.Count - 1)
                {
                    MessageBox.Show("해당하는 데이터가 존재하지 않습니다.");
                    return;
                }
                DataRow currRow = phoneTable.Rows[e.RowIndex];
                txtdate.Text = currRow["mem_date"].ToString();
                txtid.Text = currRow["mem_id"].ToString();
                txtadd.Text = currRow["mem_add"].ToString();
                txtName.Text = currRow["mem_name"].ToString();

                txtPhone.Text = currRow["mem_phone"].ToString();
                textBox2.Text = currRow["mem_id"].ToString();


                dbc.SelectedRowIndex = Convert.ToInt32(currRow["mem_id"]);
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //DS.Clear(); 
                //DBAdapter.Fill(DS, "Phone");
                dbc.PhoneTable = dbc.DS.Tables["member"];//*
                DataColumn[] PrimaryKey = new DataColumn[1];
                PrimaryKey[0] = dbc.PhoneTable.Columns["mem_id"];
                dbc.PhoneTable.PrimaryKey = PrimaryKey;
                DataRow currRow = dbc.PhoneTable.Rows.Find(dbc.SelectedRowIndex);
                currRow.BeginEdit();
                currRow["mem_date"] = txtdate.Text;
                currRow["mem_add"] = txtadd.Text;
                currRow["mem_id"] = txtid.Text;
                currRow["mem_name"] = txtName.Text;
                currRow["mem_phone"] = txtPhone.Text;

               // currRow["mem_id"] = textBox2.Text;

                currRow.EndEdit();
                DataSet UpdatedSet = dbc.DS.GetChanges(DataRowState.Modified);
                if (UpdatedSet.HasErrors)
                {
                    MessageBox.Show("변경된 데이터에 문제가 있습니다.");
                }
                else
                {
                    dbc.DBAdapter.Update(UpdatedSet, "member");
                    dbc.DS.AcceptChanges();
                }
                DBGrid.DataSource = dbc.DS.Tables["member"].DefaultView;
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }
        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // DS.Clear();
                // DBAdapter.Fill(DS, "Phone");
                dbc.PhoneTable = dbc.DS.Tables["member"];//*
                DataColumn[] PrimaryKey = new DataColumn[1];
                PrimaryKey[0] = dbc.PhoneTable.Columns["mem_id"];
                dbc.PhoneTable.PrimaryKey = PrimaryKey;
                DataRow currRow = dbc.PhoneTable.Rows.Find(dbc.SelectedRowIndex);
                currRow.Delete();
                dbc.DBAdapter.Update(dbc.DS.GetChanges(DataRowState.Deleted),
               "member");
                DBGrid.DataSource = dbc.DS.Tables["member"].DefaultView;
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

        private void DBGrid_CellContentClick(object sender,
       DataGridViewCellEventArgs e)
        {
        }
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Owner = this;
            frm2.ShowDialog();
            frm2.Dispose();
        }
        public String TxtS //속성 설정
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value.ToString(); }
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dbc.DB_ObjCreate(); //*****
                dbc.DB_Open_class();//*****
                dbc.DS.Clear();
              
                dbc.DBAdapter.Fill(dbc.DS, "class");
                //  phoneTable = DS.Tables["Phone"];//*
                dataGridView1.DataSource = dbc.DS.Tables["class"].DefaultView;
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // DataSet DS = new DataSet();//*
                //DBAdapter.Fill(DS, "Phone");
                DataTable classTable = dbc.DS.Tables["class"];
                if (e.RowIndex < 0)
                {
                    // DBGrid의 컬럼 헤더를 클릭하면 컬럼을 정렬하므로
                    // 아무 메시지도 띄우지 않습니다. return;
                }
                else if (e.RowIndex > classTable.Rows.Count - 1)
                {
                    MessageBox.Show("해당하는 데이터가 존재하지 않습니다.");
                    return;
                }
                DataRow currRow = classTable.Rows[e.RowIndex];
                textBox5.Text = currRow["cl_id"].ToString();
               

                dbc.SelectedRowIndex = Convert.ToInt32(currRow["cl_id"]);
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                String mem_id = textBox2.Text;
                String cl_id = textBox5.Text;
                String mycl_id = textBox1.Text;

                MessageBox.Show("수강신청완료!");
                // DS.Clear();//*
                // DBAdapter.Fill(DS, "Phone");//*
                dbc.DB_ObjCreate();
                dbc.DB_Open_myclass();
                dbc.DS.Clear();
                string strConn = "User Id=swim; Password = 1111; Data Source = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1522))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); ";
                OracleConnection conn = new OracleConnection(strConn);
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = $"INSERT INTO myclass (mycl_id, mem_id, cl_id) VALUES('{mycl_id}','{mem_id}','{cl_id}')";
                cmd.ExecuteNonQuery();
                conn.Close();
               
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dbc.DB_ObjCreate(); //*****
                dbc.DB_Open_myclass();//*****
                dbc.DS.Clear();

                dbc.DBAdapter.Fill(dbc.DS, "myclass");
                //  phoneTable = DS.Tables["Phone"];//*
                dataGridView1.DataSource = dbc.DS.Tables["myclass"].DefaultView;
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class Form2 : Form
    {
        new MemberForm Parent;
        //수정하거나 삭제하기 위해 선택된 행의 인덱스를 저장한다.
        private int SelectedRowIndex;
        // Data Provider인 DBAdapter 입니다.
        OracleDataAdapter DBAdapter;
        // DataSet 객체입니다.
        DataSet DS;
        // 추가, 수정, 삭제시에 필요한 명령문을 
        // 자동으로 작성해주는 객체입니다.
        OracleCommandBuilder myCommandBuilder;
        // ataTable 객체입니다.
        DataTable phoneTable;
        // 수정, 삭제할 때 필요한 레코드의 키값을 보관할 필드
        private int SelectedKeyValue;
        private void ClearTextBoxes()
        {
            txtid.Clear();
            txtName.Clear();
            txtPhone.Clear();
        }
        private void DB_Open()
        {
            try
            {
                string connectionString = "User Id=swim; Password = 1111; Data Source = " +
                    "(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)" +
                    "(PORT = 1522))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); ";
                string commandString = "select * from member";
                DBAdapter = new OracleDataAdapter(commandString, connectionString);
                myCommandBuilder = new OracleCommandBuilder(DBAdapter);
                DS = new DataSet();
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
        }
        public Form2()
        {
            InitializeComponent();
            DB_Open();
        }
        private void NameList_SelectedIndexChanged(object
       sender, EventArgs e)
        {
            //DS.Clear();
            //DBAdapter.Fill(DS, "Phone");
            Parent = (MemberForm)Owner;
            phoneTable = DS.Tables["member"];
            DataRow[] ResultRows = phoneTable.Select("mem_name like '%" + Parent.TxtS + "%'");


            DataColumn[] PrimaryKey = new DataColumn[1];
            PrimaryKey[0] = phoneTable.Columns["mem_id"];
            phoneTable.PrimaryKey = PrimaryKey;
            DataRow currRow = phoneTable.Rows.Find(NameList.Text.Substring(0, 2));
            SelectedKeyValue = Convert.ToInt32(currRow["mem_id"].ToString());
            txtid.Text = currRow["mem_id"].ToString();
            txtName.Text = currRow["mem_name"].ToString();
            txtPhone.Text = currRow["mem_phone"].ToString();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            DS.Clear();
            DBAdapter.Fill(DS, "member");
            Parent = (MemberForm)Owner;
            phoneTable = DS.Tables["member"];
            DataRow[] ResultRows
            = phoneTable.Select("mem_name like '%" +
           Parent.TxtS + "%'");
            NameList.Items.Clear();
            foreach (DataRow currRow in ResultRows)
            {
                NameList.Items.Add(currRow["mem_id"].ToString()
                + " " + currRow["mem_name"].ToString());
            }
        }

       
    }
}
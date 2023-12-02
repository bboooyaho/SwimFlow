using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;


namespace ADOForm
{
    public partial class MainForm : Form
    {
        DBClass dbc = new DBClass(); //*****DBClass 객체 생성

       
        public MainForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dbc.DB_ObjCreate(); //*****
                dbc.DB_Open();//*****
                dbc.DS.Clear();

                dbc.DBAdapter.Fill(dbc.DS, "member");
                DBGrid.DataSource = dbc.DS.Tables["member"].DefaultView;

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
        //        txtdate.Text = currRow["mem_date"].ToString();
          //      txtid.Text = currRow["mem_id"].ToString();
            //    txtadd.Text = currRow["mem_add"].ToString();
              //  txtName.Text = currRow["mem_name"].ToString();

                //txtPhone.Text = currRow["mem_phone"].ToString();
                //textBox2.Text = currRow["mem_id"].ToString();


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
    }
}

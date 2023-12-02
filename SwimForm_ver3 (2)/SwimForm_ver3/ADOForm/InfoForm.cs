using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOForm
{
    public partial class InfoForm : Form
    {
        string sqlstr;    //쿼리문 저장 변수
        DataRow currRow;
        DBClass dbc = new DBClass();  //*****DBClass 객체 생성

        public InfoForm()
        {
            InitializeComponent();
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            dbc.DB_ObjCreate(); //*****
            dbc.DB_Open();//*****
            dbc.DB_Access();//***

            information_display();

        }

        public void information_display() 
        {
            sqlstr = "Select Count(*) From member";      
            dbc.DCom.CommandText = sqlstr;
      //      dbc.DA.SelectCommand = dbc.DCom;  //*
        //    dbc.DA.Fill(dbc.DS, "sql_Result");
            dbc.DS.Tables["sql_Result"].Clear();
          //  dbc.DA.Fill(dbc.DS, "sql_Result");
            currRow = dbc.DS.Tables["sql_Result"].Rows[0];
            label7.Text = currRow[0].ToString() + "명";

            //sqlstr = "Select Count(*) From member";
            //dbc.DCom.CommandText = sqlstr;
            //dbc.DA.Fill(dbc.DS, "sql_Result");
            //dbc.DS.Tables["sql_Result"].Clear();
            //dbc.DA.Fill(dbc.DS, "sql_Result");
            //currRow = dbc.DS.Tables["sql_Result"].Rows[0];
            //Label4.Text = currRow[0].ToString() + "명";

            //sqlstr = "Select Count(*) From book Where b_lent is null ";
            //dbc.DCom.CommandText = sqlstr;
            //dbc.DA.Fill(dbc.DS, "sql_Result");
            //dbc.DS.Tables["sql_Result"].Clear();
            //dbc.DA.Fill(dbc.DS, "sql_Result");
            //currRow = dbc.DS.Tables["sql_Result"].Rows[0];
            //Label6.Text = currRow[0].ToString() + "권";

            //sqlstr = "Select Count(*) From member Where m_lent <> 0";
            //dbc.DCom.CommandText = sqlstr;
            //dbc.DA.Fill(dbc.DS, "sql_Result");
            //dbc.DS.Tables["sql_Result"].Clear();
            //dbc.DA.Fill(dbc.DS, "sql_Result");
            //currRow = dbc.DS.Tables["sql_Result"].Rows[0];
            //Label8.Text = currRow[0].ToString() + "명";

        }
    }
}

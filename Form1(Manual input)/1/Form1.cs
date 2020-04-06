using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace _1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=aero;Integrated Security=True";

        //    // Создание подключения
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    try
        //    {
        //        // Открываем подключение
        //        connection.Open();
        //        tbRequest.Text="Подключение открыто";
        //    }
        //    catch (SqlException ex)
        //    {
        //        tbRequest.Text = ex.Message;

        //    }
        //    finally
        //    {
        //        // закрываем подключение
        //        connection.Close();
        //        //tbRequest.Text = "Подключение закрыто";

        //    }
        //}

        //private void datGridDBTables_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}
        private void MainForm_Load(object sender, EventArgs e)
        {
            //на загрузку формы:
            UserReq = new DBRequest();//клас для управления
            StructTab = new DataTable("TabFields");//инициализация таблицы структуры
            DataColumn NewDatCol = new DataColumn("Tables", Type.GetType("System.String"));
            NewDatCol.AllowDBNull = false;
            NewDatCol.Unique = true;
            StructTab.Columns.Add(NewDatCol);//добавляет в таблицу структуры 1 колонку
            NewDatCol = new DataColumn("Fields", Type.GetType("System.String"));
            NewDatCol.AllowDBNull = false;
            NewDatCol.DefaultValue = "none";
            StructTab.Columns.Add(NewDatCol);//добавляет в таблицу структуры 2 колонку

            datGridDBTables.DataSource = StructTab;//выбор датасорса для первого грида в таблице структуры
            datGridDBTables.ReadOnly = false;
            datGridSQLResult.DataSource = RequestTab;//выбор датасорса для второго грида в таблице запросов
            StructTab.RowChanged += new DataRowChangeEventHandler(StructTab_OnRowChanged);//обработчик события для изменения рядочка
        }
        private void StructTab_OnRowChanged(object sender, DataRowChangeEventArgs e)
        {
            try
            {
                if (LastTabName != (string)e.Row["Tables"])//если последнее название таблицы не ровно (?)
                {
                    LastTabName = (string)e.Row["Tables"];//то последнее название таблицы ровно (?)
                    string Fields = UserReq.GetTableFields(LastTabName);//вытягивание названия полей
                    e.Row["Fields"] = Fields;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//меседж бокс с ошибкой
            }
        }
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            bool Connected = false;
            Cursor = Cursors.WaitCursor;//курсор ожидания
            try
            {
                UserReq.Disconnect();//отключиться 
                UserReq.ConnectTo(tbDatSource.Text, tbInitCat.Text);//подключиться по новой
                Connected = true;
            }
            catch (Exception e1)
            {
                MessageBox.Show(this, e1.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//меседж бокс с ошибкой
                Connected = false;
            }
            if (Connected)//если подключено - сделать элементы доступными
            {
                tbRequest.Enabled = true;
                btnRequest.Enabled = true;
                datGridSQLResult.Enabled = true;
                datGridDBTables.Enabled = true;

                //заметки для другой версии
                //string sql = "SELECT [Name] FROM sys.tables WHERE type_desc = 'USER_TABLE'";
                //string[] row = { "Users","Hello" };
                //StructTab.Rows.Add(row);
                //MessageBox.Show($"{StructTab.Rows.Count}");
                //datGridDBTables.DataSource = StructTab;
            }
            else//в другом случае - недоступными
            {
                tbRequest.Enabled = false;
                btnRequest.Enabled = false;
                datGridSQLResult.Enabled = false;
                datGridDBTables.Enabled = false;

                
            }
            Cursor = Cursors.Arrow;//курсор - стрелочка
            try
            {
                StructTab.Clear(); //почистить таблицы
                RequestTab.Clear(); 
            }
            catch
            {

            }
        }

        private void BtnRequest_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;//курсор - ожидание
            try
            {
                RequestTab = UserReq.SQLRequest(tbRequest.Text); //записать запрос в таблицу !!!!!!!!!!!!
                datGridSQLResult.DataSource = RequestTab; //ресурс - эта таблица
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Request Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //меседж бокс с ошибкой
            }
            Cursor = Cursors.Arrow;
        }

        private void DatGridDBTables_MouseUp(object sender, MouseEventArgs e)//при клике на таблицу оно выводить запрос всего из таблицы
        {
            DataGridView.HitTestInfo HitInfo = datGridDBTables.HitTest(e.X, e.Y);            
            if ((HitInfo.RowIndex >= 0) && (HitInfo.RowIndex < StructTab.Rows.Count))
            {                
                tbRequest.Text = "SELECT * FROM " + (string)StructTab.Rows[HitInfo.RowIndex]["Tables"];
                BtnRequest_Click(this, null);
            }
        }

        private void DatGridDBTables_Resize(object sender, EventArgs e)
        {
            
        }
    }
}


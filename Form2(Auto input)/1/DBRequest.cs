using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace _1
{
    public class DBRequest
    {
        public SqlDataAdapter GetAdapter(string Query)
        {
            return new SqlDataAdapter(Query, DBCon);
        }
        private SqlConnection DBCon = new SqlConnection(); //создает обьект Connection
        public void ConnectTo(string DataSource, string InitialCatalog)//.\SQLEXPRESS  //usersdb //подключаеться к базе данных
        {
            string connectionString = $@"Data Source={DataSource};Initial Catalog={InitialCatalog};Integrated Security=True";//строка подключения
            DBCon.ConnectionString = connectionString;
            try
            {
                DBCon.Open();//открытие подключения
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public void Disconnect() //закрытие подключения
        {
            try
            {
                if (DBCon.State == ConnectionState.Open)//если открыто
                    DBCon.Close(); //закрыть
            }
            catch
            {

            }
        }
        ~DBRequest() //деструктор
        {
            Disconnect();
        }
        public string GetTableFields(string TableName)//название полей таблицы
        {
            if (DBCon.State == ConnectionState.Open)//проверка, открыто ли подключение 
            {
                DataTable CurTable = new DataTable("ConnectedTab"); //таблица
                SqlDataAdapter DBAdapt; //обрабатывает запросы к БД
                try
                {
                    DBAdapt = new SqlDataAdapter("SELECT * FROM " + TableName, DBCon); //Запрос забирает все из таблицы
                    DBAdapt.Fill(CurTable); //заполнение таблицы выборкой
                }
                catch(Exception e)
                {
                    throw e;
                }
                string ResStr = ""; //результующая строка
                int ColCount = CurTable.Columns.Count; //количество столбцов
                for(int i=0;i<ColCount;i++)
                {
                    string StrCon = ", ";//окончание строки
                    if (i == ColCount - 1)//если конец, то ;
                        StrCon = ";";
                    ResStr += CurTable.Columns[i].ColumnName + "[" + CurTable.Columns[i].DataType.Name + "]" + StrCon;//название столбца[тип данных], .. ;
                }
                return ResStr;
            }
            else
                return null;
        }
        public DataTable SQLRequest(string RequestStr)//возвращает выборку по запросу
        {
            if (DBCon.State == ConnectionState.Open)//если подключение открыто
            {
                DataTable ResultTab = new DataTable("SQLresult");//таблица
                SqlDataAdapter DBAdapt;//адаптер
                try
                {
                    DBAdapt = new SqlDataAdapter(RequestStr, DBCon);//выборка в адаптер
                    DBAdapt.Fill(ResultTab);//заполнение таблицы
                }
                catch (Exception e)
                {
                    throw e;
                }
                return ResultTab;//возвращение таблицы
            }
            else
                return null;
        }
    }
}

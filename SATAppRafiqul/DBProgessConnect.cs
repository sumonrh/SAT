using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;


namespace SATAppRafiqul
{
    class DBProgressConnect
    {
        private SQLiteConnection connection;

        //Constructor
        public DBProgressConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            string connectionString;
            connectionString = "Data Source=SATBook.db;Version=3;";
            connection = new SQLiteConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (SQLiteException ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (SQLiteException ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return false;
            }
        }


        //Insert statement
        public void Insert(string uname, string dt, string scr)
        {
            string query = "INSERT INTO progresstable(username, date, score) VALUES ('" + uname + "', '" + dt + "', '" + scr + "');";

            try
            {
                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
            }
            catch (SQLiteException ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            
        }


        //Delete statement
        public void Delete(string uname, string dt)
        {
            string query = "DELETE FROM progresstable WHERE username='" + uname + "' and date ='" + dt + "';";

            if (this.OpenConnection() == true)
            {
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        /// <summary>
        /// This Select method reads the entire MYSQL table and returns a DataTable
        /// </summary>
        /// <returns></returns>

        public DataTable Read(string uname)
        //public DataTable Read()
        {
            string query = "SELECT * FROM progresstable WHERE username = '"+uname+"'";
            //string query = "SELECT * FROM progresstable";
            //DataTable dtable;

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                //Create a data reader and Execute the command
                SQLiteDataReader dataReader = cmd.ExecuteReader();
                DataTable dtSchema = dataReader.GetSchemaTable();
                DataTable dtable = new DataTable();
                // You can also use an ArrayList instead of List<>
                List<DataColumn> listCols = new List<DataColumn>();

                if (dtSchema != null)
                {
                    foreach (DataRow drow in dtSchema.Rows)
                    {
                        string columnName = System.Convert.ToString(drow["ColumnName"]);
                        DataColumn column = new DataColumn(columnName, (Type)(drow["DataType"]));
                        column.Unique = (bool)drow["IsUnique"];
                        column.AllowDBNull = (bool)drow["AllowDBNull"];
                        column.AutoIncrement = (bool)drow["IsAutoIncrement"];
                        listCols.Add(column);
                        dtable.Columns.Add(column);
                    }
                }

                // Read rows from DataReader and populate the DataTable
                while (dataReader.Read())
                {
                    DataRow dataRow = dtable.NewRow();
                    for (int i = 0; i < listCols.Count; i++)
                    {
                        dataRow[((DataColumn)listCols[i])] = dataReader[i];
                    }
                    dtable.Rows.Add(dataRow);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return dtable;
            }
            else
            {
                return null;
            }
        }

        //Count statement
        /// <summary>
        /// This method counts the number of rows in the geo_info database and returns an integer value
        /// </summary>
        /// <returns></returns>
        public int Count(string uname)
        {
            //string query = "SELECT Count(*) FROM progresstable";
            //string query = "SELECT * FROM progresstable";
            string query = "SELECT * FROM progresstable WHERE username = '"+uname+"'";
            int Count = 0;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                SQLiteDataReader SqltRdr = cmd.ExecuteReader();
                //ExecuteScalar will return one value
                while (SqltRdr.Read())
                {
                    Count++;
                }

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return -1;
            }
        }


        /*public int UandP_Exists(string uname, string pword)
        {
            string query = "SELECT * FROM progresstable where username ='" + uname + "' and password = '" + pword + "'";
            int Count = 0;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                SQLiteDataReader SqltRdr = cmd.ExecuteReader();
                //ExecuteScalar will return one value
                //Count = (Int32)cmd.ExecuteScalar();
                while (SqltRdr.Read())
                {
                    Count++;
                }

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return -1;
            }
        }*/

        public int U_Exists(string uname)
        {
            string query = "SELECT * FROM progresstable where username ='" + uname + "'";
            int Count = 0;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                SQLiteDataReader SqltRdr = cmd.ExecuteReader();
                //ExecuteScalar will return one value
                while (SqltRdr.Read())
                {
                    Count++;
                }

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return -1;
            }
        }
    }
}
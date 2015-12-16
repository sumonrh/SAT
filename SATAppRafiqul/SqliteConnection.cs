using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace SAT_Application
{
    class DBConnect
    {
        private SQLiteConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "yourbook";
            uid = "root";
            password = "Sumon1984#";
            string connectionString;

            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
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
                //When handling errors, your application can response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        //MessageBox.Show("Cannot connect to server.  Contact administrator");
                        System.Windows.MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        //MessageBox.Show("Invalid username/password, please try again");
                        System.Windows.MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
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
        public void Insert(string id, string fy, string fc, string b, string h, string cv, string Ast, string Mu)
        {
            //string query = "INSERT INTO geo_info (MU) VALUES('Moment')";
            string query = "INSERT INTO geo_info(ID, FY, FC, WIDTH, HEIGHT, COVER, AST, MU) VALUES ('" + id + "', '" + fy + "', '" + fc + "', '" + b + "', '" + h + "', '" + cv + "', '" + Ast + "', '" + Mu + "');";

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

        //Update statement
        public void Update(string i, string fy, string fc, string b, string h, string cv, string Ast, string Mu)
        //public void Update(string i, string Mu)
        {

            //string query = "UPDATE `beam_details`.`geo_info` SET `FY`='"+fy+"', `FC`='"+fc+"', `WIDTH`='"+b+"', `HEIGHT`='"+h+"', `COVER`='"+cv+"', `AST`='"+Ast+"', `MU`='"+Mu+"';";
            string query = "UPDATE `beam_details`.`geo_info` SET `FY`='" + fy + "', `FC`='" + fc + "', `WIDTH`='" + b + "', `HEIGHT`='" + h + "', `COVER`='" + cv + "', `AST`='" + Ast + "', `MU`='" + Mu + "' WHERE `ID`='" + i + "';";
            //string query = "UPDATE `beam_details`.`geo_info` SET `MU`='" + Mu + "' WHERE `ID`='" + i + "';";


            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                SQLiteCommand cmd = new SQLiteCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete(string i)
        {
            string query = "DELETE FROM geo_info WHERE ID='" + i + "';";

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

        public DataTable Read()
        {
            string query = "SELECT * FROM vocabultable";
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
        public int Count()
        {
            string query = "SELECT Count(*) FROM vocabultable";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                SQLiteCommand cmd = new SQLiteCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        /*
        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }*/

    }
}
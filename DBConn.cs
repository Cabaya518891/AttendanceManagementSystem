using MySql.Data.MySqlClient;

namespace SchedCover
{
    public sealed class DBConn
    {
        private static DBConn _instance;
        private string _connectionString = "server=localhost;database=ams_database;userid=root;password=;Convert Zero Datetime=True;";


        private DBConn() { }

        public static DBConn Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DBConn();
                }
                return _instance;
            }
        }

        public MySqlConnection Connection
        {
            get
            {
                return new MySqlConnection(_connectionString); // Always return a new connection
            }
        }
        

    }
}
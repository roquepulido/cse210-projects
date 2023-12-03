using MySqlConnector;

class DBConnect
{
    private MySqlConnection connection;
    private string server;
    private string database;
    private string user;
    private string password;
    private bool _isOnline;
    public bool IsOnline
    {
        get { return _isOnline; }
        set { _isOnline = value; }
    }


    //Constructor
    public DBConnect(string server, string database, string user, string password)
    {
        Initialize(server, database, user, password);
    }
    public DBConnect()
    {
        string s = "67.227.144.24";
        string d = "grupoagi_test_goal";
        string u = "grupoagi_test_goal";
        string p = "RoqueAlbertoPulidoMorales";
        Initialize(s, d, u, p);
    }

    //Initialize values
    private void Initialize(string s, string db, string u, string p)
    {
        server = s;
        database = db;
        user = u;
        password = p;
        string connectionString;
        connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + user + ";" + "PASSWORD=" + password + ";";

        connection = new MySqlConnection(connectionString);
    }
    //open connection to database
    private bool OpenConnection()
    {
        try
        {
            connection.Open();
            this.IsOnline = true;
            return true;
        }
        catch (MySqlException ex)
        {
            //When handling errors, you can your application's response based 
            //on the error number.
            //The two most common error numbers when connecting are as follows:
            //0: Cannot connect to server.
            //1045: Invalid user name and/or password.
            System.Console.WriteLine(ex.Message);
            this.IsOnline = false;
            return false;
        }
    }

    //Close connection
    private void CloseConnection()
    {
        try
        {
            connection.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    //Insert statement
    public int Insert(string goalData, int goalType)
    {
        string query = $"INSERT INTO goals (goal_data,goal_type) VALUES('{goalData}',{goalType})";
        int row = 0;
        //open connection
        if (this.OpenConnection())
        {
            //create command and assign the query and connection from the constructor
            MySqlCommand cmd = new(query, connection);

            //Execute command
             cmd.ExecuteNonQuery();

             row = (int)cmd.LastInsertedId;

            //close connection
            this.CloseConnection();
        }
        return row;
    }

    //Update statement
    public void Update(string goalData, int id)
    {
        string query = $"UPDATE goals SET goal_data='{goalData}' WHERE id={id}";

        //Open connection
        if (this.OpenConnection())
        {
            //create mysql command
            MySqlCommand cmd = new()
            {
                //Assign the query using CommandText
                CommandText = query,
                //Assign the connection using Connection
                Connection = connection
            };

            //Execute query
            cmd.ExecuteNonQuery();

            //close connection
            this.CloseConnection();
        }
    }

    //Delete statement
    public void Delete(int id)
    {
        string query = $"DELETE FROM goals WHERE id={id}";

        if (this.OpenConnection())
        {
            MySqlCommand cmd = new(query, connection);
            cmd.ExecuteNonQuery();
            this.CloseConnection();
        }
    }
    public List<TableGoal> SelectAll()
    {
        string query = "SELECT * FROM goals";

        //Create a list to store the result
        List<TableGoal> list = new();

        //Open connection
        if (this.OpenConnection())
        {
            //Create Command
            MySqlCommand cmd = new(query, connection);
            //Create a data reader and Execute the command
            using (MySqlDataReader dataReader = cmd.ExecuteReader())

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list.Add(new TableGoal(dataReader["id"], dataReader["goal_data"], dataReader["goal_type"]));
                }


            //close Connection
            this.CloseConnection();

            //return list to be displayed
            return list;
        }
        else
        {
            return list;
        }
    }
    public TableGoal SelectById(int id)
    {
        string query = $"SELECT * FROM goals WHERE id={id}";

        //Open connection
        if (this.OpenConnection())
        {
            //Create Command
            MySqlCommand cmd = new(query, connection);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            //Read the data and store them in the list
            dataReader.Read();

            TableGoal tableGoal = new(dataReader["id"], dataReader["goal_data"], dataReader["goal_type"]);


            //close Data Reader
            dataReader.Close();

            //close Connection
            this.CloseConnection();

            //return list to be displayed
            return tableGoal;
        }
        else
        {
            return null;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using MySql.Data.MySqlClient;

public class mysql_script : MonoBehaviour {

	void Start () {
        Mysql();
	}

	void Mysql()
    {
        MySqlConnection conn = new MySqlConnection();
        string DataConecction = "Server=localhost;Database=tutorial;Uid=root;Pwd=1234;";

        conn.ConnectionString = DataConecction;

        try
        {
            conn.Open();
            Debug.Log("Conexión establecida");
        }
        catch(MySqlException error)
        {
            Debug.Log("Conexión fallida: " + error);
        }
    }
}

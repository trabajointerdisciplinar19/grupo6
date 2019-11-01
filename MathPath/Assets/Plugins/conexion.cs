using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class conexion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        conectar();
    }

    // Update is called once per frame
    void conectar()
    {
        string conn = "URI=file:" + Application.dataPath + "/Plugins/juego.db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT * FROM Usuario";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            string value = reader.GetString(0);
            string name = reader.GetString(1);
            int rand = reader.GetInt32(2);
            Debug.Log("Nickname= " + value + " Password= " + name + " Score= " + rand);

        }
        Debug.Log("Nickname= HI");
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}

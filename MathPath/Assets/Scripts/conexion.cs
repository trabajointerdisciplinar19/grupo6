using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.UI;

public class conexion : MonoBehaviour
{
    public GameObject Input;
    public GameObject Input2;
 

    // Update is called once per frame
    public void conectar()
    {
        string conn = "URI=file:" + Application.dataPath + "/Plugins/juego.db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "INSERT INTO Usuario (Nickname, Contraseña, Puntaje) VALUES ('" + Input.GetComponent<Text>().text+"' , '" + Input2.GetComponent<Text>().text + "' , '" + 0 + "')";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            string value = reader.GetString(0);
            string name = reader.GetString(1);
            int rand = reader.GetInt32(2);
            Debug.Log("Nickname= " + value + " Password= " + name + " Score= " + rand);
            
        }
        Debug.Log("Nickname= REGISTRADO");
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}

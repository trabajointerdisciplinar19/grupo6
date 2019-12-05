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
    public GameObject Input5;
    public GameObject Input3;
    public GameObject Input4;
    public GameObject login;
    public Button btnLogin;
    private string usuario;
    private string password;



    // Update is called once per frame
    public void conectar()
    {
        string conn = "URI=file:" + Application.dataPath + "/Plugins/juego.db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "INSERT INTO Usuario (Nickname, Contraseña, Puntaje, Nota) VALUES ('" + Input.GetComponent<Text>().text+"' , '" + Input2.GetComponent<Text>().text + "' , '" + 0 + "' , '" + Input5.GetComponent<Text>().text + "')";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        Debug.Log("Nickname= REGISTRADO");
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    } 

    public void validar()
    {
        
        usuario = Input3.GetComponent<InputField>().text;
        password = Input4.GetComponent<InputField>().text;
        btnLogin = login.GetComponent<Button>();
        btnLogin.onClick.AddListener(validateLogin);
     

    }
   
    public void validateLogin()
    {
        usuario = Input3.GetComponent<InputField>().text;
        password = Input4.GetComponent<InputField>().text;
        string conn = "URI=file:" + Application.dataPath + "/Plugins/juego.db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT * FROM Usuario WHERE Nickname = '"+usuario+"'"+" AND "+"Contraseña ="+"'"+password+"'";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        int c = 0;
        while(reader.Read())
        {
            c++;
        }
        if(c>0)
        {
            Debug.Log("Se inicio sesión correctamente");
            Application.LoadLevel("menu");
        }
        else
        {
            Debug.Log("Contraseña o usuario incorrectos");

        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}

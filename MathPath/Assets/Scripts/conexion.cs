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
    public InputField Input6;
    public InputField Input7;
    public Button resp1;
    public Text tes1;
    public Text tes2;
    public Button resp2;
    public Button emp;
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
   
    public int random1()
    {
        System.Random r = new System.Random();
        int res = r.Next(10, 100);
        return res;
    }
    public int random2()
    {
        System.Random r = new System.Random();
        int res = r.Next(101, 200);
        return res;
    }
    public void empezar()
    {
        int r1 = random1();
        string res1 = r1.ToString();
        Input6.text  = res1;
        int r2 = random2();
        string res2 = r2.ToString();
        Input7.text = res2;
        int correcta = r1 + r2;
        string res3 = correcta.ToString();
        tes1.text= res3;
        int incorrecta = (r1 + r2)+70;
        string res4 = incorrecta.ToString();
        tes2.text = res4;
    }
    public void empezar2()
    {
        int r1 = random1();
        string res1 = r1.ToString();
        Input6.text = res1;
        int r2 = random2();
        string res2 = r2.ToString();
        Input7.text = res2;
        int correcta = r2 - r1;
        string res3 = correcta.ToString();
        tes1.text = res3;
        int incorrecta = (r2 - r1) + 50;
        string res4 = incorrecta.ToString();
        tes2.text = res4;
    }
    public void seguir()
    {

    }
    public void perder()
    {
        Application.LoadLevel("gameover");
    }


}

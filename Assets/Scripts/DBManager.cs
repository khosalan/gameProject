using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager 
{
    public static string userName;
    public static int playerID;

    public static bool LoggedIn { get { return userName != null; } }

    public static void LogOut()
    {
        userName = null;
    }
}

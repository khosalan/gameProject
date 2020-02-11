using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager 
{
    public static string userName;
    public static int playerID;

    private const double versionNumber = 1.02;
    public static bool LoggedIn { get { return userName != null; } }

    public static double VersionNumber { get { return versionNumber; } }

    public static void LogOut()
    {
        userName = null;
    }
}

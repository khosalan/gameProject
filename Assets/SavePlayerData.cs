using UnityEngine;
using System.IO; //to work with files in OS
using System.Runtime.Serialization.Formatters.Binary; //allow us to access binary formatters

//static class as we can instantiate
public static class SavePlayerData
{
    //can call it from anywhere
    public static void SavePlayerLogin(Login login)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.vita"; //path depends on OS, so used application.persistentPath which gets a path from a data diredctory on OS
        FileStream stream = new FileStream(path,FileMode.OpenOrCreate); //to work with file        

        PlayerData data = new PlayerData(login);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayerLogin()
    {
        string path = Application.persistentDataPath + "/player.vita";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData; //cast the information as PlayerData type
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Saved file not found in " + path);
            return null;
        }
    }
}

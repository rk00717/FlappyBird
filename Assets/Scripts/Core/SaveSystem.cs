using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem{
    static string PATH = Application.persistentDataPath + "/score.rkode";

    public static void SaveScore(GameControllerScript gameController){
        BinaryFormatter formatter = new BinaryFormatter();
        // string PATH = Application.presistentDataPath + "/score.rkode";
        FileStream stream = new FileStream(PATH, FileMode.Create);

        GameData data = new GameData(gameController);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadScore(){
        if(File.Exists(PATH)){
            BinaryFormatter formatter = new BinaryFormatter();
            // string PATH = Application.presistentDataPath + "/score.rkode";
            FileStream stream = new FileStream(PATH, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;

            stream.Close();
            
            return data;
        }else{
            Debug.Log("File Not Found..");
        }
        return null;
    }
}
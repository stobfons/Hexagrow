using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveGame
{
    public static void save(LoaderObject gameData){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/hexagrowTest2.svg";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, gameData);
        stream.Close();
    }

    public static LoaderObject load(){
        string path = Application.persistentDataPath + "/hexagrowTest2.svg";
        if(File.Exists(path)){
        Debug.Log("Save Found! "+ path);
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        LoaderObject data = formatter.Deserialize(stream) as LoaderObject;
        stream.Close();
        return data;

        } else {
            Debug.LogError("Save not found.");
            LoaderObject newLoaderFile = new LoaderObject();
            save(newLoaderFile);
            return null;
        }

    }
}

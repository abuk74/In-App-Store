using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveInfo(Item item)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/item.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        SerializableItemInfo data = new SerializableItemInfo(item);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static SerializableItemInfo LoadInfo()
    {
        string path = Application.persistentDataPath + "/item.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SerializableItemInfo data = formatter.Deserialize(stream) as SerializableItemInfo;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}

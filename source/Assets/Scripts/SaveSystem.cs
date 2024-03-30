using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
public static class SaveSystem
{
    public static void SavePlayer (LevelComplete levelComplete){

        BinaryFormatter binaryFormatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/player.sav";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(levelComplete);

        binaryFormatter.Serialize(fileStream, data);
        fileStream.Close();

    }

    public static PlayerData LoadPlayer(){
        
        string path = Application.persistentDataPath + "/player.sav";
        if(File.Exists(path)){
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            PlayerData data = binaryFormatter.Deserialize(fileStream) as PlayerData;
            fileStream.Close();
            return data;
        }else
        {
            Debug.LogError("No file save exist");
            return null;
        }
    }

    public static void SaveShop(){
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/shop.sav";
        FileStream fileStream = new FileStream(path, FileMode.Create);
        ShopData data = new ShopData();
        binaryFormatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static ShopData LoadShop(){
        string path = Application.persistentDataPath + "/shop.sav";
        if(File.Exists(path)){
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            ShopData data = binaryFormatter.Deserialize(fileStream) as ShopData;
            fileStream.Close();
            return data;
        }else{
            Debug.LogError("No file save shop exist");
            return null;
        }

    }
    public static void SaveDiamonds(){
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/diamonds.sav";
        FileStream fileStream = new FileStream(path, FileMode.Create);
        DiamomdsData data = new DiamomdsData();
        binaryFormatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static DiamomdsData LoadDiamonds(){
        string path = Application.persistentDataPath + "/diamonds.sav";
        if(File.Exists(path)){
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            DiamomdsData data = binaryFormatter.Deserialize(fileStream) as DiamomdsData;
            fileStream.Close();
            return data;
        }else{
            Debug.LogError("No file save diamonds exist");
            return null;
        }
    }
}

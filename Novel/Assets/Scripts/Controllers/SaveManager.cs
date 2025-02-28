using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private static string SAVED_GAME = "savedGame";

    public static void SaveGame(SaveData data)
    {
        data.prevScenes = data.prevScenes.FindAll(index => index >= 0);
        PlayerPrefs.SetString(SAVED_GAME, JsonUtility.ToJson(data));
    }

    public static SaveData LoadGame()
    {
        string savedGameJson = PlayerPrefs.GetString(SAVED_GAME);
        if (string.IsNullOrEmpty(savedGameJson))
        {
            return new SaveData(); 
        }

        SaveData loadedData = JsonUtility.FromJson<SaveData>(savedGameJson);
        if (loadedData.prevScenes == null || loadedData.prevScenes.Count == 0)
        {
            loadedData.prevScenes = new List<int>();
        }

        return loadedData;
    }


    public static bool IsGameSaved()
    {
        return PlayerPrefs.HasKey(SAVED_GAME);
    }

    public static void ClearSavedGame()
    {
        PlayerPrefs.DeleteKey(SAVED_GAME);
    }
}
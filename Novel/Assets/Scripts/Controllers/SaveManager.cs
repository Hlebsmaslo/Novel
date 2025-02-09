using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private static string SAVED_GAME = "savedGame";

    public static void SaveGame(SaveData data)
    {
        data.prevScenes = data.prevScenes.FindAll(index => index >= 0);

        // Лог для отладки
        Debug.Log("Saving prevScenes: " + string.Join(", ", data.prevScenes));

        PlayerPrefs.SetString(SAVED_GAME, JsonUtility.ToJson(data));
    }

    public static SaveData LoadGame()
    {
        string savedGameJson = PlayerPrefs.GetString(SAVED_GAME);

        // Если сохранённых данных нет, создаём новый объект SaveData с дефолтными значениями
        if (string.IsNullOrEmpty(savedGameJson))
        {
            Debug.Log("No saved game found, returning default data.");
            return new SaveData(); // Возвращаем пустые данные
        }

        SaveData loadedData = JsonUtility.FromJson<SaveData>(savedGameJson);

        // Проверка на пустой список prevScenes
        if (loadedData.prevScenes == null || loadedData.prevScenes.Count == 0)
        {
            Debug.Log("prevScenes is empty, initializing default scenes.");
            loadedData.prevScenes = new List<int>(); // Можно добавить стартовые сцены по умолчанию, если нужно
        }

        // Лог для отладки
        Debug.Log("Loaded prevScenes: " + string.Join(", ", loadedData.prevScenes));

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
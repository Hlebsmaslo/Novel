using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private static string SAVED_GAME = "savedGame";

    public static void SaveGame(SaveData data)
    {
        data.prevScenes = data.prevScenes.FindAll(index => index >= 0);

        // ��� ��� �������
        Debug.Log("Saving prevScenes: " + string.Join(", ", data.prevScenes));

        PlayerPrefs.SetString(SAVED_GAME, JsonUtility.ToJson(data));
    }

    public static SaveData LoadGame()
    {
        string savedGameJson = PlayerPrefs.GetString(SAVED_GAME);

        // ���� ���������� ������ ���, ������ ����� ������ SaveData � ���������� ����������
        if (string.IsNullOrEmpty(savedGameJson))
        {
            Debug.Log("No saved game found, returning default data.");
            return new SaveData(); // ���������� ������ ������
        }

        SaveData loadedData = JsonUtility.FromJson<SaveData>(savedGameJson);

        // �������� �� ������ ������ prevScenes
        if (loadedData.prevScenes == null || loadedData.prevScenes.Count == 0)
        {
            Debug.Log("prevScenes is empty, initializing default scenes.");
            loadedData.prevScenes = new List<int>(); // ����� �������� ��������� ����� �� ���������, ���� �����
        }

        // ��� ��� �������
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
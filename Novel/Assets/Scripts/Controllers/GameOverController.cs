using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;


public class GameOverController : MonoBehaviour
{
    public string gameScene;
    public string menuScene;



    public void NewGame1()
    {
        SaveManager.ClearSavedGame();
        SceneManager.LoadScene(gameScene, LoadSceneMode.Single);
    }
    public void Menu1()
    {
        SaveManager.ClearSavedGame();
        SceneManager.LoadScene(menuScene, LoadSceneMode.Single);
    }


}

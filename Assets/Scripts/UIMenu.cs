using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class UIMenu : MonoBehaviour
{

    public TMP_Text bestScoreText;
    public string textInput;
    public TMP_InputField nameInput;

    private void Start()
    {
        MainManager.Instance.LoadHighScore();

        if(MainManager.Instance != null)
        {
            if (MainManager.Instance.highScore!= 0)
            {
                DisplayHighScore();
            }
            else
            {
                DisplayName();
            }
        }
        else
        {
            bestScoreText.text = "Hello, set a high score!";
        }
        
    }

    public void SavePlayerName()
    {
        textInput = nameInput.text;
        MainManager.Instance.sessionName = textInput;
    }

    void DisplayHighScore()
    {
        bestScoreText.text = "The current high score is " + MainManager.Instance.highScore + " set by " + MainManager.Instance.playerName;
    }
   
    void DisplayName()
    {
        bestScoreText.text = MainManager.Instance.sessionName + ", set a high score!";
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
    }
}

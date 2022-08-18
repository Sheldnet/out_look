using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuScript : MonoBehaviour
{
    public TMP_Text playerdisplay;
    private void Start()
    {
        if (DBManager.LoggedIn)
        {
            playerdisplay.text = DBManager.username;
        }
    }
    public void ExitGame()
    {
        DBManager.LogOut();
        Debug.Log("ВЫХОД!");
        Application.Quit();
    }

    public void StartLevel(int scenum)
    {
        SceneManager.LoadScene(scenum);
    }
    
    public void ChangeAccount(int scenum)
    {
        SceneManager.LoadScene(scenum);
        DBManager.LogOut();
    }    
}

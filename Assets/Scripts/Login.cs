using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Login : MonoBehaviour
{
    public TMP_InputField passwordField;
    public TMP_InputField usernameField;

    public Button submitButton;

    public void CallLogin()
    {
        StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer()
    {
        WWWForm form = new WWWForm();
        form.AddField("nickname", usernameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);
        yield return www;
        if (www.text[0] == '0')
        {
            DBManager.username = usernameField.text;
            DBManager.userID = int.Parse(www.text.Split('\t')[1]);
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("User login failed! Error #" + www.text);
        }
    }

    public void VerifyInput()
    {
        submitButton.interactable = (passwordField.text.Length > 0 && usernameField.text.Length > 0);
    }
}

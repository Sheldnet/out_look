using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Registration : MonoBehaviour
{
    public TMP_InputField nicknameField;
    public TMP_InputField passwordField;
    public TMP_InputField emailField;
    public TMP_InputField nameField;
    public TMP_InputField surnameField;

    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("nickname", nicknameField.text);
        form.AddField("password", passwordField.text);
        form.AddField("email", emailField.text);
        form.AddField("name", nameField.text);
        form.AddField("surname", surnameField.text);
        WWW www = new WWW("http://localhost/sqlconnect/register.php", form);
        yield return www;
        if(www.text[0] == '0')
        {
            Debug.Log("Account Registered");
            DBManager.username = nicknameField.text;
            DBManager.userID = int.Parse(www.text.Split('\t')[1]);
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("User creation failed! Error #" + www.text);
        }
    }

    public void VerifyInput()
    {
        submitButton.interactable = (nicknameField.text.Length >= 4 && passwordField.text.Length >= 5 && emailField.text.Length > 0 && nameField.text.Length > 0 && surnameField.text.Length > 0);
    }
}

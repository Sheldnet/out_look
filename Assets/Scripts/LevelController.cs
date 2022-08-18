using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    bool timerFlag = true;
    public KeyCode restart = KeyCode.R;

    public int levelnum;

    public float second, millisecond, minute = 0;

    public int storedsecond;

    public Text timerValue;
    public void EndGame()
    {
        
    }

    private void Update()
    {
        if (Input.GetKey(restart))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void FixedUpdate()
    {
        if (timerFlag)
        {
            millisecond += 0.02f;
            if (millisecond > 1)
            {
                second++;
                storedsecond++;
                millisecond = 0;
            }
            if (second == 60)
            {
                minute++;
                second = 0;

            }
        }
            timerValue.text = $"{minute} : {second}";
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            timerFlag = false;
            if (DBManager.LoggedIn == true)
            {
                CallSaveData();
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene(1);
            }
        }
    }

    public void CallSaveData()
    {
        StartCoroutine(SavePlayerData());
    }

    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", DBManager.username);
        form.AddField("uID", DBManager.userID);
        form.AddField("levelnum", levelnum);
        form.AddField("time", storedsecond);

        WWW www = new WWW("http://localhost/sqlconnect/savedata.php", form);
        yield return www;
        if (www.text[0] == '0')
        {
            Debug.Log("Data Saved!");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("Save failed. Error #" + www.text);
        }

        SceneManager.LoadScene(1);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DataRequest : MonoBehaviour
{
    private int levelnum1 = 1;
    private int levelnum2 = 2;
    public TMP_Text Time1;
    public TMP_Text Time2;

    public void CallLoadData()
    {
        if (gameObject.activeSelf)
        {
            if (DBManager.LoggedIn==true)
            {
                StartCoroutine(LoadPlayerData());
            }
        }
    }

    IEnumerator LoadPlayerData()
    {
        WWWForm form1 = new WWWForm();
        form1.AddField("username", DBManager.username);
        form1.AddField("uID", DBManager.userID);
        form1.AddField("levelnum", levelnum1);

        WWW www = new WWW("http://localhost/sqlconnect/loaddata.php", form1);
        yield return www;
        if (www.text[0] == '0')
        {
            DBManager.Time1 = www.text.Split('\t')[1];
            Time1.text = DBManager.Time1; 
        }
        else
        {
            Debug.Log("Load failed. Error #" + www.text);
        }

        WWWForm form2 = new WWWForm();
        form2.AddField("username", DBManager.username);
        form2.AddField("uID", DBManager.userID);
        form2.AddField("levelnum", levelnum2);

        WWW www2 = new WWW("http://localhost/sqlconnect/loaddata.php", form2);
        yield return www2;
        if (www2.text[0] == '0')
        {
            DBManager.Time2 = www2.text.Split('\t')[1];
            Time2.text = DBManager.Time2;
        }
        else
        {
            Debug.Log("Load failed. Error #" + www2.text);
        }
    }
}

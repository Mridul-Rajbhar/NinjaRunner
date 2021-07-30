using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WEB: MonoBehaviour
{
    private void Start()
    {
        //StartCoroutine(Login("Mridul", "qwerty"));
        StartCoroutine(Resgister("Dinesh", "qwerty"));
    }

    IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUserName", username);
        form.AddField("loginUserPassword", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Unity%20Zig%20Zag%20Runner/getData.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    IEnumerator Resgister(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("signUpUserName", username);
        form.AddField("signUpUserPassword", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Unity%20Zig%20Zag%20Runner/registerUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

}
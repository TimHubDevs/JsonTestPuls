using System;
using System.Collections;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class JsonDownloader : MonoBehaviour
{
    public void LoadData(Action<TestModel> testmodel)
    {
        string url =
            "https://firebasestorage.googleapis.com/v0/b/firsttask-4498a.appspot.com/o/test.json?alt=media&token=99193bbf-6291-4fa9-b316-f4a44a6da6f4";
        StartCoroutine(GetRequest(url, model => { testmodel.Invoke(model); }));
    }

    private IEnumerator GetRequest(string url, Action<TestModel> data)
    {
        Debug.Log(url);
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log("Error: " + webRequest.error);
            }
            else
            {
                Debug.Log("Received: " + webRequest.downloadHandler.text);
                TestModel tableModel = new TestModel();
                tableModel = Parse<TestModel>(webRequest.downloadHandler.text);
                data.Invoke(tableModel);
            }
        }
    }

    public Model Parse<Model>(string jsonArray)
    {
        Model model = JsonConvert.DeserializeObject<Model>(jsonArray);
        Debug.Log("" + model);
        return model;
    }
}
using System;
using System.Collections;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class JsonDownloader : MonoBehaviour
{
    [SerializeField] private GameObject content;

    private void Start()
    {
        StartCoroutine(CheckData());
    }

    public IEnumerator CheckData()
    {
        string url =
            "https://firebasestorage.googleapis.com/v0/b/firsttask-4498a.appspot.com/o/test.json?alt=media&token=99193bbf-6291-4fa9-b316-f4a44a6da6f4";
        StartCoroutine(GetRequest(url, model =>
        {
            for (int i = 0; i < model.main_category.items.Count; i++)
            {
                ObjectContain(model, i);
            }
        }));
        yield return null;
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

    private void ObjectContain(TestModel model, int i)
    {
        var prefab = Instantiate(Resources.Load<GameObject>("Prefabs/PrefabObject"), content.transform);
        prefab.GetComponent<Image>().color = new Color(model.main_category.items[i].color.x,
            model.main_category.items[i].color.y, model.main_category.items[i].color.z,
            model.main_category.items[i].color.a);
        prefab.GetComponentInChildren<Text>().text =
            "Position: " + model.main_category.items[i].position + "\n Index: " +
            model.main_category.items[i].properties.index + "\n Visibility(invisiblePartsCount): " +
            model.main_category.items[i].properties.visibility.invisiblePartsCount +
            "\n Visibility(isOnTheTopPosition): " +
            model.main_category.items[i].properties.visibility.isOnTheTopPosition + "\n IsValid: " +
            model.main_category.items[i].properties.isValid;
        NavigationSystem.addActionForClose(() => { Destroy(prefab); });
    }
}
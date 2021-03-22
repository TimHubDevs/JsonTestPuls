using UnityEngine;

public class Reload : MonoBehaviour
{
    [SerializeField] private JsonDownloader jsonDownloader;
    
    public void ReloadList()
    {
        jsonDownloader.LoadData(model => { });
    }
}
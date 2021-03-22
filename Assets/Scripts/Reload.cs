using UnityEngine;

public class Reload : MonoBehaviour
{
    [SerializeField] private JsonDownloader jsonDownloader;
    
    private NavigationSystem navigationSystem;

    public void ReloadList()
    {
        NavigationSystem.closeAll();
        StartCoroutine(jsonDownloader.CheckData());
    }
}
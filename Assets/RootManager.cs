using UnityEngine;

public class RootManager : MonoBehaviour
{
    [SerializeField] private JsonDownloader jsonDownloader;
    
    [SerializeField] private CanvasManager canvasManager;
    
    void Start()
    {
        Init();
    }

    public void Init()
    {
        jsonDownloader.LoadData(model => { canvasManager.GiveListItem(model.main_category.items); });
    }
}

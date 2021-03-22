using UnityEngine;
using UnityEngine.UI;

public class Reload : MonoBehaviour
{
    [SerializeField] private RootManager rootManager;

    [SerializeField] private Button bton;

    private void Start()
    {
        bton.onClick.AddListener(ReloadList);
    }

    public void ReloadList()
    {
        rootManager.Init();
    }
}
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private ItemListView itemListView;
    [SerializeField] private Reload reload;
    public void GiveListItem(List<Item> items)
    {
        itemListView.Init(items);
    }
}

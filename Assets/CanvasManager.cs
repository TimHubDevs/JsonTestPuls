using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private ItemListView itemListView;
    public void GiveListItem(List<Item> items)
    {
        itemListView.Init(items);
    }
}

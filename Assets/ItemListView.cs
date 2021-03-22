using System.Collections.Generic;
using UnityEngine;

public class ItemListView : MonoBehaviour
{
    [SerializeField] private GameObject content;
    [SerializeField] private ItemPrefabUI itemPrefabUI;

    public void Init(List<Item> data)
    {
        for (int i = 0; i < data.Count; i++)
        {
            var itemViewInstance = Instantiate(itemPrefabUI, content.transform);
            itemViewInstance.Init(data[i]);
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class ItemPrefabUI : MonoBehaviour
{
    [SerializeField] private Image img;
    [SerializeField] private Text text;

    public void Init(Item item)
    {
        img.color = new Color(item.color.x,
            item.color.y, item.color.z,
            item.color.a);
        text.text =
             "Position: " + item.position + "\n Index: " +
             item.properties.index + "\n Visibility(invisiblePartsCount): " +
             item.properties.visibility.invisiblePartsCount +
             "\n Visibility(isOnTheTopPosition): " +
             item.properties.visibility.isOnTheTopPosition + "\n IsValid: " +
             item.properties.isValid;
    }
}
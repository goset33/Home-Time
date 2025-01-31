using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ItemController : MonoBehaviour
{
    public static InventoryController inventoryController;
    public static BuyHandler buyHandler;

    public FoodObject scriptable;

    public void Init(FoodObject food)
    {
        scriptable = food;
    }

    public void Taked()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>(true).text = scriptable.price.ToString();
    }

    public void Released()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void TakeItem()
    {
        if (inventoryController.AddItem(scriptable))
        {
            Destroy(gameObject);
        }
    }
}

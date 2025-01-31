using UnityEngine;
using UnityEngine.Events;

public class ItemController : MonoBehaviour
{
    public static InventoryController inventoryController;
    public static SellsController sellsController;

    public FoodObject scriptable;
    public UnityEvent<FoodObject> onItemBought;

    public void Init(FoodObject food)
    {
        scriptable = food;
    }

    public void TakeItem()
    {
        if (inventoryController.cash < scriptable.price || inventoryController.invContent.Count == inventoryController.slots.Count) return;

        onItemBought.AddListener((FoodObject) => sellsController.ItemBought(scriptable));
        onItemBought?.Invoke(scriptable);
        inventoryController.AddItem(scriptable);
        Destroy(gameObject);

    }
}

using UnityEngine;
using DG.Tweening;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ItemController : MonoBehaviour
{
    public static InventoryController inventoryController;

    public FoodObject scriptable;

    public void Init(FoodObject food)
    {
        scriptable = food;
    }

    public void TakeItem()
    {
        if (inventoryController.cash < scriptable.price || inventoryController.invContent.Count == inventoryController.slots.Count) return;

        inventoryController.AddItem(scriptable);
        Destroy(gameObject);

    }
}

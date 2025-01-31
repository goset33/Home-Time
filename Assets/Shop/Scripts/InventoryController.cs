using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public TextMeshProUGUI cashText, subtitles;
    public Transform inventory;
    public int cash;

    [HideInInspector] public List<Image> slots = new();
    [HideInInspector] public List<FoodObject> invContent = new();
    private int lastBlocked = 0;

    private void Awake()
    {
        cashText.text = cash.ToString();
        ItemController.inventoryController = this;
        for (int i = 0; i < inventory.childCount; i++)
        {
            slots.Add(inventory.GetChild(i).GetComponent<Image>());
        }
    }

    public void AddItem(FoodObject obj)
    {
        slots[lastBlocked].sprite = obj.sprite;
        slots[lastBlocked].color = Color.white;
        invContent.Add(obj);

        cash -= obj.price;
        cashText.text = cash.ToString();
        lastBlocked++;

        if (invContent.Count == slots.Count)
        {
            GameEnding();
        }
    }

    public void GameEnding()
    {

    }

    public void TypeSorry()
    {
        subtitles.color = Color.white;
        subtitles.DOColor(new Color(1f, 1f, 1f, 0f), 1f);
    }
}

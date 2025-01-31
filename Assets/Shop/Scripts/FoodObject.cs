using UnityEngine;

[CreateAssetMenu(fileName = "FoodObject", menuName = "Scriptable Objects/FoodObject", order = 1)]
public class FoodObject : ScriptableObject
{
    public GameObject prefab;
    public Sprite sprite;
    public int price;
}

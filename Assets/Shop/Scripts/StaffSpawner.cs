using UnityEngine;

public class StaffSpawner : MonoBehaviour
{
    public FoodObject[] sells;
    public Transform[] spawnHandlers;

    private void Awake()
    {
        foreach (Transform spawnpoints in spawnHandlers)
        {
            for (int i = 0; i < spawnpoints.transform.childCount; i++)
            {
                int rand = Random.Range(0, sells.Length);
                GameObject obj = Instantiate(sells[rand].prefab, spawnpoints.GetChild(i));
                obj.transform.rotation = sells[rand].prefab.transform.rotation;
                obj.GetComponent<ItemController>().scriptable = sells[rand];
            }
        }
    }
}

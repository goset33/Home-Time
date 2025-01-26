using UnityEngine;

public class FoodPackController : MonoBehaviour
{
    private bool isActivate;
    private ParticleSystem system;

    private void Awake()
    {
        system = GetComponentInChildren<ParticleSystem>();
    }

    public void OnActivate()
    {
        if (!isActivate)
        {
            system.Play();
            isActivate = true;
        }
        else
        {
            system.Stop();
            isActivate = false;
        }
    }
}

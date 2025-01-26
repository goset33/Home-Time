using UnityEngine;
using UnityEngine.Events;

public class FlowerController : MonoBehaviour
{
    private int counter;
    private bool isWatered;

    public UnityEvent onFlowerWatered;

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Water drop") && !isWatered)
        {
            counter++;
            if (counter >= 300)
            {
                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.Play();

                isWatered = true;
                GetComponentInChildren<ParticleSystem>().Play();
                onFlowerWatered?.Invoke();
            }
        }
    }
}

using UnityEngine;
using UnityEngine.Events;

public class WaterCanController : MonoBehaviour
{
    private int fillStatus = 0;
    private bool isFilled, isFlowing;
    private int wateredFlowers;

    public float flowingTime;
    public float maxFlowingTime = 5f;

    [Space]
    public UnityEvent onAllFlowersWatered;

    private AudioSource audioSource;
    private ParticleSystem water;
    private GameObject waterLevel;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        water = GetComponentInChildren<ParticleSystem>();
        waterLevel = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (isFlowing)
        {
            flowingTime += Time.deltaTime;
            if (flowingTime >= maxFlowingTime)
            {
                flowingTime = 0f;
                OnActivate();
            }
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Water drop") && !isFilled)
        {
            fillStatus++;
            if (fillStatus >= 500)
            {
                fillStatus = 0;
                waterLevel.SetActive(true);
                isFilled = true;
            }
        }
    }

    public void OnActivate()
    {
        if (isFilled)
        {
            if (!isFlowing) // Включение воды
            {
                audioSource.Play();
                water.Play();
                isFlowing = true;
            }
            else if (isFlowing && flowingTime == 0f) // Вода кончилась
            {
                water.Stop();
                isFlowing = false;
                isFilled = false;
                waterLevel.SetActive(false);
            }
            else // Выключение воды
            {
                audioSource.Pause();
                water.Stop();
                isFlowing = false;
            }
        }
    }

    public void WhenFlowerWatered()
    {
        wateredFlowers++;
        if (wateredFlowers == 4)
        {
            onAllFlowersWatered?.Invoke();
        }
    }
}

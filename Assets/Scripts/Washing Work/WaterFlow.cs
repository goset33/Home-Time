using UnityEngine;

public class WaterFlow : MonoBehaviour
{
    public GameObject water;
    public AudioClip waterEnding;

    private bool isFlowing;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ActivateWater()
    {
        if (!isFlowing)
        {
            isFlowing = true;
            audioSource.Stop();
            audioSource.Play();
            water.GetComponent<ParticleSystem>().Play();
        }
        else
        {
            isFlowing = false;
            audioSource.Stop();
            audioSource.PlayOneShot(waterEnding, 0.7f);
            water.GetComponent<ParticleSystem>().Stop();
        }
    }
}

using UnityEngine;
using UnityEngine.Events;

public class MopController : MonoBehaviour
{
    private AudioSource audioSource;
    public bool isWet;
    private int washed;
    [SerializeField] private Texture2D[] states;

    [Space]
    public UnityEvent onEverythingWashed;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeState()
    {
        int index = isWet ? 0 : 1;
        GetComponent<Renderer>().material.mainTexture = states[index];
        isWet = index == 1;
        audioSource.Play();
    }

    public void DirtTouched(GameObject dirt)
    {
        if (isWet)
        {
            Destroy(dirt);
            ChangeState();
            washed++;
            if (washed == 3)
            {
                onEverythingWashed?.Invoke();
            }            
        }
    }
}

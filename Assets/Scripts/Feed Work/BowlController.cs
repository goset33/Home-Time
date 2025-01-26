using UnityEngine;
using UnityEngine.Events;

public class BowlController : MonoBehaviour
{
    private int fillStatus = 0;
    private bool isFilled;

    public UnityEvent onBowlFilled;

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Food") && !isFilled)
        {
            fillStatus++;
            if (fillStatus >= 50)
            {
                fillStatus = 0;
                transform.parent.GetChild(1).gameObject.SetActive(true);
                isFilled = true;
                onBowlFilled?.Invoke();
            }
        }
    }
}

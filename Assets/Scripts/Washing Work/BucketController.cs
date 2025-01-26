using UnityEngine;

public class BucketController : MonoBehaviour
{
    private int fillStatus = 0;
    private bool isFilled;

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Water drop") && !isFilled)
        {
            fillStatus++;
            if (fillStatus >= 500)
            {
                fillStatus = 0;
                transform.GetChild(0).gameObject.SetActive(true);
                isFilled = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mop") && isFilled)
        {
            MopController mopController = other.GetComponent<MopController>();
            if (!mopController.isWet)
            {
                other.GetComponent<MopController>().ChangeState();
            }
        }
    }
}

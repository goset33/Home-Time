using UnityEngine;

public class DirtTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mop"))
        {
            other.GetComponent<MopController>().DirtTouched(gameObject);
        }
    }
}

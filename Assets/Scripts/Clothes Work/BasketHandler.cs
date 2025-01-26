using UnityEngine;
using UnityEngine.Events;

public class BasketHandler : MonoBehaviour
{
    private int counter = 0;
    public UnityEvent onBasketFilled;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cloth"))
        {
            counter++;
            other.tag = "Untagged";

            if (counter == 5)
            {
                onBasketFilled?.Invoke();
                print("Everything is in the basket");
            }
        }
    }
}

using UnityEngine;

public class IsClosed : MonoBehaviour
{
    void Update()
    {
        // Check if any key is pressed
        if (Input.anyKeyDown)
        {
            // Disable the GameObject this script is attached to
            gameObject.SetActive(false);
        }
    }
}

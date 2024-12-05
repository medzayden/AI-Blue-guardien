using UnityEngine;
using UnityEngine.UI;

public class EarthHealth : MonoBehaviour
{
    //public Slider heartbeatSlider;
    //public Slider temperatureSlider;
    public float heartbeat = 100f;
    public float temperature = 25f;

    void Update()
    {
        // Simulate heartbeat (currents) and temperature change
        heartbeat -= Time.deltaTime * 0.1f; // Decrease over time
        temperature += Time.deltaTime * 0.05f; // Increase temperature over time

        // Update UI sliders
        //heartbeatSlider.value = heartbeat;
        //temperatureSlider.value = temperature;

        // Game Over condition if temperature or heartbeat reaches critical levels
        if (heartbeat <= 0 || temperature >= 40)
        {
            // Trigger game over sequence (e.g., display a message, stop the game)
            Debug.Log("Earth's health has failed!");
        }
    }
}


using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ActionButtons : MonoBehaviour
{
    // Buttons
    public Button plasticButton;  // Renamed to match the actual usage
    public Button populationButton;
    public Button airPollutionButton;
    public Button overfishingButton;
    public Button actionButton;  // Renamed to make it descriptive

    // Game variables
    private EarthHealth earthHealth;
    private GameManager gameManager;  // Defined GameManager correctly

    void Start()
    {
        // Initialize EarthHealth and GameManager references
        earthHealth = FindObjectOfType<EarthHealth>();
        gameManager = FindObjectOfType<GameManager>();

        // Assign button listeners
        plasticButton.onClick.AddListener(CleanPlastic);
        populationButton.onClick.AddListener(KillPeaple);
        airPollutionButton.onClick.AddListener(ActivateCarbonFilters);
        overfishingButton.onClick.AddListener(DestroyFishingBoat);

        // Ensure actionButton is hooked up to a method if it should perform an action.
        actionButton.onClick.AddListener(SomeActionMethod);
    }

    IEnumerator EnableButton(float time, Button button)
    {
        if (button != null)
        {
            button.enabled = false;
            Image image = button.GetComponent<Image>();
            image.color = Color.red;
            yield return new WaitForSeconds(time);
            image.color = Color.white;
            button.enabled = true;
        }

    }

    void CleanPlastic()
    {
        // Add scanning behavior here (highlight areas with threats)
        Debug.Log("Scanning Earth...");
        earthHealth.heartbeat += 15;
        StartCoroutine(EnableButton(10f, plasticButton));  // Disables button for 10 seconds after click
    }

    void KillPeaple()
    {
        // Add cleaning ships behavior (clear plastic or other threats)
        Debug.Log("Deploying Cleaning Ships...");
        if (earthHealth != null)
        {
            earthHealth.heartbeat += 10;  // Example: Improve heartbeat with cleaning ships
        }

        StartCoroutine(EnableButton(10f, populationButton));
    }

    void ActivateCarbonFilters()
    {
        // Add carbon filter behavior (reduce acidification)
        Debug.Log("Activating Carbon Filters...");
        if (earthHealth != null)
        {
            earthHealth.temperature -= 5;  // Example: Lower temperature with filters
        }

        StartCoroutine(EnableButton(10f, airPollutionButton));
    }

    void DestroyFishingBoat()
    {
        // Add biodiversity boosting behavior (restore coral reefs)
        Debug.Log("Boosting Biodiversity...");
        // Implement biodiversity boosting logic here

        StartCoroutine(EnableButton(10f, overfishingButton));
    }

    void SomeActionMethod()
    {
        // Placeholder for actionButton functionality if needed
        Debug.Log("Action button pressed.");

        earthHealth.heartbeat += 0.5f;
        earthHealth.temperature += 5;

        StartCoroutine(EnableButton(0.5f, actionButton));
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ActionButtons : MonoBehaviour
{
    // Buttons
    public Button plasticButton;  // Renamed to match the actual usage
    public Button cleanButton;
    public Button carbonButton;
    public Button biodiversityButton;
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
        plasticButton.onClick.AddListener(ScanEarth);
        cleanButton.onClick.AddListener(DeployCleaningShips);
        carbonButton.onClick.AddListener(ActivateCarbonFilters);
        biodiversityButton.onClick.AddListener(BoostBiodiversity);

        // Ensure actionButton is hooked up to a method if it should perform an action.
        actionButton.onClick.AddListener(SomeActionMethod);
    }

    IEnumerator EnableButton(float time, Button button)
    {
        if (button != null) {
            button.enabled = false;
            yield return new WaitForSeconds(time);
            button.enabled = true;
        }
        
    }

    void ScanEarth()
    {
        // Add scanning behavior here (highlight areas with threats)
        Debug.Log("Scanning Earth...");
        StartCoroutine(EnableButton(10f, plasticButton));  // Disables button for 10 seconds after click
    }

    void DeployCleaningShips()
    {
        // Add cleaning ships behavior (clear plastic or other threats)
        Debug.Log("Deploying Cleaning Ships...");
        if (earthHealth != null)
        {
            earthHealth.heartbeat += 10;  // Example: Improve heartbeat with cleaning ships
        }
    }

    void ActivateCarbonFilters()
    {
        // Add carbon filter behavior (reduce acidification)
        Debug.Log("Activating Carbon Filters...");
        if (earthHealth != null)
        {
            earthHealth.temperature -= 5;  // Example: Lower temperature with filters
        }
    }

    void BoostBiodiversity()
    {
        // Add biodiversity boosting behavior (restore coral reefs)
        Debug.Log("Boosting Biodiversity...");
        // Implement biodiversity boosting logic here
    }

    void SomeActionMethod()
    {
        // Placeholder for actionButton functionality if needed
        Debug.Log("Action button pressed.");
    }
}

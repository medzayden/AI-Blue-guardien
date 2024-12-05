using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.UI;

public class ActionButtons : MonoBehaviour
{
    public Button scanButton;
    public Button cleanButton;
    public Button carbonButton;
    public Button biodiversityButton;

    private EarthHealth earthHealth;

    void Start()
    {
        earthHealth = FindObjectOfType<EarthHealth>();

        // Assign button listeners
        scanButton.onClick.AddListener(ScanEarth);
        cleanButton.onClick.AddListener(DeployCleaningShips);
        carbonButton.onClick.AddListener(ActivateCarbonFilters);
        biodiversityButton.onClick.AddListener(BoostBiodiversity);
    }

    void ScanEarth()
    {
        // Add scanning behavior here (highlight areas with threats)
        Debug.Log("Scanning Earth...");
    }

    void DeployCleaningShips()
    {
        // Add cleaning ships behavior (clear plastic or other threats)
        Debug.Log("Deploying Cleaning Ships...");
        earthHealth.heartbeat += 10; // Example: Improve heartbeat with cleaning ships
    }

    void ActivateCarbonFilters()
    {
        // Add carbon filter behavior (reduce acidification)
        Debug.Log("Activating Carbon Filters...");
        earthHealth.temperature -= 5; // Example: Lower temperature with filters
    }

    void BoostBiodiversity()
    {
        // Add biodiversity boosting behavior (restore coral reefs)
        Debug.Log("Boosting Biodiversity...");
    }
}


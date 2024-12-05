using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct secondaryStats
{
    int plastic;
    int population;
    int airPollution;
    int deforestation;
}
public class GameManager : MonoBehaviour
{
    public EarthHealth earthHealth;
    public float threatSpawnInterval = 10f; // Time between threat spawns (seconds)
    public float threatIncreaseRate = 1.1f; // How fast the threat intensity increases over time
    public float maxThreatIntensity = 100f; // Maximum intensity of threats
    private float currentThreatIntensity = 1f;

    // Threat types (can expand with more types as needed)
    private enum ThreatType { Plastic, Acidification, DeadZone, Overfishing, population }
    private ThreatType currentThreat;

    void Start()
    {
        // Start the threat simulation process
        StartCoroutine(SpawnThreats());
    }

    IEnumerator SpawnThreats()
    {
        while (true)
        {
            // Wait for the specified interval before spawning the next threat
            yield return new WaitForSeconds(threatSpawnInterval);

            // Increase the threat intensity over time
            currentThreatIntensity = Mathf.Min(currentThreatIntensity * threatIncreaseRate, maxThreatIntensity);

            // Randomly choose a threat type
            currentThreat = (ThreatType)Random.Range(0, 5);

            // Apply the chosen threat
            ApplyThreat();
        }
    }

    void ApplyThreat()
    {
        switch (currentThreat)
        {
            case ThreatType.Plastic:
                SpawnPlasticBuildUp();
                break;
            case ThreatType.Acidification:
                IncreaseAcidification();
                break;
            case ThreatType.DeadZone:
                CreateDeadZone();
                break;
            case ThreatType.Overfishing:
                CauseOverfishing();
                break;
            case ThreatType.population:
                IncreasePopulation();
                break;
        }
    }

    // Threat application methods (they can increase/decrease Earth health metrics)

    void SpawnPlasticBuildUp()
    {
        Debug.Log("Plastic Build-Up Spawned!");
        // Decrease the heartbeat (currents) based on threat intensity
        earthHealth.heartbeat -= currentThreatIntensity * 0.5f;
    }

    void IncreaseAcidification()
    {
        Debug.Log("Ocean Acidification Increased!");
        // Increase the temperature and damage coral reefs
        earthHealth.temperature += currentThreatIntensity * 0.2f;
        earthHealth.heartbeat -= currentThreatIntensity * 0.3f; // Acidification also affects biodiversity
    }

    void CreateDeadZone()
    {
        Debug.Log("Dead Zone Created!");
        // Reduce oxygen levels and disrupt plankton zones
        earthHealth.temperature += currentThreatIntensity * 0.3f;
        earthHealth.heartbeat -= currentThreatIntensity * 0.4f; // Dead zones lower the heartbeat
    }

    void CauseOverfishing()
    {
        Debug.Log("Overfishing Event!");
        // Damage biodiversity and coral reefs
        earthHealth.heartbeat -= currentThreatIntensity * 0.6f;
    }

    void IncreasePopulation()
    {
        Debug.Log("Global Warming Increased!");
        // Increase temperature significantly
        earthHealth.temperature += currentThreatIntensity * 0.5f;
    }
}


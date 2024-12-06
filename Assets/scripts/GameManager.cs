using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

struct secondaryStats
{
    
}
public class GameManager : MonoBehaviour
{
    public EarthHealth earthHealth;
    public float threatSpawnInterval = 10f; // Time between threat spawns (seconds)
    public float threatIncreaseRate = 1.1f; // How fast the threat intensity increases over time
    public float maxThreatIntensity = 100f; // Maximum intensity of threats
    private float currentThreatIntensity = 1f;

    public float plastic = 0f; public float platicGrothRate = 0.2f;
    public Image plasticFill;
    public float population =0f; public float populationGrothRate = 0.2f;
    public Image populationFill;
    public float airPollution =0f; public float airPollutionGrothRate = 0.2f;
    public Image airPollutionFill;
    public float Overfishing = 0f; public float overfishingGrothRate = 0.2f;
    public Image OverfishingFill;

    

    // Threat types (can expand with more types as needed)
    private enum ThreatType { Plastic, AirPolliton, Overfishing, population }
    private ThreatType currentThreat;

    void Start()
    {
        // Start the threat simulation process
        StartCoroutine(SpawnThreats());
    }
    private void Update()
    {
        plastic += Time.deltaTime * platicGrothRate;
        plasticFill.fillAmount = plastic / 100;
        airPollution += Time.deltaTime * airPollutionGrothRate;
        airPollutionFill.fillAmount = airPollution / 100;
        Overfishing += Time.deltaTime * overfishingGrothRate;
        OverfishingFill.fillAmount = Overfishing/100;
        population += Time.deltaTime * populationGrothRate;
        populationFill.fillAmount = population/100;

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
            case ThreatType.AirPolliton:
                IncreaseAirPolliton();
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

        plastic += 5;
        platicGrothRate += 0.3f;

        // Decrease the heartbeat (currents) based on threat intensity 
        earthHealth.heartbeat -= currentThreatIntensity * plastic/100;
    }

    void IncreaseAirPolliton()
    {
        Debug.Log("Ocean Acidification Increased!");
        // Increase the temperature and damage coral reefs
        airPollution += 5;
        airPollutionGrothRate += 0.3f;

        earthHealth.temperature += currentThreatIntensity * 0.2f;
        earthHealth.heartbeat -= currentThreatIntensity * airPollutionGrothRate; // Acidification also affects biodiversity
    }

    void CauseOverfishing()
    {
        Debug.Log("Overfishing Event!");

        Overfishing += 5;
        overfishingGrothRate += 0.5f;

        // Damage biodiversity and coral reefs
        earthHealth.heartbeat -= currentThreatIntensity * overfishingGrothRate;
    }

    void IncreasePopulation()
    {
        Debug.Log("Population Increased!");
        // Increase Population significantly

        population += 5;
        populationGrothRate += 0.6f;

        earthHealth.heartbeat -= currentThreatIntensity * populationGrothRate;
    }
}


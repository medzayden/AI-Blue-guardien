using UnityEngine;

public class KonamiCode : MonoBehaviour
{
    private GameManager gameManager;  // Defined GameManager correctly
    private EarthHealth earthHealth;



    // Define your custom Konami Codes as arrays of KeyCode
    private KeyCode[][] konamiCodes = new KeyCode[][]
    {
        new KeyCode[] { KeyCode.W, KeyCode.H, KeyCode.A, KeyCode.T, KeyCode.S, KeyCode.G, KeyCode.O, KeyCode.O, KeyCode.D },  // "whatsgood"
        new KeyCode[] { KeyCode.G, KeyCode.E, KeyCode.T, KeyCode.O, KeyCode.U, KeyCode.T },                                 // "getout"
        new KeyCode[] { KeyCode.H, KeyCode.U, KeyCode.M, KeyCode.A, KeyCode.N },                                           // "human"
        new KeyCode[] { KeyCode.O, KeyCode.R, KeyCode.G, KeyCode.A, KeyCode.N, KeyCode.S },                                // "organs"
        new KeyCode[] { KeyCode.C, KeyCode.H, KeyCode.I, KeyCode.L, KeyCode.A, KeyCode.F, KeyCode.O, KeyCode.R, KeyCode.M, KeyCode.I }, // "chilaformi"
        new KeyCode[] { KeyCode.W, KeyCode.A, KeyCode.T, KeyCode.E, KeyCode.R }                                            // "water"
    };

    private int[] currentIndexes; // Tracks progress for each Konami Code
    public float resetDelay = 2.0f; // Time allowed before resetting the input sequence
    private float lastInputTime;

    void Start()
    {

        // Initialize EarthHealth and GameManager references
        earthHealth = FindObjectOfType<EarthHealth>();
        gameManager = FindObjectOfType<GameManager>();
        // Initialize progress tracking for each Konami Code
        currentIndexes = new int[konamiCodes.Length];
    }

    void Update()
    {
        // Check for keypresses
        if (Input.anyKeyDown)
        {
            foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key))
                {
                    HandleKeyPress(key);
                    break;
                }
            }
        }

        // Reset sequence if too much time has passed since the last input
        if (Time.time - lastInputTime > resetDelay)
        {
            ResetSequences();
        }
    }

    void HandleKeyPress(KeyCode key)
    {
        for (int i = 0; i < konamiCodes.Length; i++)
        {
            if (key == konamiCodes[i][currentIndexes[i]])
            {
                // Correct key, move to the next in the sequence
                currentIndexes[i]++;
                lastInputTime = Time.time;

                // Check if the full sequence is complete
                if (currentIndexes[i] == konamiCodes[i].Length)
                {
                    ActivateKonamiCode(i);
                    currentIndexes[i] = 0; // Reset the sequence for this code
                }
            }
            else
            {
                // If the wrong key is pressed for this code, reset its progress
                currentIndexes[i] = 0;
            }
        }
    }

    void ActivateKonamiCode(int codeIndex)
    {
        switch (codeIndex)
        {
            case 0:
                Debug.Log("Konami Code 'whatsgood' Activated! Special feature unlocked!");
                earthHealth.heartbeat = 100f;
                break;
            case 1:
                Debug.Log("Konami Code 'getout' Activated! Escape ability unlocked!");
                gameManager.plastic = 0;
                
                break;
            case 2:
                Debug.Log("Konami Code 'human' Activated! Human mode enabled!");
                gameManager.population = 2f;
                break;
            case 3:
                Debug.Log("Konami Code 'organs' Activated! Organ mode enabled!");
                gameManager.airPollution -= 60;
                break;
            case 4:
                Debug.Log("Konami Code 'chilaformi' Activated! Special ability unlocked!");
                gameManager.Overfishing = 0f;
                break;
            case 5:
                Debug.Log("Konami Code 'water' Activated! Water-related ability unlocked!");
                gameManager.Overfishing = 0f;
         
                break;
            default:
                Debug.Log("Unknown code activated!");
                break;
        }
    }

    void ResetSequences()
    {
        for (int i = 0; i < currentIndexes.Length; i++)
        {
            currentIndexes[i] = 0;
        }
    }
}

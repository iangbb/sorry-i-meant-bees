using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteoriteShower : MeteoriteSpawner
{

    public float minimumShowerDelay;
    public float maximumShowerDelay;
    
    public Text meteorShowerAlertText;
    
    // Start is called before the first frame update
    void Start()
    {
        // Customise MeteoriteSpawner's public fields
        minSpawnInterval = 0.2f;
        maxSpawnInterval = 2.0f;
        totalMeteorsToSpawn = 20;
        SetupMeteorSpawner();
        StartCoroutine(LoopMeteorShowerAfterRandomTime());
    }

    private IEnumerator LoopMeteorShowerAfterRandomTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minimumShowerDelay, maximumShowerDelay));
            StartCoroutine(ShowMeteoriteShowerAlert());
            StartCoroutine(SpawnMeteorite());
        }
    }

    private IEnumerator ShowMeteoriteShowerAlert()
    {
        meteorShowerAlertText.enabled = true;
        yield return new WaitForSeconds(2);
        meteorShowerAlertText.enabled = false;
    }
}

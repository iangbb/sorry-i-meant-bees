using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteoriteShower : MeteoriteSpawner
{

    public Text meteorShowerAlertText;
    
    // Start is called before the first frame update
    protected new void Start()
    {
        minSpawnInterval = 0.2f;
        maxSpawnInterval = 1.0f;
        totalMeteorsToSpawn = 20;
        SetupMeteorSpawner();
        StartCoroutine(LoopMeteorShowerAfterRandomTime());
    }

    private IEnumerator LoopMeteorShowerAfterRandomTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(30.0f, 60.0f));
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

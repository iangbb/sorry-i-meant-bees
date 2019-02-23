using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteShower : MeteoriteSpawner
{
    
    
    // Start is called before the first frame update
    protected new void Start()
    {
        minSpawnInterval = 0.2f;
        maxSpawnInterval = 1.0f;
        totalMeteorsToSpawn = 20;
        StartCoroutine(DelayedActivation(Random.Range(30.0f, 60.0f)));
    }

    private IEnumerator DelayedActivation(float delay)
    {
        yield return new WaitForSeconds(delay);
        base.Start();
        StartCoroutine(LoopMeteorShowerAfterRandomTime());
    }

    private IEnumerator LoopMeteorShowerAfterRandomTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(30.0f, 60.0f));
            StartCoroutine(SpawnMeteorite());
        }
    }
}

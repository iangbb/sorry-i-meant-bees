using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteShower : MeteoriteSpawner
{
    
    
    // Start is called before the first frame update
    protected new void Start()
    {
        //activationTime = Random.Range(30.0f, 60.0f);
        minSpawnInterval = 0.2f;
        maxSpawnInterval = 1.0f;
        totalMeteorsToSpawn = 20;
        StartCoroutine(DelayedActivation(10.0f));
    }

    private IEnumerator DelayedActivation(float delay)
    {
        yield return new WaitForSeconds(delay);
        base.Start();
    }
}

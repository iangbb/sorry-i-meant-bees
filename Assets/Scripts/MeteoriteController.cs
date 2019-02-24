using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteController : MonoBehaviour
{
    private float lifeTime;
    private float width;
    private float height;

    void Start()
    {
        lifeTime = 10;
        GameObject cont = GameObject.FindGameObjectWithTag("GameController");
        width = cont.GetComponent<boundary_script>().width;
        height = cont.GetComponent<boundary_script>().height;
        StartCoroutine(ControlMeteorLifetime());
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = gameObject.transform.position;
        if (Mathf.Abs(pos.x) > width / 2 + 10 || Mathf.Abs(pos.y) > height / 2 + 10)
            GameObject.Destroy(gameObject);
    }

    private IEnumerator ControlMeteorLifetime()
    {
        yield return new WaitForSeconds(lifeTime);
        GameObject.Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookshot_script : MonoBehaviour
{
    public KeyCode hookshotKey;
    public LineRenderer line;
    DistanceJoint2D joint;
    Vector3 targetPos;
    RaycastHit2D hit;
    public float distance = 100f;
    public LayerMask mask;
    public float step = 0.2f;

    private bool hookshotEnabled;


    void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        line.enabled = false;
        hookshotEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(hookshotKey) && hookshotEnabled)
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;
            hit = Physics2D.Raycast(transform.position, targetPos - transform.position, distance, mask);
            if(hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                joint.enabled = true;
                joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                joint.distance = Vector2.Distance(transform.position, hit.collider.transform.position);

                line.enabled = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, hit.collider.transform.position);
            }
        }

        if (Input.GetKey(hookshotKey))
        {
            line.SetPosition(0, transform.position);
        }

        if (Input.GetKeyUp(hookshotKey))
        {
            joint.enabled = false;
            line.enabled = false;
        }
    }

    public void setHookShotEnabled(bool w) { hookshotEnabled = w; }

    public bool getHookShotEnabled() { return hookshotEnabled; }
}

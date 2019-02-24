using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookshot_script : MonoBehaviour
{
    public KeyCode hookshotLeftKey;
    public KeyCode hookshotRightKey;
    public LineRenderer line;
    private DistanceJoint2D joint;
    private Vector3 targetPos;
    private RaycastHit2D hit;
    public float distance = 1000f;
    public LayerMask mask;
    public float step = 0.2f;

    public bool hookshotEnabled = true;
    private KeyCode[] controls;


    void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        line.enabled = false;
        hookshotEnabled = true;
        controls = new KeyCode[] { hookshotLeftKey, hookshotRightKey };
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < controls.Length; i++)
        {
            if (hookshotEnabled && Input.GetKeyDown(controls[i]))
            {
                joint.enabled = false;
                line.enabled = false;
                
                // get direction of player
                Vector3 playerDirection = transform.up;
                Vector3 lookDirection;
                if (i == 0)
                {
                    lookDirection = Quaternion.Euler(0, 0, 90) * playerDirection;
                }
                else
                {
                    lookDirection = Quaternion.Euler(0, 0, -90) * playerDirection;
                }

                hit = Physics2D.Raycast(transform.position, lookDirection, distance, mask);
                
                if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    joint.enabled = true;
                    joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                    joint.distance = Vector2.Distance(transform.position, hit.collider.transform.position);

                    line.enabled = true;
                    line.SetPosition(0, transform.position);
                    line.SetPosition(1, hit.collider.transform.position);
                }
            }

            if (Input.GetKey(controls[i]))
            {
                //Rigidbody2D hitCollider = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    joint.enabled = true;
                    joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();;
                    joint.distance = Vector2.Distance(transform.position, hit.collider.transform.position);

                    line.enabled = true;
                    line.SetPosition(0, transform.position);
                    line.SetPosition(1, hit.collider.transform.position);
                }
            }

            if (Input.GetKeyUp(controls[i]) || (joint.connectedBody == null && Input.GetKey(controls[i])))
            {
                joint.enabled = false;
                line.enabled = false;
            }
        }
    }

    public void SetHookShotEnabled(bool enabled)
    {
        hookshotEnabled = enabled;
    }

    public bool GetHookShotEnabled()
    {
        return hookshotEnabled;
    }
}

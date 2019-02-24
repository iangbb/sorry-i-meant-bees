using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookshot_script : MonoBehaviour
{
    public KeyCode hookshotLeftKey;
    public KeyCode hookshotRightKey;
    public LineRenderer line;
    DistanceJoint2D joint;
    Vector3 targetPos;
    RaycastHit2D hit;
    public float distance = 1000f;
    public LayerMask mask;
    public float wideRaysAngle = 2.0f;

    public bool hookshotEnabled = true;
    KeyCode[] controls;


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
            if (Input.GetKeyDown(controls[i]) && hookshotEnabled)
            {
                joint.enabled = false;
                line.enabled = false;
                // get direction of player
                Vector3 playerDirection = transform.up;
                Vector3 lookDirection;
                if (i == 0)
                    lookDirection = Quaternion.Euler(0, 0, 90) * playerDirection;
                else
                    lookDirection = Quaternion.Euler(0, 0, -90) * playerDirection;
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
                else
                {
                    hit = Physics2D.Raycast(transform.position, Quaternion.Euler(0, 0, wideRaysAngle) * lookDirection, distance, mask);
                    if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                    {
                        joint.enabled = true;
                        joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                        joint.distance = Vector2.Distance(transform.position, hit.collider.transform.position);

                        line.enabled = true;
                        line.SetPosition(0, transform.position);
                        line.SetPosition(1, hit.collider.transform.position);
                    }
                    else
                    {
                        hit = Physics2D.Raycast(transform.position, Quaternion.Euler(0, 0, -wideRaysAngle) * lookDirection, distance, mask);
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
                }
            }

            if (Input.GetKey(controls[i]))
            {
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
            if (Input.GetKeyUp(controls[i]) || (joint.connectedBody == null && Input.GetKey(controls[i])))
            {
                joint.enabled = false;
                line.enabled = false;
            }
        }
    }

    public void setHookShotEnabled(bool w) { hookshotEnabled = w; }

    public bool getHookShotEnabled() { return hookshotEnabled; }
}

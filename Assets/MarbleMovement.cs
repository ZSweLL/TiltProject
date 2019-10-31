using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleMovement : MonoBehaviour
{

    Vector3 dir;
    Rigidbody rb;

    public bool debug = true;
    public float speed = 10;

    public Transform arrowIndicator;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 dir = Vector3.zero; // new Vector3(0,0,0);

        dir.x = Input.acceleration.x;
        dir.z = Input.acceleration.y;
        if(debug) {
            Debug.DrawRay(this.transform.position, dir * 2, Color.red, 0.5f);
        }

    }

     void LateUpdate() {
            arrowIndicator.rotation = Quaternion.LookRotation(dir, Vector3.up);
            Vector3 scale = Vector3.one;
            scale.z = dir.magnitude * 2;
            arrowIndicator.localScale = scale;
        }

    void FixedUpdate() {
        rb.AddForce(dir * speed);
    }
}

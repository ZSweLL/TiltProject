using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleMovement : MonoBehaviour
{

    Vector3 dir;

    Vector3 calibratedDir;
    Rigidbody rb;

    public bool debug = true;
    public float speed = 10;

    public Transform arrowIndicator;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        Calibrate();
        startPos = this.transform.position;
    }

    public void Calibrate() {
        calibratedDir.x = Input.acceleration.x;
        calibratedDir.z = Input.acceleration.y;
        Debug.Log("Calibrated Dir = " + calibratedDir);
    }

    public float jumpSpeed = 5f;
    public void Jump() {
        if(isGrounded) {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
    }

    bool isGrounded = true;

    void OnCollisionEnter() {
        isGrounded = true;
    }

    void OnCollisionExit() {
        isGrounded = false;
    }

    public int score = 0;
    bool canJump = false;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "JumpPowerUp") {
            canJump = true;
        }
        if(other.gameObject.CompareTag("Coin")) {
            score += 250;
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 dir = Vector3.zero; // new Vector3(0,0,0);

        dir.x = Input.acceleration.x - calibratedDir.x;
        dir.z = Input.acceleration.y - calibratedDir.y;
        if(debug) {
            Debug.DrawRay(this.transform.position, dir * 2, Color.red, 0.5f);
        }

    }

     void LateUpdate() {
            arrowIndicator.rotation = Quaternion.LookRotation(dir, Vector3.up);
            Vector3 scale = Vector3.one;
            scale.z = dir.magnitude * 2;
            arrowIndicator.localScale = scale;

            if(this.transform.position.y <= 0) {
                ResetPosition();
            }
        }

        Vector3 startPos;

        void ResetPosition() {
            this.transform.position = startPos;
            rb.velocity = Vector3.zero;  // this stops all movement.
        }

    void FixedUpdate() {
        rb.AddForce(dir * speed);
    }
}

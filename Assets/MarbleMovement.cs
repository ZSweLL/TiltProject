using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
[RequireComponent(typeof(AudioSource))]
public class MarbleMovement : MonoBehaviour
{

    Vector3 dir;

    Vector3 calibratedDir;
    Rigidbody rb;

    public TextMeshPro scoreText;

    public bool debug = true;
    public float speed = 10;

    public bool canJump;

    public GameObject BtnJump;

    public Transform arrowIndicator;

    AudioSource aud;
    public AudioClip sound;
    public AudioClip[] sounds;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        Calibrate();
        startPos = this.transform.position;
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshPro>();
        aud = this.GetComponent<AudioSource>();
    }

    public void Calibrate() {
        calibratedDir.x = Input.acceleration.x;
        calibratedDir.z = Input.acceleration.y;
        Debug.Log("Calibrated Dir = " + calibratedDir);
    }

    public float jumpSpeed = 5f;
    public void Jump() {
        if(isGrounded && canJump) {
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

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "JumpPowerUp") {
            canJump = true;
            BtnJump.SetActive(canJump);
            Destroy(other.gameObject);
            aud.PlayOneShot(sounds[Random.Range(0, sounds.Length)]);
        }
        if(other.gameObject.CompareTag("Coin")) {
            score += 250;
            scoreText.text = "Score: " + score;
            Destroy(other.gameObject);
            aud.PlayOneShot(sounds[Random.Range(0, sounds.Length)]);
        }
        if(other.gameObject.CompareTag("Finish1")) {
            LoadLevelTwo();
        }
        if(other.gameObject.CompareTag("Finish2")) {
            LoadLevelThree();
        }
        if(other.gameObject.CompareTag("Finish3")) {
            LoadLevelFour();
        }
        if(other.gameObject.CompareTag("Finish4")) {
            LoadLevelFive();
        }
        if(other.gameObject.CompareTag("Finish5")) {
            LoadLevelSix();
        }
        if(other.gameObject.CompareTag("Finish6")) {
            LoadLevelSeven();
        }
        if(other.gameObject.CompareTag("Finish7")) {
            LoadLevelEight();
        }
        if(other.gameObject.CompareTag("Finish8")) {
            LoadLevelNine();
        }
        if(other.gameObject.CompareTag("Finish9")) {
            LoadLevelTen();
        }
        if(other.gameObject.CompareTag("Finish10")) {
            LoadLevelZero();
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

    void LoadLevelOne() {
        SceneManager.LoadScene("TileGame");
    }
    void LoadLevelTwo() {
        SceneManager.LoadScene("Level2");
    }
    void LoadLevelThree() {
        SceneManager.LoadScene("Level3");
    }
    void LoadLevelFour() {
        SceneManager.LoadScene("Level4");
    }
    void LoadLevelFive() {
        SceneManager.LoadScene("Level5");
    }
    void LoadLevelSix() {
        SceneManager.LoadScene("Level6");
    }
    void LoadLevelSeven() {
        SceneManager.LoadScene("Level7");
    }
    void LoadLevelEight() {
        SceneManager.LoadScene("Level8");
    }
    void LoadLevelNine() {
        SceneManager.LoadScene("Level9");
    }
    void LoadLevelTen() {
        SceneManager.LoadScene("Level10");
    }
    void LoadLevelZero() {
        SceneManager.LoadScene("MainMenu");
    }
}

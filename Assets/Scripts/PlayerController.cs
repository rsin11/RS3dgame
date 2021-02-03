using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Player can move and jump*/
public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private bool isOnGround;
 
   
    public float moveSpeed = 5.0f;
    public AudioSource playerAudio;
    public AudioClip crashSound;
    public AudioClip jumpsSound;

    public float jumpForce = 20.0f;
    public float gravityModifier = 1.0f;



    public ParticleSystem smokeParticle;
    private GameManager gameManager;


    void Start()
    {
        playerAudio.GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier; // Helps control Jump
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer() // Move player right and left with Arrows
    {
        float VerticalInput = Input.GetAxis("Vertical"); // Goes front and back
        playerRb.AddForce(Vector3.forward * VerticalInput * moveSpeed);

        float HorizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector3.right * HorizontalInput * moveSpeed);



        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true) // To make player Jump to be able to hit objects  
        {

            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAudio.PlayOneShot(jumpsSound,1.0f);

            isOnGround = false;
        }
    }

    // 
    void OnTriggerEnter(Collider other)
    {
        if (gameManager.isGameActive)
        {
            playerAudio.PlayOneShot(crashSound,1.0f);
            Destroy(other.gameObject);
            Instantiate(smokeParticle, other.transform.position, Quaternion.identity);
            gameManager.UpdateScore(5);
        }
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))// To keep the ball falling through the ground after a jump
        {
            isOnGround = true;
            Vector3 currentPos = playerRb.transform.position;
            playerRb.transform.position = currentPos;
        }
    }

}







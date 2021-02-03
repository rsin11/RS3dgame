using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject player;
    private float speed = 10.0f;
    GameManager gameManager;

    void Start()
    {

        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.isGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive == true)
        {
            enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && gameManager.isGameActive)
        {
            gameManager.GameOver();
            Destroy(gameObject);
            Destroy(other.gameObject);
            gameManager.isGameActive = false;
        }
        else if (gameManager.wonGame == true)
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}

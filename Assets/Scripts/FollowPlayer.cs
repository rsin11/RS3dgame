using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offSet = new Vector3(-1, 8, -25);
   

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = player.transform.position + offSet;
        }
        

    }

}

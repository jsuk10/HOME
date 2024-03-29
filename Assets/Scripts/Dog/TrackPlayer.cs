﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MonoBehaviour
{
    private float velocity = 5f;
    private float limitDistance = 10.0f;
    private float padding = 1f;

    private GameObject player;
    
    private float distanceToPlayer;
    private Vector3 vectorToPlayer;

    private void Awake()
    {
        player = MainObject.Instance.player;

    }

    // Start is called before the first frame update
    void LateUpdate()
    {
        Track();
    }

    public void Track()
    {
        vectorToPlayer = player.transform.position - this.transform.position;
        distanceToPlayer = vectorToPlayer.magnitude;
        vectorToPlayer.Normalize();
        //vectorToPlayer.z = Player.transform.position.z;

        var dogSprite = transform.Find("Sprite").Find("Idle");
        if(distanceToPlayer <= limitDistance - padding)
        {   
            transform.localScale = new Vector3 (1, 1, 1);
            transform.Translate(vectorToPlayer * -velocity * Time.deltaTime);
        }
        else if(limitDistance + padding <= distanceToPlayer)
        {
            transform.localScale = new Vector3 (-1, 1, 1);
            transform.Translate(vectorToPlayer * velocity * Time.deltaTime);
        }


    }
    // Update is called once per frame
}

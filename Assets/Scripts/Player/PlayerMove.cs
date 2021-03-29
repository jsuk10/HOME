using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove: MonoBehaviour
{
    private float velocityWalk = 2;
    private float velocityRun = 3;
    private Vector3 moveDirection;
    private Vector3 prevDirection;
    float keyInputTime = 0.0f;

    [SerializeField]
    private GameObject Dog;
    private float timeNeedtoRun = 1.5f;

    private float v = 0;
    private float h = 0;
    private float prevV = 0;
    private float prevH = 0;
    void Update()
    {
        Move();
    }

    private bool SetDirection()
    {
        moveDirection = new Vector3(0, 0, 0);

        /*
        if(Input.GetKey(KeyCode.LeftArrow))
            moveDirection += Vector3.left;

        if(Input.GetKey(KeyCode.RightArrow))
            moveDirection += Vector3.right;

        if(Input.GetKey(KeyCode.UpArrow))
            moveDirection += Vector3.up;

        if(Input.GetKey(KeyCode.DownArrow))
            moveDirection += Vector3.down;
        */
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");

        if(0 < v && prevV <= v)
            moveDirection += Vector3.up;
        if(v < 0 && v <= prevV)
            moveDirection += Vector3.down;
        if(0 < h && prevH <= h)
            moveDirection += Vector3.right;
        if(h < 0 && h <= prevH)
            moveDirection += Vector3.left;

        prevV = v;
        prevH = h;

        if(moveDirection.magnitude == 0)
            return false;
        else
        {
            moveDirection.Normalize();
            return true;
        }
    }

    private void CheckSameDirection()
    {
        if(Vector3.Dot(moveDirection, prevDirection) <= 0.0f)
            keyInputTime = 0;
        else
            keyInputTime += Time.deltaTime;
        prevDirection = moveDirection;         
    }
    private void Move()
    {
        if(SetDirection())
        {
            CheckSameDirection();
            if(keyInputTime <= timeNeedtoRun)
                transform.Translate(moveDirection * velocityWalk * Time.deltaTime);
            else
                transform.Translate(moveDirection * velocityRun * Time.deltaTime);
            
            //Dog.GetComponent<TrackPlayer>().Track();
        }
    }
}

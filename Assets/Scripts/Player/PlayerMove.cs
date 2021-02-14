using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove: MonoBehaviour
{
    float velocityWalk = 2;
    float velocityRun = 3;
    Vector3 moveDirection;
    Vector3 prevDirection;
    float keyInputTime = 0.0f;

    [SerializeField]
    GameObject Dog;
    float timeNeedtoRun = 1.5f;
    void Update()
    {
        Move();
    }

    bool SetDirection()
    {
        moveDirection = new Vector3(0, 0, 0);

        if(Input.GetKey(KeyCode.LeftArrow))
            moveDirection += Vector3.left;

        if(Input.GetKey(KeyCode.RightArrow))
            moveDirection += Vector3.right;

        if(Input.GetKey(KeyCode.UpArrow))
            moveDirection += Vector3.up;

        if(Input.GetKey(KeyCode.DownArrow))
            moveDirection += Vector3.down;
        
        Debug.Log(moveDirection.ToString());

        if(moveDirection.magnitude == 0)
            return false;
        else
        {
            moveDirection.Normalize();
            return true;
        }
    }

    void CheckSameDirection()
    {
        if(Vector3.Dot(moveDirection, prevDirection) <= 0.0f)
            keyInputTime = 0;
        else
            keyInputTime += Time.deltaTime;         
    }
    void Move()
    {
        if(SetDirection())
        {
            CheckSameDirection();

            if(keyInputTime <= timeNeedtoRun)
                transform.Translate(moveDirection * velocityWalk * Time.deltaTime);
            else
                transform.Translate(moveDirection * velocityRun * Time.deltaTime);
            
            //Dog.GetComponent<TrackPlayer>().Track();
            prevDirection = moveDirection;
        }
    }
}

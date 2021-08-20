using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer: MonoBehaviour
{
    private float velocityWalk = 2f;
    private float velocityRun = 4;
    private Vector3 moveDirection;
    private Vector3 prevDirection;
    float keyInputTime = 0.0f;

    private float timeNeedtoRun = 1.5f;

    private float v = 0;
    private float h = 0;
    private float prevV = 0;
    private float prevH = 0;
    void Update()
    {
        Move();
    }

    /// <summary>
    /// 키보드 입력값으로 방향을 결정한다
    /// </summary>
    private bool SetDirection()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");

        //moveDirection = new Vector3(h, v, 0);
  
        moveDirection = new Vector3(0, 0, 0);
        if(0 < v && prevV <= v)
            moveDirection += Vector3.up;
        if(v < 0 && v <= prevV)
            moveDirection += Vector3.down;
        if(0 < h && prevH <= h)
        {
            FlipSprite(1);
            moveDirection += Vector3.right;          
        }
        if(h < 0 && h <= prevH)
        {
            FlipSprite(-1);
            moveDirection += Vector3.left;
        }


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

    /// <summary>
    /// 결정된 방향이 이전과 같은지 확인하여 키 입력시간을 증가시킨다. 
    /// 키 입력시간이 일정 이상이라면 속도가 빨라진다
    /// </summary>
    private void CheckSameDirection()
    {
        if(Vector3.Dot(moveDirection, prevDirection) <= 0.0f)
        {  
            keyInputTime = 0;
        }
        else
            keyInputTime += Time.deltaTime;
        prevDirection = moveDirection;         
    }

    private void FlipSprite(int x)
    {
        var sprite = gameObject.transform.Find("Sprite");
        sprite.localScale = new Vector3(x, 1, 1);
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

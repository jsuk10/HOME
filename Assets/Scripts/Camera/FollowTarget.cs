using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cinemachine이 follow할 지점을 현재 맵 길이 대비 플레이어의 위치를 계산하여 결정한다
/// </summary>
public class FollowTarget : Singleton<FollowTarget>
{
    float height = 10;
    float width = 10 * 1920/1080;
    Vector3 mapLeft;
    Vector3 mapRight;
    Vector3 mapTop;
    Vector3 mapBottom;
    Transform Border;

    GameObject player;
    GameObject dog;

    GameObject currentTarget;

    public override void Init() 
    {
        
    }

    private void Start() 
    {
        Border = transform.parent.Find("Border");
        mapLeft = Border.Find("MapLeft").position;
        mapRight = Border.Find("MapRight").position;
        mapTop = Border.Find("MapTop").position;
        mapBottom = Border.Find("MapBottom").position;
        player = MainObject.Instance.player;
        dog = MainObject.Instance.dog;
        currentTarget = player;
    }

    private void Update() 
    {
        Vector3 currentTargetPosition = currentTarget.transform.position;
        
        float xPos = Mathf.Lerp(mapLeft.x + width / 2 , mapRight.x - width / 2, (currentTargetPosition.x - mapLeft.x)/(mapRight.x - mapLeft.x));        
        float yPos = Mathf.Lerp(mapBottom.y + height / 2 , mapTop.y - height / 2, (currentTargetPosition.y - mapBottom.y)/(mapTop.y - mapBottom.y));
        
       
        transform.position = new Vector3(xPos, yPos, currentTargetPosition.z);
    }

    public void ChangeCurrentTarget(string targetName)
    {
        if(targetName == "player")
        {
            currentTarget = player;
        }
        else if(targetName == "dog")
        {
            currentTarget = dog;
        }
    }
}


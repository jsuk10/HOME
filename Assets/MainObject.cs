using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainObject : Singleton<MainObject>
{
    public GameObject dog;
    public GameObject player;

    public override void Init()
    {
        dog = transform.Find("Dog").gameObject;
        player = transform.Find("Player").gameObject;
    }
}

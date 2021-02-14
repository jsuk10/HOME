using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MonoBehaviour
{
    float velocity = 4f;
    float limitDistance = 8.0f;
    float padding = 1f;

    [SerializeField]
    GameObject Player;
    float distanceToPlayer;
    Vector3 vecToPlayer;

    // Start is called before the first frame update
    void Update()
    {
        Track();
    }

    public void Track()
    {
        vecToPlayer = Player.transform.position - this.transform.position;
        distanceToPlayer = vecToPlayer.magnitude;
        vecToPlayer.Normalize();

        if(distanceToPlayer <= limitDistance - padding)
        {
            transform.Translate(vecToPlayer * -velocity * Time.deltaTime);
        }
        else if(limitDistance + padding <= distanceToPlayer)
        {
            transform.Translate(vecToPlayer * velocity * Time.deltaTime);
        }
    }
    // Update is called once per frame
}

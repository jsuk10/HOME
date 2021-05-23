using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MonoBehaviour
{
    private float velocity = 4f;
    private float limitDistance = 8.0f;
    private float padding = 1f;

    [SerializeField]
    private GameObject Player;
    
    private float distanceToPlayer;
    private Vector3 vectorToPlayer;

    // Start is called before the first frame update
    void LateUpdate()
    {
        Track();
    }

    public void Track()
    {
        vectorToPlayer = Player.transform.position - this.transform.position;
        distanceToPlayer = vectorToPlayer.magnitude;
        vectorToPlayer.Normalize();

        if(distanceToPlayer <= limitDistance - padding)
        {
            transform.Translate(vectorToPlayer * -velocity * Time.deltaTime);
        }
        else if(limitDistance + padding <= distanceToPlayer)
        {
            transform.Translate(vectorToPlayer * velocity * Time.deltaTime);
        }
    }
    // Update is called once per frame
}

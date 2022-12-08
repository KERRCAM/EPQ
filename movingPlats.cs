using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlats : MonoBehaviour
{

    public GameObject platform;
    private float timer;
    [SerializeField] private float duration;
    [SerializeField] private float Xspeed;
    private Rigidbody2D body;

    void Start()
    {
        timer = Time.time;
        body = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        body.velocity = new Vector2(1 * Xspeed, body.velocity.y);
        if (Time.time - timer > duration)
        {
            timer = Time.time;
            Xspeed = -Xspeed;
        } 
        
    }

}

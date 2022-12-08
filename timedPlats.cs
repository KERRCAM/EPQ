using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timedPlats : MonoBehaviour
{

    public GameObject platform;
    private float timer;
    [SerializeField] private bool platState; 
    [SerializeField] private float duration;
    

    void Start()
    {
        timer = Time.time;
    }

    
    void Update()
    {
        if(Time.time - timer > duration)
        {
            platform.SetActive(platState);
            timer = Time.time;
            platState = !platState;
        }
    } 


}

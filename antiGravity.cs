using UnityEngine;

public class antiGravity : MonoBehaviour
{

    private Rigidbody2D body; 
    [SerializeField] private bool qAntiGravV;
    [SerializeField] private bool mouse0AntiGravV;
    [SerializeField] private bool splitAntiGravV;
   
    
    private float sleep;
    

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sleep = Time.time;
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Q) && qAntiGravV == true && Time.time - sleep > 2.5f  || Input.GetKey(KeyCode.Mouse0) && mouse0AntiGravV == true && Time.time - sleep > 2.5f)
        {
            body.gravityScale *= -1;
            sleep = Time.time;
        } 
        if (Input.GetKey(KeyCode.Q) && splitAntiGravV == true && Time.time - sleep > 2.5f)
        { 
            if (body.gravityScale > 0)
            {
                body.gravityScale *= -1;
                sleep = Time.time;
            }
            
            
        }
        if (Input.GetKey(KeyCode.Mouse0) && splitAntiGravV == true && Time.time - sleep > 2.5f)
        {
            if (body.gravityScale < 0)
            {
                body.gravityScale *= -1;
                sleep = Time.time;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("qAntiGravV"))
        {
            qAntiGravV = true;
        }
        if (other.gameObject.CompareTag("mouse0AntiGravV"))
        {
            mouse0AntiGravV = true;
        }
        if (other.gameObject.CompareTag("splitAntiGravV"))
        {
            splitAntiGravV = true;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("qAntiGravV"))
        {
            qAntiGravV = false;
        }
        if (other.gameObject.CompareTag("mouse0AntiGravV"))
        {
            mouse0AntiGravV = false;
        }
        if (other.gameObject.CompareTag("splitAntiGravV"))
        {
            splitAntiGravV = false;
        }
    }




}

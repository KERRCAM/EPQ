using UnityEngine;

public class antiGravity : MonoBehaviour
{

    private Rigidbody2D body; 
    [SerializeField] private bool qAntiGravV;
    [SerializeField] private bool mouse0AntiGravV;
    [SerializeField] private bool qAntiGravH;
    [SerializeField] private bool mouse0AntiGravH;
    private float gravH;
    

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        gravH = -9.81f;
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Q) && qAntiGravV == true || Input.GetKey(KeyCode.Mouse0) && mouse0AntiGravV == true)
        {
            body.gravityScale *= -1;
        } 
        if (Input.GetKey(KeyCode.Q) && qAntiGravH == true || Input.GetKey(KeyCode.Mouse0) && mouse0AntiGravH == true)
        {
            gravH = -gravH;
            Physics2D.gravity = new Vector2(gravH, 0f);
        } else if(Input.GetKey(KeyCode.S) && qAntiGravH == true || Input.GetKey(KeyCode.DownArrow) && mouse0AntiGravH == true)
        {
            Physics2D.gravity = new Vector2(0f, -9.81f);
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
        if (other.gameObject.CompareTag("qAntiGravH"))
        {
            qAntiGravH = true;
        }
        if (other.gameObject.CompareTag("mouse0AntiGravH"))
        {
            mouse0AntiGravH = true;
        }
    }


    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("qAntiGravV"))
        {
            qAntiGravV = false;
        }
        if (other.gameObject.CompareTag("mouse0AntiGravV"))
        {
            mouse0AntiGravV = false;
        }
        if (other.gameObject.CompareTag("qAntiGravH"))
        {
            qAntiGravH = false;
        }
        if (other.gameObject.CompareTag("mouse0AntiGravH"))
        {
            mouse0AntiGravH = false;
        }
    } 


    


}

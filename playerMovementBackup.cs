using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float Xspeed;
    [SerializeField] private float Yspeed;
    private Rigidbody2D body;
    [SerializeField] private bool inAir;
    public Vector2 respawnPoint;
    [SerializeField] private bool rightArrowAvailable = true;
    [SerializeField] private bool leftArrowAvailable = true;
    [SerializeField] private bool upArrowAvailable = true;
    [SerializeField] private bool wAvailable = true;
    [SerializeField] private bool aAvailable = true;
    [SerializeField] private bool dAvailable = true;
    [SerializeField] private bool eWind = false;
    [SerializeField] private bool mouse1Wind = false;
    [SerializeField] private float wind = 0;
    [SerializeField] private bool slippy = false;
    [SerializeField] private bool slippyCollision = false;
    private float lastDashV;
    private float lastDashH;
    [SerializeField] private bool eAdvMovV = false;
    [SerializeField] private bool mouse1AdvMovV = false;
    [SerializeField] private bool qAdvMovH = false;
    [SerializeField] private bool mouse0AdvMovH = false;
    private float velH = 1f;
    private float velHT;


    private void Start()
    {
        lastDashV = Time.time;
        lastDashH = Time.time;
        velHT = Time.time;
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
        

    }

    private void Update() 
    { 
        if (velH == 3f)
        {
            if(Time.time - lastDashH > 0.25f)
            {
                velH = 1f;
            }
        }
        if (slippyCollision == true && inAir == false)
        {
            slippy = true;
        }
        if (inAir == true)
        {
            slippy = false;
        }
        if (slippy == false)
        {
            body.velocity = new Vector2(wind * Xspeed, body.velocity.y);
        }
        if (Input.GetKey(KeyCode.D) && dAvailable == true || Input.GetKey(KeyCode.RightArrow) && rightArrowAvailable == true)
        {
            body.velocity = new Vector2(velH * Xspeed, body.velocity.y);
        }
        if (Input.GetKey(KeyCode.A) && aAvailable == true || Input.GetKey(KeyCode.LeftArrow) && leftArrowAvailable == true)
        {
            body.velocity = new Vector2(-velH * Xspeed, body.velocity.y);
        }

        if (Input.GetKey(KeyCode.W) && inAir == false && wAvailable == true || Input.GetKey(KeyCode.UpArrow) && inAir == false && upArrowAvailable == true)
        {
            if (body.gravityScale < 0)
            {  
                body.velocity = new Vector2(body.velocity.x, -Yspeed);
            }
            if (body.gravityScale > 0)
            {
                body.velocity = new Vector2(body.velocity.x, Yspeed); 
            }
            
        }
        if (Input.GetKey(KeyCode.E) && eWind == true || Input.GetKey(KeyCode.Mouse1) && mouse1Wind == true)
        {
            wind = -wind;
        } 

        if (Input.GetKey(KeyCode.E) && eAdvMovV == true && Time.time - lastDashV > 2.5f || Input.GetKey(KeyCode.Mouse1) && mouse1AdvMovV == true && Time.time - lastDashV > 2.5f)
        {
            if (body.gravityScale < 0)
            {
                body.velocity = new Vector2(body.velocity.x, 2*-Yspeed);
                lastDashV = Time.time;
            }
            if (body.gravityScale > 0)
            {
                body.velocity = new Vector2(body.velocity.x, 2*Yspeed);
                lastDashV = Time.time;
            }
        } 

        if (Input.GetKey(KeyCode.Q) && qAdvMovH == true && Time.time - lastDashH > 2.5f || Input.GetKey(KeyCode.Mouse0) && mouse0AdvMovH == true && Time.time - lastDashH > 2.5f)
        {
            
            velH = 3f;
            lastDashH = Time.time;
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            inAir = false;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            inAir = true;
        }
    }


    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("checkpoint"))
        {
            respawnPoint = transform.position;
        }
        if (other.gameObject.CompareTag("ground"))
        {
            inAir = false;
        }
        if (other.gameObject.CompareTag("P1UP2LR"))
        {
            wAvailable = true;
            leftArrowAvailable = true;
            rightArrowAvailable = true;
            upArrowAvailable = false;
            aAvailable = false;
            dAvailable = false;
        }
        if (other.gameObject.CompareTag("P1LRP2U"))
        {
            aAvailable = true;
            dAvailable = true;
            upArrowAvailable = true;
            leftArrowAvailable = false;
            rightArrowAvailable = false;
            wAvailable = false;
        }
        if (other.gameObject.CompareTag("P1RUP2L"))
        {
            wAvailable = true;
            dAvailable = true;
            leftArrowAvailable = true;
            upArrowAvailable = false;
            rightArrowAvailable = false;
            aAvailable = false;
        }
        if (other.gameObject.CompareTag("P1LP2RU"))
        {
            aAvailable = true;
            rightArrowAvailable = true;
            upArrowAvailable = true;
            leftArrowAvailable = false;
            dAvailable = false;
            wAvailable = false;
        }
        if (other.gameObject.CompareTag("P1RP2LU"))
        {
            dAvailable = true;
            leftArrowAvailable = true;
            upArrowAvailable = true;
            rightArrowAvailable = false;
            aAvailable = false;
            wAvailable = false;
        }
        if (other.gameObject.CompareTag("P1LUP2R"))
        {
            aAvailable = true;
            wAvailable = true;
            rightArrowAvailable = true;
            dAvailable = false;
            leftArrowAvailable = false;
            upArrowAvailable = false;

        }
        if (other.gameObject.CompareTag("eWind"))
        {
            eWind = true;
            wind = 0.3f;
        }
        if (other.gameObject.CompareTag("mouse1Wind"))
        {
            mouse1Wind = true;
            wind = 0.3f;
        }
        if (other.gameObject.CompareTag("slippy"))
        {
            slippyCollision = true;
        }
        if (other.gameObject.CompareTag("eAdvMovV"))
        {
            eAdvMovV = true;
        }
        if (other.gameObject.CompareTag("mouse1AdvMovV"))
        {
            mouse1AdvMovV = true;
        }
        if (other.gameObject.CompareTag("qAdvMovH"))
        {
            qAdvMovH = true;
        }
        if (other.gameObject.CompareTag("mouse0AdvMovH"))
        {
            mouse0AdvMovH = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            inAir = true;
        }
        if (other.gameObject.CompareTag("P1UP2LR"))
        {
            upArrowAvailable = true;
            aAvailable = true;
            dAvailable = true;
        }
        if (other.gameObject.CompareTag("P1LRP2U"))
        {
            wAvailable = true;
            leftArrowAvailable = true;
            rightArrowAvailable = true;
        }
        if (other.gameObject.CompareTag("P1RUP2L"))
        {
            rightArrowAvailable = true;
            upArrowAvailable = true;
            aAvailable = true;
        }
        if (other.gameObject.CompareTag("P1LP2RU"))
        {
            leftArrowAvailable = true;
            dAvailable = true;
            wAvailable = true;
        }
        if (other.gameObject.CompareTag("P1RP2LU"))
        {
            rightArrowAvailable = true;
            aAvailable = true;
            wAvailable = true;
        }
        if (other.gameObject.CompareTag("P1LUP2R"))
        {
            leftArrowAvailable = true;
            upArrowAvailable = true;
            dAvailable = true;
        }
        if (other.gameObject.CompareTag("eWind"))
        {
            eWind = false;
            wind = 0f;
        }
        if (other.gameObject.CompareTag("mouse1Wind"))
        {
            mouse1Wind = false;
            wind = 0f;
        } 
        if (other.gameObject.CompareTag("slippy"))
        {
            slippyCollision = false;
        }
        if (other.gameObject.CompareTag("eAdvMovV"))
        {
            eAdvMovV = false;
        }
        if (other.gameObject.CompareTag("mouse1AdvMovV"))
        {
            mouse1AdvMovV = false;
        }
        if (other.gameObject.CompareTag("qAdvMovH"))
        {
            qAdvMovH = false;
        }
        if (other.gameObject.CompareTag("mouse0AdvMovH"))
        {
            mouse0AdvMovH = false;
        }
    }

    
    
    
}


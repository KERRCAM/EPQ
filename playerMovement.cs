using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float Xspeed;
    [SerializeField] private float Yspeed;
    private Rigidbody2D body;
    [SerializeField] private bool inAir;
    public Vector2 respawnPoint;
    [SerializeField] private bool rightArrowAvailable = false;
    [SerializeField] private bool leftArrowAvailable = false;
    [SerializeField] private bool upArrowAvailable = false;
    [SerializeField] private bool wAvailable = false;
    [SerializeField] private bool aAvailable = false;
    [SerializeField] private bool dAvailable = false;
    

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
    }

    private void Update()
    {
        body.velocity = new Vector2(0 * Xspeed, body.velocity.y);
        if (Input.GetKey(KeyCode.D) && dAvailable == true || Input.GetKey(KeyCode.RightArrow) && rightArrowAvailable == true)
        {
            body.velocity = new Vector2(1 * Xspeed, body.velocity.y);
        }
        if (Input.GetKey(KeyCode.A) && aAvailable == true || Input.GetKey(KeyCode.LeftArrow) && leftArrowAvailable == true)
        {
            body.velocity = new Vector2(-1 * Xspeed, body.velocity.y);
        }

        if (Input.GetKey(KeyCode.W) && inAir == false && wAvailable == true || Input.GetKey(KeyCode.UpArrow) && inAir == false && upArrowAvailable == true)
        {
            body.velocity = new Vector2(body.velocity.x, Yspeed);
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
            wAvailable = false;
            leftArrowAvailable = false;
            rightArrowAvailable = false;
        }
    }

    

    
}

using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float Xspeed;
    [SerializeField] private float Yspeed;
    private Rigidbody2D body;
    [SerializeField] private bool inAir;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * Xspeed, body.velocity.y);

        if (Input.GetKey(KeyCode.Space) && inAir == false)
            body.velocity = new Vector2(body.velocity.x, Yspeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
            inAir = false;
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
            inAir = true;
    }

}

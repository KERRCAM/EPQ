using UnityEngine;

public class contactDeath : MonoBehaviour
{
    public GameObject start;
    public GameObject Player;
    playerMovement playerMovement;
    private Vector2 respawnPos;

    private void Awake()
    {
        playerMovement = Player.GetComponent<playerMovement>();
    }

    private void Update()
    {
        respawnPos = playerMovement.respawnPoint;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Player") )
        {
            Player.transform.position = respawnPos;
        }
    }

}

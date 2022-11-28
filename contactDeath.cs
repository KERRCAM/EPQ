using UnityEngine;

public class contactDeath : MonoBehaviour
{
    public GameObject start;
    public GameObject Player;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            Player.transform.position = start.transform.position;
    }

}

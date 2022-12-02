using UnityEngine;
using UnityEngine.SceneManagement;
public class finish : MonoBehaviour
{

    [SerializeField] string nextLevel = "";

    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            SceneManager.LoadScene(nextLevel);
    }

}

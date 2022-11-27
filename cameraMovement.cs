using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float yAdjustment = 1f;
    [SerializeField] private Transform target;
    
    private void Update()
    {
        Vector3 newPos = new Vector3(target.position.x,target.position.y + yAdjustment,-10f);
        transform.position = Vector3.Slerp(transform.position, newPos, speed * Time.deltaTime);
    }
}

using UnityEngine.UI;
using UnityEngine;
 
[ExecuteAlways]
public class timer : MonoBehaviour
{

    public static float clock = 0;
    Text time;

    void Start()
    {
        time = GetComponent<Text>();
    }

    
    void Update()
    {
        time.text = "time: " + clock;
        clock = Time.time;
    }
}

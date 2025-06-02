using UnityEngine;

public class balloonScript : MonoBehaviour
{
    
   
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 0.2f);

    }
}

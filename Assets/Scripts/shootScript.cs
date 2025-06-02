using UnityEngine;

public class shootScript : MonoBehaviour
{
    public GameObject arCamera;
    public GameObject smoke;

    public void shoot()
    {
        RaycastHit hit; 
    
    if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward ,out hit))
    {
        if(hit.transform.name == "Balloon 1(Clone)" || hit.transform.name == "Balloon 2(Clone)" || hit.transform.name == "Balloon 3(Clone)")
        {
        ScoreManager.Instance.AddPoint(1); 
        Destroy(hit.transform.gameObject);
        Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }

}
}
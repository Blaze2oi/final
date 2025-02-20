using UnityEngine;

public class nextimg : MonoBehaviour
{
    public GameObject img2;
    public GameObject img3;
    public GameObject img4;
    int n = 1;
    
    public void onclick()
    {
        n++;
    }
    private void FixedUpdate()
    {
        if (n == 2)
        {
            img2.SetActive(true);
        }
        if (n == 3)
        {
            img3.SetActive(true);
        }
        if (n == 4)
        {
            img4.SetActive(true);
        }
        if(n == 5)
        {
            img4.SetActive(false);
        }
    }
}

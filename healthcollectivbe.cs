
using UnityEngine;

public class healthcollectivbe : MonoBehaviour
{
    [SerializeField] private float healthvalue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<health>().AddHealth(healthvalue);
            gameObject.SetActive(false);
        }
    }
}

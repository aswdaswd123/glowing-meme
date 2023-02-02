
using UnityEngine;

public class enemy_sidways : MonoBehaviour
{
    [SerializeField] private float damage;
   [SerializeField] private float movementdistance;
    [SerializeField] private float speed;
    private bool movingleft;
    private float leftedge;
    private float rightedge;


    private void Awake()
    {
        leftedge = transform.position.x - movementdistance;
        rightedge = transform.position.x + movementdistance;
    }


    private void Update()
    {
        if (movingleft)
        {
            if (transform.position.x > leftedge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingleft = false;

        }
        else
        {
            if (transform.position.x < rightedge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingleft = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag == "Player")
        {
            collision.GetComponent<health>().takedamage(damage);
        }
    }
}

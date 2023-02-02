
using UnityEngine;

public class projectile : MonoBehaviour
{
   [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private float lifetime;


    private BoxCollider2D boxcollider;
    private Animator anim;

    private void Awake()
    {
        boxcollider= GetComponent<BoxCollider2D>();
        anim= GetComponent<Animator>();

    }

    private void Update()
    {
        if (hit) return;
        float movmentspeed = speed * Time.deltaTime * direction;
        transform.Translate(movmentspeed,0,0);
        lifetime += Time.deltaTime;
        if (lifetime > 3) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxcollider.enabled = false;
        anim.SetTrigger("explode");
    }
    public void setdirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit= false;
        boxcollider.enabled = true;

        float localscaleX = transform.localScale.x;
        if(Mathf.Sign(localscaleX) != _direction)
            localscaleX = -localscaleX;

        transform.localScale = new Vector3(localscaleX,transform.localScale.y, transform.localScale.z);
    }

    private void deactivate()
    {
        gameObject.SetActive(false);
    }
}

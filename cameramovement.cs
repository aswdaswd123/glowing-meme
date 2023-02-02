
using UnityEngine;

public class cameramovement : MonoBehaviour
{
   [SerializeField] private float speed;
    private float correntposX;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform player;
    private void Update()
    {
        //room camera
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(correntposX, transform.position.y, transform.position.z), ref velocity, speed * Time.deltaTime);

        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }

    public void movetonewroom(Transform _newroom)

    {
        correntposX= _newroom.position.x;
    }
}


using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //oogga boogaa 2.0


    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] fireballs;
    private Animator anim;
    private player_movement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<player_movement>();

    }


    //get mouse

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canattak())
            attack();

        cooldownTimer += Time.deltaTime;
    }


    private void attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
        fireballs[findfireball()].transform.position = firepoint.position;
        fireballs[findfireball()].GetComponent<projectile>().setdirection(Mathf.Sign(transform.localScale.x));

    }
    private int findfireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
             if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

}




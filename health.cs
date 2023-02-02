
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Concurrent;
using Unity.VisualScripting;

public class health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startinghealth;
    private Animator anim;
    public float currenthealth { get; private set; }
    private bool dead;
    [Header("iFrames")]
    [SerializeField] private float iframesduration;
    [SerializeField] private int numberofflashes;
    private SpriteRenderer spriterend;
   
    private void Awake()
    {
        currenthealth = startinghealth;
        anim = GetComponent<Animator>();
        spriterend = GetComponent<SpriteRenderer>();
    }
    public void newscence()
    {
        anim.ResetTrigger("die");
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }


    public void takedamage(float _damage)
    {
        currenthealth = Mathf.Clamp(currenthealth - _damage, 0, startinghealth);
        if (currenthealth > 0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(invurnerbulity());
            
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                GetComponent<player_movement>().enabled = false;
                dead = true;
                
                newscence();

            }
        }
    }
    public void AddHealth(float _value)
    {
        currenthealth = Mathf.Clamp(currenthealth + _value, 0, startinghealth);
    }
    private IEnumerator invurnerbulity()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        for (int i = 0; i < numberofflashes; i++)
        {
            spriterend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iframesduration / (numberofflashes * 2));
            spriterend.color = Color.white;
            yield return new WaitForSeconds(iframesduration / (numberofflashes * 2));
        }
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }
    
}

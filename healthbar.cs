
using UnityEngine.UI;
using UnityEngine;

public class healthbar : MonoBehaviour
{
    [SerializeField] private health playerhealth;
    [SerializeField] private Image totalhealthbar;
    [SerializeField] private Image currenthealthbar;


    private void Start()
    {
        totalhealthbar.fillAmount = playerhealth.currenthealth / 10;
    }
    private void Update()
    {
        currenthealthbar.fillAmount = playerhealth.currenthealth / 10;
    }
}

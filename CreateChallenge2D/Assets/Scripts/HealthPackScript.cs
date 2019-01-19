using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackScript : MonoBehaviour
{
    public int hpRegen;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerScript>().TakeDamage(hpRegen * -1);
            Destroy(gameObject);
            //Particulas, yey!
            //Sonidos, yey!
        }
        
    }
}

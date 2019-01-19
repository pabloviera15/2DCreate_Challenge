using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePlantScript : EnemyScript
{
    IEnumerator firePattern;
    public GameObject projectile;
    public float shootTime;
    public float sightRadio;
    public GameObject player;
    private void Start()
    {
        StartCoroutine("fireControl");
    }
    IEnumerator fireControl()
    {
        while (true)
        {
            if(Vector3.Distance(player.transform.position, transform.position) <= sightRadio)
            {
                GameObject bullet1 = Instantiate(projectile, transform.position, Quaternion.identity);
                bullet1.GetComponent<EnemyProjectileScript>().rb.velocity = transform.right * bullet1.GetComponent<EnemyProjectileScript>().impulse;
                GameObject bullet2 = Instantiate(projectile, transform.position, Quaternion.identity);
                bullet2.GetComponent<EnemyProjectileScript>().rb.velocity = transform.up * bullet1.GetComponent<EnemyProjectileScript>().impulse;
                GameObject bullet3 = Instantiate(projectile, transform.position, Quaternion.identity);
                bullet3.GetComponent<EnemyProjectileScript>().rb.velocity = transform.right * bullet1.GetComponent<EnemyProjectileScript>().impulse * -1;

            }
            yield return new WaitForSeconds(shootTime);
        }

        
    }
}

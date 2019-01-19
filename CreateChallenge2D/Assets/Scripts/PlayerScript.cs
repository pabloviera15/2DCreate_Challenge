using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int hp;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damageTaken)
    {
        hp -= damageTaken;
        if(hp <= 0)
        {
            print("ded");
            //gameover
        }
    }
}

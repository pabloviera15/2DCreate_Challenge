using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;
    Rigidbody2D rb;
    private float moveImput;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask groundMask;

    private float jumpTimeCounter;
    public float jumpPower;
    public float jumpTime;
    private bool isJumping;

    public GameObject bullet;
    public float shootTime;
    public Transform aim;

    IEnumerator shtCtrl;
    bool shoot;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shtCtrl = Shooting();
        StartCoroutine(shtCtrl);
        shoot = false;
    }
    private void FixedUpdate()
    {
        moveImput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveImput * speed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(moveImput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }else if (moveImput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius,groundMask);
        
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpPower;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpPower;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        if (Input.GetAxis("Fire1") > 0)
        {
            shoot = true;
            print(shoot);
        }
        else { shoot = false; }
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            if (shoot)
            {
                GameObject bala = Instantiate(bullet, transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(shootTime);
            
        }
    }
}


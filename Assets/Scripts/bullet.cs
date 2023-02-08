using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public int hp;
    //public prefab bullet;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        hp = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D (Collision2D coll)
    {
        if (coll.gameObject == true)
        {
            hp--;
            if (hp == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int hp;
    public GameObject enemy1;

    void Start()
    {
        hp = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D (Collision2D coll)
    {
        if (coll.gameObject.tag == "bullet")
        {
            hp--;
            if (hp == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public float depth = 1;

    Player player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float realVelocity = player.velocity.x / depth;
        Vector2 pos = transform.position;

        pos.x -= realVelocity * Time.fixedDeltaTime;

        if(gameObject.tag == "bridge")
        {
            if (pos.x <= -41)
                pos.x = 127f;
        }
        if (gameObject.tag == "bldng")
        {
            if(pos.x <= -25)
            pos.x = 80;
        }
        if (gameObject.tag == "train")
        {
            if (pos.x <= -500)
                pos.x = 1500;
        }


        transform.position = pos;
    }
}

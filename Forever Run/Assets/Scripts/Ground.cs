using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // Start is called before the first frame update
    Player player;
    BoxCollider2D collider;
    public float groundHeight;
    public float groundRight;
    public float screenRight;
    bool didgenerateground = false;

    public Obstacle obstacletemplate;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        collider = GetComponent<BoxCollider2D>();
        groundHeight = transform.position.y + (collider.size.y / 2) +24.5f;
        screenRight = Camera.main.transform.position.x * 2;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos.x -= player.velocity.x * Time.fixedDeltaTime;

       

        groundRight = transform.position.x + (collider.size.x / 2)+32f;

        if(groundRight < 0)
        {
            Destroy(gameObject);
            return;
        }

        if (!didgenerateground)
        {
            if (groundRight < screenRight)
            {
                didgenerateground = true;
                generateground();
            }
        }
        transform.position = pos;
    }

   public void generateground()
    {
        GameObject go = Instantiate(gameObject);
        BoxCollider2D gocollider = go.GetComponent<BoxCollider2D>();
        Vector2 pos;
        float h1 = player.jumpVelocity * player.maxHoldJumpTime;
        float t = player.jumpVelocity / -player.gravity;
        float h2 = player.jumpVelocity * t + (0.5f * (player.gravity * (t * t)));
        float maxJumpHeight = h1 + h2;
        float maxY = maxJumpHeight*0.5f;
        maxY += groundHeight;
        float minY = 2;
        float actualY = Random.Range(minY, maxY); 

        
        
        pos.y = actualY - (gocollider.size.y / 2 + 24.5f);
        if(pos.y > -4f)
        {
            pos.y = -4f;

        }

        float t1 = t + player.maxHoldJumpTime;
        float t2 = Mathf.Sqrt((2.0f * (maxY-actualY))/ -player.gravity);
        float totalTime = t1 + t2;
        float maxX = totalTime * player.velocity.x;
        maxX *= 0.5f;
        maxX += groundRight;
        float minX = screenRight + 5;
        float actualX = Random.Range(minX, maxX);



        pos.x = actualX + (collider.size.x / 2 + 32f);
        
        go.transform.position = pos;

        Ground goGround = go.GetComponent<Ground>();
        goGround.groundHeight = go.transform.position.y + (gocollider.size.y / 2) + 24.5f;

        int obstaclenum = Random.Range(0, 3);
        for(int i = 0; i < obstaclenum;  i++)
        {
            GameObject box = Instantiate(obstacletemplate.gameObject);
            float y = goGround.groundHeight;
            float halfwidth = gocollider.size.x / 2 + 32f - 5;
            float left = go.transform.position.x - halfwidth;
            float right = go.transform.position.x + halfwidth;
            float x = Random.Range(left, right);

            Vector2 boxPos = new Vector2(x,y+0.2f); 
            box.transform.position = boxPos;


        }




    }

}

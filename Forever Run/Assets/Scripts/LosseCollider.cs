using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LosseCollider : MonoBehaviour
{
    Player player;
    Text distancetext;

    GameObject results;
    Text finalDistanceText; // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player = GameObject.Find("Player").GetComponent<Player>();
            distancetext = GameObject.Find("Distance Text").GetComponent<Text>();
            results = GameObject.Find("Results");
            finalDistanceText = GameObject.Find("FinalDistanceText").GetComponent<Text>();

            results.SetActive(false);

            int distance = Mathf.FloorToInt(player.distance);
            distancetext.text = distance + "m";
            if (player.isDead)
            {
                results.SetActive(true);
                finalDistanceText.text = distance + "m";
            }
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

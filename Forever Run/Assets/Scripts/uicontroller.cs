using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uicontroller : MonoBehaviour
{
    // Start is called before the first frame update
    Player player;
    Text distancetext;
    bool ispaused = false;
    

    GameObject results;
    Text finalDistanceText;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        distancetext = GameObject.Find("Distance Text").GetComponent<Text>();
        results = GameObject.Find("Results");
        finalDistanceText = GameObject.Find("FinalDistanceText").GetComponent<Text>();

        results.SetActive(false);
        
        
       
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int distance = Mathf.FloorToInt(player.distance);
        distancetext.text = distance + "m";

        if (player.isDead)
        {
            results.SetActive(true);
            finalDistanceText.text = distance + "m";
           
        }
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
        Destroy(GameObject.Find("my music"));
    }

    public void Retry()
    {
        SceneManager.LoadScene("Main Game");
    }
/*
    public void pause()
    {
        ispaused = true;
        if (ispaused == true)
            Time.timeScale = 0;
    }
    public void unpause()
    {
        ispaused = false;
        if (ispaused == false)
            Time.timeScale = 1;
    }
*/
}

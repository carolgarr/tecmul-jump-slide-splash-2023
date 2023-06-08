using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int numberCollectibles;
    public GameObject endMessage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Display Game Over message
        if (numberCollectibles == 0)
        {
            endMessage.SetActive(true);
        }
    }
}

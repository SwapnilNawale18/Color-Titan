using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelUnlockSystem
{
public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {//Check whether only ball collied with finishline
        BallController ball = other.GetComponent<BallController>();

        if(!ball || GameManager.singleton.GameEnded)
        {
            return;
        }

        Debug.Log("Goal was touched");
        GameManager.singleton.EndGame(true);
    }
    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
}
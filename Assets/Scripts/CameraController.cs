using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelUnlockSystem
{
public class CameraController : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (GameManager.singleton.GameStarted)
            transform.position = transform.position + Vector3.forward * 5 * Time.fixedDeltaTime;
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
//46 min
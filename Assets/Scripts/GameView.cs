using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LevelUnlockSystem
{
public class GameView : MonoBehaviour
{
    [SerializeField] private Image fillBarPorgress;
    private float lastValue;
    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.singleton.GameStarted)
        {
            return;
        }
        float traveledDistance = GameManager.singleton.EntireDistance - GameManager.singleton.DistanceLeft;
        float value = traveledDistance/GameManager.singleton.EntireDistance;

        if(GameManager.singleton.GameEnded && value < lastValue)//GameManager.singleton.gameObject
        {//to stop progressbar moving backwards
            return;
        }

        fillBarPorgress.fillAmount = Mathf.Lerp(fillBarPorgress.fillAmount, value, 5*Time.deltaTime);
        lastValue = value;
    }
}
}
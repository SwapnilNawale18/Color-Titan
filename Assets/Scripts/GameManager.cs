using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelUnlockSystem
{
public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public bool GameStarted { get; private set; }
    public bool GameEnded { get; private set; }

    [SerializeField] private float slowMotionFactor = 0.1f;
    [SerializeField] private Transform startTransform;
    [SerializeField] private Transform goalTransform;
    [SerializeField] private BallController ball;

    public float EntireDistance { get; private set; }
    public float DistanceLeft { get; private set; }

    private void Awake()
    {
        if(singleton == null)
        {
            singleton = this;
        }
        else if(singleton != this)
        {
            Destroy(gameObject);
        }

        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
    }

    public void StartGame()
    {
        GameStarted = true;
        Debug.Log("Game Started");
    }

    public void EndGame(bool win)
    {
        GameEnded = true;
        Debug.Log("Game Ended");

        if (!win)
        {
            //Restart the Game
            Invoke("RestartGame", 2 * slowMotionFactor);
            Time.timeScale = slowMotionFactor;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
        else
        {//If won then restart Game
            Invoke("RestartGame", 2);
        }
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().name);//0 in brackets
    }
    // Start is called before the first frame update
    private void Start()
    {
        EntireDistance = goalTransform.position.z - startTransform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        DistanceLeft = Vector3.Distance(ball.transform.position, goalTransform.position);
        if(DistanceLeft > EntireDistance)
        {
            DistanceLeft = EntireDistance;
        }
        if(ball.transform.position.z > goalTransform.transform.position.z)
        {
            DistanceLeft = 0;
        }
    }
}
}
//46 min
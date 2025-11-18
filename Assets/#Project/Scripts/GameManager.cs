using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private UIManager uI;
    private CameraFollow cam;
    GameObject background;
    private Dictionary<Transform, MovingPlateformBehavior> allMovingPlatforms;
    private GameObject movingPlatforms;
    private RaccoonController player;
    private GameObject prizes;
    private AudioSource chestnutSound;
    private float gameTime;
    private int score;
    private int numberOfFalls;
    public void Initialize(CameraFollow cam, RaccoonController player, GameObject prizes, UIManager uI, GameObject background, GameObject movingPlatforms, AudioSource chestnutSound)
    {
        this.uI = uI;   
        this.cam = cam;   
        this.player = player;   
        this.prizes = prizes;   
        this.background = background;   
        this.movingPlatforms = movingPlatforms; 
        this.chestnutSound = chestnutSound; 

        gameTime = 0;
        score = 0;
        numberOfFalls = 0;
    }
    void Update()
    {
        gameTime += Time.deltaTime;

        cam.Process();
        player.Process();

        for (int i = 0; i < movingPlatforms.transform.childCount; i++)
        {
            if (movingPlatforms.transform.GetChild(i).TryGetComponent<MovingPlateformBehavior>(out MovingPlateformBehavior movingPlatform))
            {
                movingPlatform.Process();
            }
        }

        for (int i = 0; i < background.transform.childCount; i++)
        {
            background.transform.GetChild(i).gameObject.TryGetComponent<ParallaxEffect>(out ParallaxEffect pe);
            pe.Process();
        }
    }
    
    public void AddOneFall()
    {
        numberOfFalls++;
    }
    public void IncreaseCounter()
    {
        chestnutSound.Play();
        score++;
        uI.IncreaseCounter();
    }
    public void Finish()
    {
        PlayerPrefs.SetFloat("gameTime", gameTime);
        PlayerPrefs.SetInt("chestnuts", score);
        PlayerPrefs.SetInt("falls", numberOfFalls);
        PlayerPrefs.Save();

        SceneManager.LoadScene("TheEnd");
    }
}

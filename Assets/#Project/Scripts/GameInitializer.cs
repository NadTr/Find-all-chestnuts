using UnityEngine;
using UnityEngine.InputSystem;

public class GameInitializer : MonoBehaviour
{
    [Header("UI and Background")]
    [SerializeField] private GameManager gm;
    [SerializeField] private UIManager uI;
    [SerializeField] private CameraFollow cam;
    [SerializeField] private Grid platforms;
    [SerializeField] private GameObject background;
    // [SerializeField] private MovingPlatefromBehavior movingPlatforms;
    [SerializeField] private GameObject prizes;

    [Space]
    [Header("Moving Platforms")]
    [SerializeField] private GameObject movingPlatforms;
    [SerializeField] private float movingPlatformSpeed = 2f;
    // [SerializeField] private ChestNutsManager chestnut;
    [Space]
    [Header("Player")]
    [SerializeField] private RaccoonController player;
    [SerializeField] private InputActionAsset actions;
    [SerializeField] private float playerSpeed = 3f;
    [SerializeField] private float jumpForce = 5f;
    [Space]
    [Header("Audios")]
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource chestnutSound;

    void Start()
    {
        InstantiateObjects();
        InitializeObjects();
    }

    private void InstantiateObjects()
    {
        gm = Instantiate(gm);
        uI = Instantiate(uI);
        cam = Instantiate(cam);
        background = Instantiate(background);
        platforms = Instantiate(platforms);

        movingPlatforms = Instantiate(movingPlatforms);
        prizes = Instantiate(prizes);
        player = Instantiate(player);

        music = Instantiate(music);
        chestnutSound = Instantiate(chestnutSound);
        
    }
    private void InitializeObjects()
    {
        gm.Initialize(cam, player, prizes, uI, background, movingPlatforms, chestnutSound);
        uI.Initialize(gm);
        cam.Initialize(gm, player.transform);

        for (int i = 0; i < background.transform.childCount; i++)
        {
            background.transform.GetChild(i).gameObject.TryGetComponent<ParallaxEffect>(out ParallaxEffect pe);
            pe.Initialize(gm, cam);
        }
        
        player.Initialize(gm, actions, playerSpeed, jumpForce);
        player.gameObject.SetActive(true);

        // movingPlatforms.Initialize(gm, movingPlatformsPos, movingPlatformSpeed);

        for (int i = 0; i < movingPlatforms.transform.childCount; i++)
        {
            if (movingPlatforms.transform.GetChild(i).TryGetComponent<MovingPlateformBehavior>(out MovingPlateformBehavior movingPlatform))
            {
                movingPlatform.Initialize(gm, movingPlatformSpeed, true);
            }
        }
        
    }
        

}

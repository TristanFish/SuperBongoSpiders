using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] builderSpiders;
    public PlayerController playerController;

    // CHANGE THIS I THINK, COULD MAKE A DATABASE??
    public SpiderSwarm silkerSpiderSwarm;
    public SpiderSwarm attackerSpiderSwarm;
    public SpiderSwarm builderSpiderSwarm;
    public SpiderSwarm eaterSpiderSwarm;

    public GameObject[] pressedOverlay;

    public GameObject pauseScreen;
    public GameObject mapScreen;

    // Start is called before the first frame update 
    void Start()
    {
        // Spawning Spiders - Right Side
        builderSpiderSwarm.AddSpiders(5, 21.3f, 22.6f, 3.0f);
        eaterSpiderSwarm.AddSpiders(2, 21.3f, 22.6f, 3.0f);

        attackerSpiderSwarm.AddSpiders(3, -18.0f, -15.5f, -1.0f);

        // Spawning Spiders - Left Side
        eaterSpiderSwarm.AddSpiders(3, -93.5f, -92.0f, -3.0f);
        builderSpiderSwarm.AddSpiders(3, -90.7f,-89.2f, -3.0f);

        builderSpiderSwarm.AddSpiders(3, -74.5f, -73.2f, -3.0f);

        silkerSpiderSwarm.AddSpiders(3, -62.5f, -61.3f, -3.0f);
        silkerSpiderSwarm.AddSpiders(6, -60.5f, -59.5f, -1.0f);



        pauseScreen.SetActive(false);
        mapScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        builderSpiders = GameObject.FindGameObjectsWithTag("BuilderSpider");


        // Button input as well for selecting spiders
        // '1' - SilkerSpiders
        // '2' - AttackerSpiders
        // '3' - BuilderSpiders
        // '4' - EaterSpiders

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectSilkerSpiders();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            SelectAttackerSpiders();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectBuilderSpiders();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectEaterSpiders();
        }

        // Pause menu - 'ESC'
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!pauseScreen.activeSelf)
            {
                PauseGame();
            } else
            {
                UnPauseGame();
            }
        }

        // Map - 'TAB'
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(!mapScreen.activeSelf)
            {
                OpenMap();
            } else
            {
                CloseMap();
            }
        }

    }

    public void SelectSilkerSpiders()
    {
        StopOtherSpiders();
        playerController.selectedSpiders = silkerSpiderSwarm;
        playerController.selectedSpiders.OnSelect();
        pressedOverlay[0].SetActive(true);

        pressedOverlay[1].SetActive(false);
        pressedOverlay[2].SetActive(false);
        pressedOverlay[3].SetActive(false);

    }

    public void SelectAttackerSpiders()
    {
        StopOtherSpiders();
        playerController.selectedSpiders = attackerSpiderSwarm;
        playerController.selectedSpiders.OnSelect();
        pressedOverlay[1].SetActive(true);

        pressedOverlay[0].SetActive(false);
        pressedOverlay[2].SetActive(false);
        pressedOverlay[3].SetActive(false);
    }
    public void SelectBuilderSpiders()
    {
        StopOtherSpiders();
        playerController.selectedSpiders = builderSpiderSwarm;
        playerController.selectedSpiders.OnSelect();
        pressedOverlay[2].SetActive(true);

        pressedOverlay[0].SetActive(false);
        pressedOverlay[1].SetActive(false);
        pressedOverlay[3].SetActive(false);
    }

    public void SelectEaterSpiders()
    {
        StopOtherSpiders();
        playerController.selectedSpiders = eaterSpiderSwarm;
        playerController.selectedSpiders.OnSelect();
        pressedOverlay[3].SetActive(true);

        pressedOverlay[0].SetActive(false);
        pressedOverlay[1].SetActive(false);
        pressedOverlay[2].SetActive(false);
    }

    public void StopOtherSpiders()
    {
        playerController.selectedSpiders.OnDeselect();
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        pauseScreen.SetActive(true);
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1.0f;
        pauseScreen.SetActive(false);
    }

    public void ResetLevel()
    {
        UnPauseGame();
        SceneManager.LoadScene("Testing_Scene");
    }

    public void OpenMap()
    {
        mapScreen.SetActive(true);
    }

    public void CloseMap()
    {
        mapScreen.SetActive(false);
    }
}

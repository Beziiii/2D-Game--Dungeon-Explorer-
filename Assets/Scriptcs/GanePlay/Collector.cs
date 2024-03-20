using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    [Header("Treasuer Counter")]
    [SerializeField] private TextMeshProUGUI treasureCounterText;

    [Header("Game Over Screen")]
    [SerializeField] private GameObject GameOverScreenObj;
   // [SerializeField] private Button GORestartButton;

    [Header("Complete Screen")]
    [SerializeField] private GameObject LCScreenObj;
   // [SerializeField] private Button NLButton;

    [Header("Game Complete Screen")]
    [SerializeField] private GameObject GCScreenObj;
   // [SerializeField] private Button RGButton;
   // [SerializeField] private Button EGButton;
   // [SerializeField] private Button BTMButton;
    [SerializeField] int _firstSceneIndex = 1;





    private Character character;
    private Pouch pouch;
    private Health health;
    private int ChestsOnMap;


    void Start()
    {
        Time.timeScale = 1;
        Health.OnPlayerDeath += DisplayGameOverScreen;
    }
    #region Awake
    public void Awake()
    {
    //
        
        character = FindObjectOfType<Character>();
        pouch = FindObjectOfType<Pouch>();
        health = FindAnyObjectByType<Health>();
        
        var Chests = FindObjectsOfType<Chest>();
        ChestsOnMap = Chests.Length;

    //    GameOverScreenObj.SetActive(false);
    //    LCScreenObj.SetActive(false);
    //    GCScreenObj.SetActive(false);
       
        
    //    health.OnPlayerDeath += DisplayGameOverScreen;
        
    //    GORestartButton.onClick.AddListener(RestartScene);
    //    NLButton.onClick.AddListener(MoveToNextLevel);
    //    RGButton.onClick.AddListener(RestarGame);
    //    EGButton.onClick.AddListener(ExitGame);
    //    BTMButton.onClick.AddListener(BackToMenu);


        if(health.health <= 0)
        {
            DisplayGameOverScreen();
        }



    }
    #endregion
    public void BackToMenu()
    {
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestarGame()
    {
        SceneManager.LoadScene(_firstSceneIndex);   
    }
    
    public void MoveToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   
    }
    
    public void DisplayGameOverScreen()
    {
        
        
            GameOverScreenObj.SetActive(true);
        
       
       
    }

    private void Update()
    {
        treasureCounterText.text = $"{pouch.GetCollectedTreasure()}/{ChestsOnMap}";
        TDLCScreen();
    }

    private void TDLCScreen()
    {
        if (pouch.GetCollectedTreasure() == ChestsOnMap && !LCScreenObj.activeSelf)
        {
            character.gameObject.SetActive(false);

            if (Application.CanStreamedLevelBeLoaded(SceneManager.GetActiveScene().buildIndex + 1))
            {
                LCScreenObj.SetActive(true);
            }
            else
            {
                GCScreenObj.SetActive(true);
            }
        }
    }
}

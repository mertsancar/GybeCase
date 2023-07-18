using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public OrderManager orderManager;
    public List<Transform> walls = new List<Transform>();
    
    public Player player;
    
    public TMP_Text goldText; 
    public TMP_Text levelText; 
    public Slider experienceSlider;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        SetGoldCount();
        SetLevel();
        SetExperience();
        
        orderManager.GenerateRandomOrders();
    }
    

    public void SetGoldCount()
    {
        goldText.text = "Gold: " + PersistenceManager.GetCurrentGold();
    }
    
    private void SetLevel()
    {
        levelText.text = PersistenceManager.GetCurrentLevel().ToString();
    }

    private void SetExperience()
    {
        var currentExperience = PersistenceManager.GetCurrentExperience();
        experienceSlider.value = currentExperience; 
    }


    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PersistenceManager 
{
    public static int GetCurrentLevel()
    {
        return PlayerPrefs.GetInt("CurrentLevel", 1);
    }
    
    public static void SetCurrentLevel(int value)
    {
        PlayerPrefs.SetInt("CurrentLevel", value);
    }
    
    public static int GetCurrentGold()
    {
        return PlayerPrefs.GetInt("CurrentGold", 0);
    }
    
    public static void SetCurrentGold(int value)
    {
        PlayerPrefs.SetInt("CurrentGold", value);
    }
    
    public static int GetProductCountById(int id)
    {
        return PlayerPrefs.GetInt("Product" + id + "Count", 0);
    }
    
    public static void SetProductCountById(int id, int value)
    {
        PlayerPrefs.SetInt("Product" + id + "Count", value);
    }
    
    public static int GetCurrentExperience()
    {
        return PlayerPrefs.GetInt("CurrentExperience", 0);
    }
    
    public static void SetCurrentExperience(int value)
    {
        PlayerPrefs.SetInt("CurrentExperience", value);
    }

    
}
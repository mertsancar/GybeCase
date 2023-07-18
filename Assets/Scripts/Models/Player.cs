using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public VariableJoystick joystick;
    
    public float movementSpeed = 5f;
    public Rigidbody rb;

    private void Update()
    {
        // rb.velocity = new Vector2(joystick.Horizontal * movementSpeed, joystick.Vertical * movementSpeed);
        Vector3 direction = Vector3.forward * joystick.Vertical * movementSpeed + Vector3.right * joystick.Horizontal * movementSpeed;
        rb.velocity = direction;
        // rb.AddForce(direction * movementSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    public void GainCoin(int coin)
    {
        var currentValue = PersistenceManager.GetCurrentGold();
        PersistenceManager.SetCurrentGold(currentValue + coin);
        GameController.instance.SetGoldCount();
    }

    public void GainProduct(int id)
    {
        var currentProductValue = GetProductById(id);
        currentProductValue += 1;
        SetProductById(id, currentProductValue);
        
        EventManager.instance.TriggerEvent(EventNames.UpdateProductCount);
    }
    
    public void SpendProduct(int id, int quantity)
    {
        var currentProductValue = GetProductById(id);
        currentProductValue -= quantity;
        SetProductById(id, currentProductValue);
        
        EventManager.instance.TriggerEvent(EventNames.UpdateProductCount);
    }
    
    public void GainExperience(int experienceValue)
    {
        var currentExperience = GameController.instance.experienceSlider.value;
        currentExperience += experienceValue;
        GameController.instance.experienceSlider.value = currentExperience;
        
        PersistenceManager.SetCurrentExperience((int)currentExperience);

        if (currentExperience >= 10)
        {
            GainLevel();
        }
    }

    private void GainLevel()
    {
        var level = PersistenceManager.GetCurrentLevel();
        var levelText = GameController.instance.levelText;
        var experienceSlider = GameController.instance.experienceSlider;
        
        level++;
        PersistenceManager.SetCurrentLevel(level);
        levelText.text = level.ToString();
        
        experienceSlider.value = 0;
        PersistenceManager.SetCurrentExperience(0);
        experienceSlider.maxValue *= 2;
    }

    public int GetProductById(int id)
    {
        return PersistenceManager.GetProductCountById(id);
    }
    
    private void SetProductById(int id, int value)
    {
        PersistenceManager.SetProductCountById(id, value);
    }
    
}

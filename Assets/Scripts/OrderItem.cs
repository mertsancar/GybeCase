using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderItem : MonoBehaviour
{
    public int productId;
    public int quantity;
    public int price;
    public int experience;

    public TMP_Text content;
    public TMP_Text goldValue;
    public Button button;
    public bool canBuy;

    public void Init(int productId, int quantity, int price, int experience)
    {
        this.productId = productId;
        this.quantity = quantity;
        this.price = price;
        this.experience = experience;

        goldValue.text = price + " Gold";
        button.onClick.AddListener(OnClickOrderItem);
        
        EventManager.instance.AddListener(EventNames.UpdateProductCount, CheckCanBuy);
        
        SetContent();
    }

    private void SetContent()
    {
        var playerProductCount = GameController.instance.player.GetProductById(productId);
        
        content.text =  "P" + productId + " " +  playerProductCount + "/" + quantity;
        canBuy = playerProductCount >= quantity;
        
        goldValue.color = canBuy ? Color.green : Color.red;
        if (button != null)
        {
            button.interactable = canBuy;
        }
    }

    private void CheckCanBuy()
    {
        SetContent();
    }

    private void OnClickOrderItem()
    {
        var player = GameController.instance.player;
        player.GainCoin(price);
        player.SpendProduct(productId, quantity);
        player.GainExperience(experience);
        
        Destroy(gameObject);
        
        OrderManager.instance.AddRandomOrder();
        
    }
    
    

    
}

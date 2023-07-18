using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager instance;
    
    public Transform orderItemsGroup;
    public GameObject orderItemPrefab;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void GenerateRandomOrders()
    {
        var level = PersistenceManager.GetCurrentLevel();
        
        for (int i = 0; i < 5; i++)
        {
            var productIndex = Random.Range(1, level+1);
            var order = Instantiate(orderItemPrefab, orderItemsGroup).GetComponent<OrderItem>();
            var quantity = Random.Range(1, level * 10);
            var price = quantity * 2;
            var experience = quantity * 1;
            
            order.Init(productIndex, quantity, price, experience);
        }
    }

    public void AddRandomOrder()
    {
        var level = PersistenceManager.GetCurrentLevel();
        var productIndex = Random.Range(1, level+1);
        var order = Instantiate(orderItemPrefab, orderItemsGroup).GetComponent<OrderItem>();
        var quantity = Random.Range(1, level * 10);
        var price = quantity * 2;
        var experience = quantity * 1;
            
        order.Init(productIndex, quantity, price, experience);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Product : MonoBehaviour
{
    public TMP_Text productName;
    public int id;
    

    public void Init(int id)
    {
        this.id = id;
        productName.text = "P" + id;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();
            player.GainProduct(id);
            Destroy(gameObject);
        }
    }
}

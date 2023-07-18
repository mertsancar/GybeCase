using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ProductManager : MonoBehaviour
{
    public GameObject prefab;
    public Transform plane;
    public int numberOfObjects = 25; 
    public float generationInterval = 1f; 
    
    private List<Vector3> generatedPositions = new List<Vector3>();
    
    
    private void Start()
    {
        StartCoroutine(GenerateObjects());
    }

    private IEnumerator GenerateObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(generationInterval);

            if (GetCurrentObjectsCount() <  numberOfObjects)
            {
                var randomPosition = GetRandomPosition();
                var randomProductId = GetRandomProductId();
                
                bool hasCollision = false;
                foreach (var generatedPos in generatedPositions)
                {
                    if (Vector3.Distance(randomPosition, generatedPos) < 1f)
                    {
                        hasCollision = true;
                        break;
                    }
                }

                if (hasCollision)
                {
                    continue;
                }
                
                var newObject = Instantiate(prefab, randomPosition, Quaternion.identity);
                var product = newObject.GetComponent<Product>();
                product.Init(randomProductId);
                
                newObject.transform.parent = plane;
                
                generatedPositions.Add(randomPosition);
                
            }
        }
    }
    
    private Vector3 GetRandomPosition()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-4f, 5f),
            1,
            Random.Range(-4f, 5f)
        );

        return randomPosition;
    }
    
    private int GetRandomProductId()
    {
        var level = PersistenceManager.GetCurrentLevel();
        return Random.Range(1, level+1);

    }

    private int GetCurrentObjectsCount()
    {
        return plane.childCount;
    }
}

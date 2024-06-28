using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    
    [SerializeField] private List<Transform> positions;
    
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private GameObject MoveBlockPrefab;
    [SerializeField] private GameObject cucumbers;
    private void Start()
    {
        int randomIndex = Random.Range(0, 3);
        Transform spawnPosition = GetPosition(randomIndex);
        
        int randomBlockVariantSpawn = Random.Range(0,11);
            
        if (randomBlockVariantSpawn == 1 || randomBlockVariantSpawn == 0)
        {
            GameObject block  =  Instantiate(blockPrefab, spawnPosition.position, spawnPosition.rotation);
        }
        if (randomBlockVariantSpawn == 9  || randomBlockVariantSpawn == 8)
        {
            GameObject cucumbers =  Instantiate(this.cucumbers, spawnPosition.position, spawnPosition.rotation);
        }
        if (randomBlockVariantSpawn == 2 || randomBlockVariantSpawn == 3 || randomBlockVariantSpawn == 11)
        {
            GameObject MoveBlock  =  Instantiate(MoveBlockPrefab, spawnPosition.position, spawnPosition.rotation);
        }
        if (randomBlockVariantSpawn == 4 || randomBlockVariantSpawn == 5 || randomBlockVariantSpawn == 6 || randomBlockVariantSpawn == 7)
        {
            GameObject coin = Instantiate(coinPrefab, spawnPosition.position, spawnPosition.rotation);
        }
    }

    private Transform GetPosition(int index)
    {
        if (index > 2)
        {
            return null;
        }
        
        return positions[index];
    }
}

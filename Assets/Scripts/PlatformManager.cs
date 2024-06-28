using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour {
    public Transform player;
    private float spawnZ = 0.0f;
    private float safeZone = 15.0f;
    private List<GameObject> activePlatforms;
    public int numberOfPlatforms = 5;
    public GameObject platformPrefab;

    void Start() {
        activePlatforms = new List<GameObject>();
        for (int i = 0; i < numberOfPlatforms; i++) {
            SpawnPlatform();
        }
    }

    void Update() {
        if (player.position.z - safeZone > (spawnZ - numberOfPlatforms * platformPrefab.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().bounds.size.z)) {
            SpawnPlatform();
        }
    }

    void SpawnPlatform() {
        GameObject platform = Instantiate(platformPrefab) as GameObject;
        platform.transform.SetParent(transform);
        platform.transform.position = Vector3.forward * spawnZ;
        spawnZ += platformPrefab.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().bounds.size.z;      
        activePlatforms.Add(platform);
    }
}

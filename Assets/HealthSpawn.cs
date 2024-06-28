using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawn : MonoBehaviour
{
    [SerializeField] private GameObject ogirok;
    [SerializeField] private GameObject tomato;
    
    void Start()
    {
        ogirok.SetActive(false);
        tomato.SetActive(false);
        int random = Random.Range(0, 2);
        if (random == 0)
        {
            ogirok.SetActive(true);
        }
        else
        {
            tomato.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

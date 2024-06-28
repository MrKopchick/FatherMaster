using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {

    void Start () { 
        
    }
    void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject);
    }
}

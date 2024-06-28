using UnityEngine;

public class SkinDisplay : MonoBehaviour
{
    //public GameObject[] skins;
    public int defaultSkinIndex = 0;
    public Material[] _materials;
    public Renderer player;
    
    void Start()
    {
        int selectedSkinIndex = SkinManager.selectedSkinIndex;

        player.material = _materials[selectedSkinIndex];
    }
}
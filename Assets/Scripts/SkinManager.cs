using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinManager : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public List<Material> skins = new List<Material>();
    private int selectedSkinIndex = 0;
    public GameObject selectedSkin;

    private void Start()
    {
        meshRenderer = selectedSkin.GetComponent<MeshRenderer>();
    }

    public void NextOption()
    {
        selectedSkinIndex++;
        if (selectedSkinIndex >= skins.Count)
        {
            selectedSkinIndex = 0;
        }

        meshRenderer.material = skins[selectedSkinIndex];
    }

    public void BackOption()
    {
        selectedSkinIndex--;
        if (selectedSkinIndex < 0)
        {
            selectedSkinIndex = skins.Count - 1;
        }

        meshRenderer.material = skins[selectedSkinIndex];
    }

    public void PlayGame()
    {
        PrefabUtility.SaveAsPrefabAsset(selectedSkin, "Assets/Prefabs/SelectedSkin.prefab");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

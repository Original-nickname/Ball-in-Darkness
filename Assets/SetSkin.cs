using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSkin : MonoBehaviour
{
    public GameObject selectedSkin;
    private Material selectedSkinMaterial;

    void Start()
    {
        selectedSkinMaterial = selectedSkin.GetComponent<MeshRenderer>().sharedMaterial;
        GetComponent<MeshRenderer>().material = selectedSkinMaterial;
    }

}

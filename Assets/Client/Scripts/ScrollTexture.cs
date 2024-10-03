// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    private float offset;
    private Material myMaterial;
    
    void Awake()
    {
        myMaterial = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        offset -= 0.2f;
        myMaterial.mainTextureOffset = new Vector2(0, offset);
    }
}
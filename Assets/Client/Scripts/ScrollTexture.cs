// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    private float offset;

    private void Update()
    {
        offset -= 0.2f;
        var renderer = GetComponent<Renderer>();
        renderer.material.mainTextureOffset = new Vector2(0, offset);
    }
}
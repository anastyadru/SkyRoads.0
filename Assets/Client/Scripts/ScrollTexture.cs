// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.using System;

using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    private float _offset;

    private void Update()
    {
        _offset -= 0.2f;
        var renderer = GetComponent<Renderer>();
        renderer.material.mainTextureOffset = new Vector2(0, offset);
    }
}
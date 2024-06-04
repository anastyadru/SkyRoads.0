// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.using System;

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    private float _offset;

    private void Update()
    {
        _offset -= 0.2f;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, _offset);
    }
}
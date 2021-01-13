﻿using UnityEngine;
using Cinemachine;


public class SwitchConfineBoundingShape : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SwitchBoundingShape();
    }

    private void SwitchBoundingShape()
    {
        PolygonCollider2D polygonCollider2d = GameObject.FindGameObjectWithTag(Tags.BoundsConfiner).GetComponent<PolygonCollider2D>();
        CinemachineConfiner cinemachineConfiner = GetComponent<CinemachineConfiner>();

        cinemachineConfiner.m_BoundingShape2D = polygonCollider2d;

        cinemachineConfiner.InvalidatePathCache();
    }
}

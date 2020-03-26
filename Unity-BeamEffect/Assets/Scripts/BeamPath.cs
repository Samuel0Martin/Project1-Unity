﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamPath : MonoBehaviour
{
    public string pathName;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathName), "easetype", iTween.EaseType.easeInOutSine, "time", time));
    }
}

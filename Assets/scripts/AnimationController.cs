using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    
    private static bool isPaused;

    public static bool IsPaused { get => isPaused; set => isPaused = value; }

    void Start()
    {
        IsPaused = false;
    }
    
    public static void Pause()
    {
        IsPaused = true;
    }

    public static void UnPause()
    {
        IsPaused = false;

    }
}

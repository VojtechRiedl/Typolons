using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{

    public Slider slider;

    public void Start()
    {
        
    }
    public Slider Slider { get => slider; set => slider = value; }
    
    public void SetValue(float value)
    {
        slider.value = value;
    } 

}

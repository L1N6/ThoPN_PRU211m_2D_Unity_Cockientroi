using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ThundererHeathBar : MonoBehaviour
{
    // Start is called before the first frame update

  
    [SerializeField] Slider slider;
    public void setValue(float value)
    {
        slider.value = value;
    }

    // Update is called once per frame

}

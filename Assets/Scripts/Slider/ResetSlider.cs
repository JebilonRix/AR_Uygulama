using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class ResetSlider : MonoBehaviour
{
    private void OnDisable()
    {
        GetComponent<PinchSlider>().SliderValue = 0.5f;
    }
}
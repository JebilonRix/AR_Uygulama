using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class RotateWithSlider : MonoBehaviour
{
    [SerializeField] private PinchSlider _pinchSlider;

    public float Angle { get; set; }

    private void Start()
    {
        if (_pinchSlider == null)
        {
            _pinchSlider = GameObject.FindGameObjectWithTag("Slider").GetComponent<PinchSlider>();
        }
    }

    private void Update()
    {
        //Objeyi slider'ýn deðerine göre döndürüyoruz.
        transform.rotation = Quaternion.Euler(
            transform.rotation.eulerAngles.x,
            (_pinchSlider.SliderValue * Angle * 2) - Angle,
            transform.rotation.eulerAngles.z);
    }
}
using UnityEngine;
using UnityEngine.UI;

public class RotateWithSlider : MonoBehaviour
{
    [SerializeField] private Slider _horizontalSlider;
    [SerializeField] private Slider _verticalSlider;

    private Quaternion _firstRotation;

    private void Start()
    {
        //Ýlk dönüklük kaydediliyor.
        _firstRotation = transform.rotation;
    }

    private void Update()
    {
        // Slider deðerini, ilk dönüklükle çarparak objeyi bir ofset ile döndürüyoruz.
        transform.rotation = _firstRotation * Quaternion.Euler(0f, _horizontalSlider.value, _verticalSlider.value);
    }
}
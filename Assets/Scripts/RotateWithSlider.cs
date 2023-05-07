using UnityEngine;
using UnityEngine.UI;

public class RotateWithSlider : MonoBehaviour
{
    [SerializeField] private Slider _horizontalSlider;
    [SerializeField] private Slider _verticalSlider;

    private Quaternion _firstRotation;

    private void Start()
    {
        //�lk d�n�kl�k kaydediliyor.
        _firstRotation = transform.rotation;
    }

    private void Update()
    {
        // Slider de�erini, ilk d�n�kl�kle �arparak objeyi bir ofset ile d�nd�r�yoruz.
        transform.rotation = _firstRotation * Quaternion.Euler(0f, _horizontalSlider.value, _verticalSlider.value);
    }
}
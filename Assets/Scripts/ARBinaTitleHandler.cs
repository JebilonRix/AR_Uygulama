using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ARBinaTitleHandler : MonoBehaviour
{
    [SerializeField] TextMeshPro Text;
    private void OnEnable()
    {
        Text.text = ARManager.Instance.CurrentInfoBox.BinaAdi;
    }
}

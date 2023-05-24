using UnityEngine;

public class SetMaterial : MonoBehaviour
{
    [SerializeField] private MeshRenderer _myMeshRenderer;
    [SerializeField] private MeshRenderer _mainMeshRenderer;

    public void SetThisMaterial()
    {
        _mainMeshRenderer.material = _myMeshRenderer.material;
    }
}
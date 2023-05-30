using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroHandler : MonoBehaviour
{
    [SerializeField] float _second;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Delay());  
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(_second);
        ARManager.Instance.SetActiveOnlyOnePanel("Main");
    }
  
   
}

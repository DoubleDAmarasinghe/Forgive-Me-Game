using Assets.SimpleLocalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multilang : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        LocalizationManager.Read();
        LocalizationManager.Language = "Sinala";
        Debug.Break();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

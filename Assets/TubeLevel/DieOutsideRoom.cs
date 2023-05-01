using System;
using UnityEngine;

public class DieOutsideRoom : MonoBehaviour {
    public void Update()
    {
        if (!gameObject.GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }    
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrimerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(Destroyed), 3f);
    }

    private void Destroyed()
    {
        Destroy(gameObject);    
    }
}

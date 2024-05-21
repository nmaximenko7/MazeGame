using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsChecker : MonoBehaviour
{
    [SerializeField] private float boundRight;
    [SerializeField] private float boundLeft;
    [SerializeField] private float offset;
    // Start is called before the first frame update
    private void CheckBounds()
    {
        if (transform.position.x > boundRight)
            transform.position = new Vector2(boundLeft + offset, transform.position.y);
        else if (transform.position.x < boundLeft)
            transform.position = new Vector2(boundRight - offset, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        CheckBounds();
    }
}

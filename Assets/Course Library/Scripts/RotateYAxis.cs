using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateYAxis : MonoBehaviour
{
    public float rotationSpeed = 200f;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}

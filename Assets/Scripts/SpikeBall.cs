using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : MonoBehaviour
{
    public float rotationAngle = 90f;

    void Update() => RotateSpikeBall();
    private void RotateSpikeBall() => transform.Rotate(transform.forward, rotationAngle * Time.deltaTime);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreatDestroyer : MonoBehaviour
{
    [SerializeField] private Transform playeTransform;
    [SerializeField] private float speed;

    private void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, playeTransform.position, speed * Time.deltaTime);
    }
}

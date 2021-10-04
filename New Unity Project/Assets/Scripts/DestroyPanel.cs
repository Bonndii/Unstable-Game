using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPanel : MonoBehaviour
{
    [SerializeField] private Transform playerTramsform;
    [SerializeField] private float destroyDistance;

    private void Update()
    {
        if(Vector3.Distance(this.transform.position, playerTramsform.position) < destroyDistance)
        {
            Destroy(this.gameObject);
        }
    }
}

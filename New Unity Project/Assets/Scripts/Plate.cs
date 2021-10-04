using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _destroyDistance;

    private void Update()
    {
        if(_destroyDistance > Vector3.Distance(this.transform.position, _player.position))
        {
            Destroy(this.gameObject);
        }
    }
}

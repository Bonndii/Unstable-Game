using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float _timer;
    public float _coolDown;
    public float _speed;
    public Transform player;
    private void Start()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, player.position, _speed * Time.deltaTime);
    }
    void Update()
    {
        if(_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        Debug.Log("Попал");
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        Debug.Log("Попал");
    }
}

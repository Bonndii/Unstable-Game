using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreatDestrction : MonoBehaviour
{
    [SerializeField] private bool yes;
    [SerializeField] private Transform playerPosotion;
    [SerializeField] private float destroyDistance;
    private void Update()
    {
        if(yes)
        {
            Debug.Log(this.transform.position.x - playerPosotion.position.x);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<GreatDestroyer>() && this.transform.position.x - playerPosotion.position.x > destroyDistance)
        {
            Destroy(this.gameObject);
            Debug.Log("lol");
        }
    }
}

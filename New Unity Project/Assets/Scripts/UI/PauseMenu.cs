using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject on;
        [SerializeField] private GameObject off;
        [SerializeField] private GameObject off1;
        [SerializeField] private GameObject wall;
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject destroyTunel;
        [SerializeField] private GameObject copyTunel;
        
        public void MainMenu()
        {
            wall.transform.position = new Vector3(-0.2f, 2, 2.7f);
            player.transform.position = new Vector3(-0.0108f, 0.0305f, 2.245f);
            Instantiate(copyTunel, destroyTunel.transform.position, destroyTunel.transform.rotation);
            Destroy(destroyTunel);
            on.SetActive(true);
            off.SetActive(false);
            off1.SetActive(false);
        }
    }
}

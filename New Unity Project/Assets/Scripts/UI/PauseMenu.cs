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
        [SerializeField] private Player player1;
        [SerializeField] private GameObject lol;
        
        public void MainMenu()
        {
            player1.isPause = false;
            player1.controller.enabled = true;
            Time.timeScale = 1f;
            wall.transform.localPosition = new Vector3(-0.2f, 2, 2.7f);
            player.transform.localPosition = new Vector3(-0.0108f, 0.0305f, 2.245f);
            Debug.Log(player.transform.position);
            lol = Instantiate(copyTunel, destroyTunel.transform.position, destroyTunel.transform.rotation);
            lol.transform.localScale = new Vector3(1, 1, 1);
            Destroy(destroyTunel);
            destroyTunel = lol;
            on.SetActive(true);
            off.SetActive(false);
            off1.SetActive(false);
        }
    }
}

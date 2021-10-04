using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private KeyCode pauseButton = KeyCode.Escape;

        private void Pause()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
        }

        private void Resume()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            Cursor.visible = false;
        }
        
        public void MainMenu(int sceneID)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(sceneID);
        }

        public void Update()
        {
            if (!Input.GetKeyDown(pauseButton)) return;

            if (pauseMenu.activeSelf)
                Resume();
            else
                Pause();
        }
    }
}

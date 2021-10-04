using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject on;
        [SerializeField] private GameObject off;
        [SerializeField] private int count;
        public void Play()
        {
            on.SetActive(true);
            off.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        public void Play(int id)
        {
            SceneManager.LoadScene(id);
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}

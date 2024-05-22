using UnityEngine;
using UnityEngine.SceneManagement;

namespace UIController
{
    public class LevelWindow : MonoBehaviour
    {
        protected virtual void OnRestartButtonClick()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        protected virtual void OnCloseButtonClick()
        {
            Time.timeScale = 1f;
            Destroy(gameObject);
        }
    }
}
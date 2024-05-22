using UnityEngine;
using EnemySpace;
using TrapSpace;
using GameManager;

namespace UIController
{
    public class UIWindowsController : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private GameObject _restartWindow;
        [SerializeField] private GameObject _gameOverWindow;
        [SerializeField] private GameObject _completeLevelWindow;

        private void OnEnable()
        {
            EnemyContact.OnKill += OnGameOverWindowOpen;
            Trap.OnKill += OnGameOverWindowOpen;
            Finish.OnWin += OnCompleteLevelOpen;
        }

        private void OnCompleteLevelOpen()
        {
            Time.timeScale = 0;
            Instantiate(_completeLevelWindow, _canvas.transform, false);
        }

        private void OnGameOverWindowOpen()
        {
            Time.timeScale = 0;
            Instantiate(_gameOverWindow, _canvas.transform, false);
        }
        public void OnRestartWindowOpen()
        {
            Time.timeScale = 0;
            Instantiate(_restartWindow, _canvas.transform, false);
        }

        private void OnDisable()
        {
            EnemyContact.OnKill -= OnGameOverWindowOpen;
            Trap.OnKill -= OnGameOverWindowOpen;
            Finish.OnWin -= OnCompleteLevelOpen;
        }
    }
}
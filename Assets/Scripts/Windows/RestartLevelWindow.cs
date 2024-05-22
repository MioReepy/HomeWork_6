using UnityEngine;
using UnityEngine.UI;

namespace UIController
{
	public class RestartLevelWindow : LevelWindow
	{
		[SerializeField] private Button _restartButton;
		[SerializeField] private Button _closeButton;

		private void Start()
		{
			Time.timeScale = 0;
			_restartButton.onClick.AddListener(base.OnRestartButtonClick);
			_closeButton.onClick.AddListener(base.OnCloseButtonClick);
		}
	}
}
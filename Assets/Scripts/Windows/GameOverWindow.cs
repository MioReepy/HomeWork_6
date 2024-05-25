using TMPro;
using UnityEngine;
using GameManager;
using UnityEngine.UI;

namespace UIController
{
	public class GameOverWindow : LevelWindow
	{
		[SerializeField] private Button _restartButton;
		[SerializeField] private TextMeshProUGUI _levelResult;

		private void Start()
		{
			Time.timeScale = 0f;
			_restartButton.onClick.AddListener(base.OnRestartButtonClick);
			_levelResult.text = $"Bonus: {Observer._commonBonus}";
		}
	}
}
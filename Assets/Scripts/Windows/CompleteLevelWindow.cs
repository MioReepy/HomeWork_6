using TMPro;
using UnityEngine;
using UnityEngine.UI;
using GameManager;

namespace UIController
{
	public class CompleteLevelWindow : LevelWindow
	{
		[SerializeField] private Button _startLevel;
		[SerializeField] private TextMeshProUGUI _levelResult;

		private void Start()
		{
			Time.timeScale = 0f;
			_startLevel.onClick.AddListener(base.OnRestartButtonClick);
			_levelResult.text = $"Enemies: {Observer._commonEnemy} \n Bonus: {Observer._commonBonus}";
		}
	}
}
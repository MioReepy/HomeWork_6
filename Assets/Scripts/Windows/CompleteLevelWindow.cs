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
			_levelResult.text = $"Enemies: {Observer._commonEnemyBonus} \n Bonus: {Observer._commonFruitBonus}";
		}
	}
}
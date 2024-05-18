using Enemy;
using Fruits;
using TMPro;
using UnityEngine;

namespace GameManager
{
	public class Observer : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _enemyDate;
		[SerializeField] private TextMeshProUGUI _bonusDate;
		private int _commonBonus;
		private int _commonEnemy;

		private void OnEnable()
		{
			EnemySnail.OnDead += EnemySnailOnDead;
			Strawberry.OnGetBonus += StrawberryOnGetBonus;
		}

		private void EnemySnailOnDead()
		{
			_commonEnemy++;
			_enemyDate.text = _commonEnemy.ToString();
		}

		private void StrawberryOnGetBonus()
		{
			_commonBonus += Strawberry._bonus;
			_bonusDate.text = _commonBonus.ToString();
		}

		private void OnDisable()
		{
			EnemySnail.OnDead -= EnemySnailOnDead;
			Strawberry.OnGetBonus -= StrawberryOnGetBonus;
		}
	}
}
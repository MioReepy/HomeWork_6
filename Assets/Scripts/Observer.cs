using EnemySpace;
using Fruits;
using TMPro;
using UnityEngine;

namespace GameManager
{
	public class Observer : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _enemyDate;
		[SerializeField] private TextMeshProUGUI _bonusDate;
		internal static int _commonBonus;
		internal static int _commonEnemy;

		private void OnEnable()
		{
			EnemyContact.OnDead += EnemySnailOnDead;
			Fruit.OnGetBonus += StrawberryOnGetBonus;
		}

		private void EnemySnailOnDead()
		{
			_commonEnemy++;
			_enemyDate.text = _commonEnemy.ToString();
		}

		private void StrawberryOnGetBonus()
		{
			_commonBonus += Fruit._bonus;
			_bonusDate.text = _commonBonus.ToString();
		}
		
		private void ResetResults()
		{
			_commonBonus = 0;
			_commonEnemy = 0;
		}

		private void OnDisable()
		{
			EnemyContact.OnDead -= EnemySnailOnDead;
			Fruit.OnGetBonus -= StrawberryOnGetBonus;
			ResetResults();
		}
	}
}
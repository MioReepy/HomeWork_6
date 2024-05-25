using EnemySpace;
using Fruits;
using TMPro;
using UnityEngine;

namespace GameManager
{
	public class Observer : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _commonDate;
		internal static int _commonFruitBonus;
		internal static int _commonEnemyBonus;
		internal static int _commonBonus;

		private void OnEnable()
		{
			EnemyContact.OnDead += EnemySnailOnDead;
			Fruit.OnGetBonus += StrawberryOnGetBonus;
		}

		private void EnemySnailOnDead()
		{
			_commonEnemyBonus += Enemy._bonus;
			_commonBonus += _commonEnemyBonus;
			_commonDate.text = _commonBonus.ToString();
		}

		private void StrawberryOnGetBonus()
		{
			_commonFruitBonus += Fruit._bonus;
			_commonBonus += _commonFruitBonus;
			_commonDate.text = _commonBonus.ToString();
		}
		
		private void ResetResults()
		{
			_commonFruitBonus = 0;
			_commonEnemyBonus = 0;
		}

		private void OnDisable()
		{
			EnemyContact.OnDead -= EnemySnailOnDead;
			Fruit.OnGetBonus -= StrawberryOnGetBonus;
			ResetResults();
		}
	}
}
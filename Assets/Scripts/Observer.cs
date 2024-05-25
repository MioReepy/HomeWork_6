using EnemySpace;
using Fruits;
using TMPro;
using UnityEngine;

namespace GameManager
{
	public class Observer : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _commonDate;
		internal static int _commonBonus;

		private void OnEnable()
		{
			EnemyContact.OnDead += EnemySnailOnDead;
			Fruit.OnGetBonus += StrawberryOnGetBonus;
		}

		private void EnemySnailOnDead()
		{
			_commonBonus += Enemy._bonus;
			_commonDate.text = _commonBonus.ToString();
		}

		private void StrawberryOnGetBonus()
		{
			_commonBonus += Fruit._bonus;
			_commonDate.text = _commonBonus.ToString();
		}
		
		private void ResetResults()
		{
			_commonBonus = 0;
		}

		private void OnDisable()
		{
			EnemyContact.OnDead -= EnemySnailOnDead;
			Fruit.OnGetBonus -= StrawberryOnGetBonus;
			ResetResults();
		}
	}
}
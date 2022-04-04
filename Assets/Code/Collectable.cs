using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Polar
{
    public class Collectable : MonoBehaviour, ICollidable
    {
        [SerializeField] private SOCollectableValues values;
		public ICollidable.ObjectType objectType;

		private void Start()
		{
			CheckType();
		}

		private void CheckType()
		{
			if (objectType == ICollidable.ObjectType.None)
			{
				Debug.LogError(gameObject.name + "'s type is none and it can't be!");
			}
		}

		public void OnCollision()
        {
            SetScore();
            SetCarbon();
			OnDespawn();
		}

		public void OnDespawn()
		{
			// Set this collectable inactive if it collides with the bear or a despawner.
			gameObject.SetActive(false);
		}

		private void SetScore()
        {
            ScoreManager.Instance.AddScore(values.score);
        }

        private void SetCarbon()
        {
            CarbonManager.Instance.AddCarbon(values.carbonImpact);
		}

		ICollidable.ObjectType ICollidable.GetObjectType()
		{
			return objectType;
		}
	}
}
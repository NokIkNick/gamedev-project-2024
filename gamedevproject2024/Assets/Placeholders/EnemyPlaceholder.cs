using UnityEngine;

public class EnemyPlaceholder : MonoBehaviour, IEnemy
{
    public event System.Action<GameObject> onDeath;

    public void Die()
    {
        onDeath?.Invoke(this.gameObject);
    }
}


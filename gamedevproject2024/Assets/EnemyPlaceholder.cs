using UnityEngine;

public class EnemyPlaceholder : MonoBehaviour, IEnemy
{
    public event System.Action<IEnemy> onDeath;

    public void Die()
    {
        onDeath?.Invoke(this);
    }
}


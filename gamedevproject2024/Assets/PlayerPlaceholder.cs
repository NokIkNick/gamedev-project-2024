using UnityEngine;

public class PlayerPlaceholder : MonoBehaviour, IPlayer
{
    public event System.Action onDeath;

    public void Die()
    {
        onDeath?.Invoke();
    }
}


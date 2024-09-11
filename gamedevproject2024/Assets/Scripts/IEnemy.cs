using System;
using UnityEngine;

public interface IEnemy
{
    event Action<GameObject> onDeath;
}

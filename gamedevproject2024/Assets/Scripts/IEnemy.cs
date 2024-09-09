using System;
using UnityEngine;

public interface IEnemy
{
    event Action<IEnemy> onDeath;
}

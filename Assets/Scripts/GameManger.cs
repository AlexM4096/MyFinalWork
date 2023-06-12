using System;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static Action OnUpdate;

    private void Update()
    {
        OnUpdate?.Invoke();
    }
}

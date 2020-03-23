using UnityEngine;

[System.Serializable]
public abstract class WinCondition : MonoBehaviour
{
    public abstract bool PlayerWins();
}
using UnityEngine;

public interface IGame
{
    string GameName { get; }
    void Initialize();
    void EndGame();
}

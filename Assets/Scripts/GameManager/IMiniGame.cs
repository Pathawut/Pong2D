using UnityEngine;

public interface IMiniGame
{
    string GameName { get; }
    void Initialize();
    void EndGame();
}

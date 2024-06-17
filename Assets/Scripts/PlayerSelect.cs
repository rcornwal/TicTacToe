using UnityEngine;

namespace TicTacToe
{
    public class PlayerSelect : MonoBehaviour
    {
        public GameSettings GameSettings;

        [SerializeField] private SceneLoader sceneLoader;

        public void SelectPlayers(int players)
        {
            GameSettings.numberOfPlayers = players;
            sceneLoader.LoadGameScene();
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TicTacToe
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadGameScene()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
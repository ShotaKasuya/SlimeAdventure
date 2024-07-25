using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneTransition
{
    public class SceneSequencer : MonoBehaviour
    {
        [SerializeField] private SceneList sceneList;

        public void SceneLoad(SceneDefinition scene)
        {
            SceneManager.LoadScene(sceneList.Scenes[(int) scene]);
        }

        public static SceneSequencer Sequencer => _sceneSequencer;
        private static SceneSequencer _sceneSequencer;

        private void Awake()
        {
            if (_sceneSequencer is null)
            {
                _sceneSequencer = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
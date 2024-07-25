using SceneTransition;
using UnityEngine;

public class SceneInvoker : MonoBehaviour
{
    [SerializeField] private SceneDefinition sceneDefinition;

    public void SceneChange()
    {
        SceneSequencer.Sequencer.SceneLoad(sceneDefinition);
    }
}

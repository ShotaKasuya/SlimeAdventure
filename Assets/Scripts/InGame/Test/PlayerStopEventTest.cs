using Cysharp.Threading.Tasks;
using InGame.Interface;
using UnityEngine;
using VContainer;

namespace InGame.Test
{
    public class PlayerStopEventTest:MonoBehaviour
    {
        [Inject]
        public void Inject(IStopEventReceiver stopEventReceiver)
        {
            // StopForSecondsTest(stopEventReceiver);
            StopUntilRestart(stopEventReceiver);
        }

        private async void StopForSecondsTest(IStopEventReceiver stopEventReceiver)
        {
            Debug.Log("Stop For Seconds Test");
            var duration = 5f;
            await UniTask.WaitForSeconds(duration);
            
            Debug.Log($"stop: {duration}");
            stopEventReceiver.Publish(new StopEvent(StopEventType.StopForSeconds, duration));

            await UniTask.WaitForSeconds(duration);
            Debug.Log($"past: {duration}");
            Debug.Log("please test player move");
        }

        private async void StopUntilRestart(IStopEventReceiver stopEventReceiver)
        {
            Debug.Log("Stop Until Restart Test");
            var duration = 5f;
            await UniTask.WaitForSeconds(duration);
            
            Debug.Log($"stop: {duration}");
            stopEventReceiver.Publish(new StopEvent(StopEventType.StopUntilRestart, duration));

            await UniTask.WaitForSeconds(duration);
            stopEventReceiver.Publish(new StopEvent(StopEventType.Restart, duration));
            Debug.Log($"past: {duration}");
            Debug.Log("please test player move");
        }
    }
}
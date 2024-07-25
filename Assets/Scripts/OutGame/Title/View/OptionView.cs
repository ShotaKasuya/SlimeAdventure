using R3;
using UnityEngine;
using UnityEngine.UI;

namespace OutGame.Title.View
{
    public class OptionView:MonoBehaviour
    {
        public Observable<float> BGMSlider => bgmSlider.OnValueChangedAsObservable();
        public Observable<float> SeSlider => seSlider.OnValueChangedAsObservable();
        public Observable<float> SensitivitySlider => sensitivitySlider.OnValueChangedAsObservable();
        
        [SerializeField] private Slider bgmSlider;
        [SerializeField] private Slider seSlider;
        [SerializeField] private Slider sensitivitySlider;
    }
}
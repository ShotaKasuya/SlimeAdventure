using KanKikuchi.AudioManager;
using OutGame.Title.View;
using R3;
using StaticVariables;

namespace OutGame.Title.Logic
{
    public class OptionChangeLogic
    {
        public OptionChangeLogic(OptionView optionView)
        {
            optionView.BGMSlider.Subscribe(value => { BGMManager.Instance.ChangeBaseVolume(value); }).AddTo(optionView);
            optionView.SeSlider.Subscribe(value => { SEManager.Instance.ChangeBaseVolume(value); }).AddTo(optionView);
            optionView.SensitivitySlider.Subscribe(value => { OptionalSettingValues.Sensitivity = value / 100f; })
                .AddTo(optionView);
        }
    }
}
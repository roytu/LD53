using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour {
    [SerializeField]
    private Sprite _unmutedImage;
    [SerializeField]
    private Sprite _mutedImage;
    [SerializeField]
    private Image _image;
    [SerializeField]
    private Slider _slider;
    [SerializeField]
    private AudioMixerGroup _audioMixerGroup;
    private string _parameterName;

    private void Start() {
        _parameterName = _audioMixerGroup.name + "Volume";
    }

    private void OnValidate() {
        if (_image == null) {
            _image = GetComponentInChildren<Image>();
        }
        if (_slider == null) {
            _slider = GetComponentInChildren<Slider>();
        }
    }

    private void Update() {
        _image.sprite = _slider.value == _slider.minValue ? _mutedImage : _unmutedImage;
        _audioMixerGroup.audioMixer.SetFloat(_parameterName, Mathf.Log(_slider.value) * 20f);
        if (_slider.value == _slider.minValue)
        {
            _audioMixerGroup.audioMixer.SetFloat(_parameterName, -100f);
        }
    }
}

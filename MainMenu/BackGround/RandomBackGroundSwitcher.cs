using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Image))]
public class RandomBackGroundSwitcher : MonoBehaviour
{
    [SerializeField] private float _switchDelay;
    [SerializeField] private Sprite[] _backgrounds;

    private Image _image;

    private void Awake() => _image = GetComponent<Image>();

    private void Start()
    {
        _image.sprite = _backgrounds[Random.Range(0, _backgrounds.Length)];
        StartCoroutine(SwitchRandomBackground());
    }

    private IEnumerator SwitchRandomBackground()
    {
        while (true)
        {
            _image.sprite = _backgrounds[Random.Range(0, _backgrounds.Length)];
            yield return new WaitForSeconds(_switchDelay);
        }
    }
}
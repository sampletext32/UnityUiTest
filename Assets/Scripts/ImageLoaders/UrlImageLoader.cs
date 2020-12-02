using System.Collections;
using Misc;
using UnityEngine;
using UnityEngine.UI;

namespace ImageLoaders
{
    [RequireComponent(typeof(Image))]
    public class UrlImageLoader : MonoBehaviour
    {
        private Image _image;

        public string Url;

        private Rotator _rotator;

        public void Start()
        {
            _image = GetComponent<Image>();
            _rotator = gameObject.AddComponent<Rotator>();
            StartCoroutine(LoadImage());
        }

        private IEnumerator LoadImage()
        {
            yield return ImageLoadingPool.Instance.Load(Url);
            _image.sprite = ImageLoadingPool.Instance.Get(Url);

            _rotator.Reset();
            Destroy(_rotator);
        }
    }
}
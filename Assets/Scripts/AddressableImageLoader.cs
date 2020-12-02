using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Image))]
    public class AddressableImageLoader : MonoBehaviour
    {
        private Image _image;

        public string AddressableName;

        private Rotator _rotator;

        public void Start()
        {
            _image = GetComponent<Image>();
            _rotator = gameObject.AddComponent<Rotator>();
            StartCoroutine(LoadImage());
        }

        private IEnumerator LoadImage()
        {
            var asyncOperation = Addressables.LoadAssetAsync<Texture2D>($"Addressables/{AddressableName}");
            yield return asyncOperation;

            var texture = asyncOperation.Result;

            var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

            _image.sprite = sprite;

            _rotator.Reset();
            Destroy(_rotator);
        }
    }
}
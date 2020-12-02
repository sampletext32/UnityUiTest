using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Misc
{
    public class ImageLoadingPool : MonoBehaviour
    {
        public static ImageLoadingPool Instance;

        private Dictionary<string, Sprite> _loadedSprites;

        private void Awake()
        {
            Instance = this;
            _loadedSprites = new Dictionary<string, Sprite>();
        }

        // Coroutine to get an image,
        // when it's called, it's either returned immediately, if a url was previously loaded
        // or awaited to load a url
        public IEnumerator Load(string url)
        {
            if (!_loadedSprites.ContainsKey(url))
            {
                _loadedSprites.Add(url, null);
                Debug.Log("Loading image");
                yield return StartCoroutine(LoadImage(url));
            }
            else if (_loadedSprites[url] == null)
            {
                Debug.Log("Already loading image");
                yield return new WaitUntil(() => _loadedSprites[url] != null);
            }
            else
            {
                Debug.Log("Image was loaded");
            }
        }

        public Sprite Get(string url)
        {
            return _loadedSprites[url];
        }

        private IEnumerator LoadImage(string url)
        {
            var webRequest = UnityWebRequestTexture.GetTexture(url);
            var asyncOperation = webRequest.SendWebRequest();

            yield return asyncOperation;

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log(webRequest.error);
                _loadedSprites[url] = Sprite.Create(new Texture2D(2, 2), new Rect(0, 0, 2, 2), new Vector2(0.5f, 0.5f));
            }
            else
            {
                Debug.Log("Request successful");
                Texture2D texture = DownloadHandlerTexture.GetContent(webRequest);
                _loadedSprites[url] = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
                    new Vector2(.5f, .5f));
            }
        }
    }
}
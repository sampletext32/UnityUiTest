using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Assets.Scripts
{
    public class AddressableImageLoader : MonoBehaviour, IImageLoader
    {
        public Texture2D Texture { get; set; }

        public string AddressableName { get; set; }

        public AddressableImageLoader(string addressableName)
        {
            AddressableName = addressableName;
        }

        private async Task<Texture2D> LoadInternal()
        {
            var handle = Addressables.LoadAssetAsync<Texture2D>(AddressableName);
            await handle.Task;

            Texture2D texture = null;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                texture = handle.Result;
                Addressables.Release(handle);
            }

            return texture;
        }

        public async Task Load()
        {
            Texture = await LoadInternal();
        }

        public async Task<Texture2D> Get()
        {
            await Load();
            return Texture;
        }
    }
}
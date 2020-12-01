using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public interface IImageLoader
    {
        Texture2D Texture { get; set; }
        Task<Texture2D> Get();
    }
}
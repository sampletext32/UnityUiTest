using System;

namespace Models
{
    [Serializable]
    public class UserData
    {
        public UserData()
        {
        }

        public UserData(string nickname, string imageUrl, int lvl)
        {
            Nickname = nickname;
            ImageUrl = imageUrl;
            Lvl = lvl;
        }

        public string Nickname { get; set; }
        public string ImageUrl { get; set; }
        public int Lvl { get; set; }
    }
}
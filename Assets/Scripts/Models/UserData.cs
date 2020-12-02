using System;

namespace Models
{
    [Serializable]
    public class UserData
    {
        public UserData()
        {
        }

        public UserData(int id, string nickname, string imageUrl, int lvl)
        {
            Id = id;
            Nickname = nickname;
            ImageUrl = imageUrl;
            Lvl = lvl;
        }

        public int Id { get; set; }
        public string Nickname { get; set; }
        public string ImageUrl { get; set; }
        public int Lvl { get; set; }
    }
}
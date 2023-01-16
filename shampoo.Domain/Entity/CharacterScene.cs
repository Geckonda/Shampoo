using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shampoo.Domain.Entity
{
    public class CharacterScene
    {
        public int? id { get; set; }
        public int? character_id { get; set; }
        public string? scene { get; set; }
        public string ShortScene()
        {
            const int limit = 50;
            if (scene != null)
            {
                if (scene.Length > limit)
                {
                    var shortScene = new StringBuilder(scene);
                    shortScene.Remove(limit, shortScene.Length - limit - 1);
                    shortScene.Append("...");
                    return shortScene.ToString();
                }
                else
                    return scene;
            }
            return "";
        }
    }
}

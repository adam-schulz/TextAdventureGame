using AdventureGame_Library1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame_Library1
{
    public enum TypeOfCharacter { Elf, Knight, Mage, Dwarf, Ranger, Bard }
    public class Character
    {
        public TypeOfCharacter CharacterType { get; set; }
        public string Weapon { get; set; }
        public int Health = 3;

        public Character() { }

        public Character(TypeOfCharacter characterType, string weapon)
        {
            CharacterType = characterType;
            Weapon = weapon;
        }
    }

    public class Monster
    {
        public string Name { get; set; }
        public int Health = 5;
        public string MonsterType { get; set; }
    }
}

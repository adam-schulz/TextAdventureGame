using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame_Library1
{
    public class AdventureGame_Repository
    {
        protected readonly List<Character> _listCharacter = new List<Character>();
        protected readonly List<Monster> _listMonster = new List<Monster>();
        //Create
        public Character AddCharacterToList(Character s)
        {
            _listCharacter.Add(s);
            return s;
        }

        public Monster AddMonsterToList(Monster r)
        {
            _listMonster.Add(r);
            return r;
        }
        //Read
        public List<Character> GetCharacters()
        {
            return _listCharacter;
        }

        public List<Monster> GetMonsters()
        {
            return _listMonster;
        }
    }
}


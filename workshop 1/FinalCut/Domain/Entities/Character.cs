namespace ITVerket.FinalCut.Domain.Entities
{
    public class Character
    {
        public string CharacterName { get; private set; }
        public Actor Actor { get; private set; }

        public Character(string characterName, Actor actor)
        {
            CharacterName = characterName;
            Actor = actor;
        }
    }
}
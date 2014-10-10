namespace Reversi
{
    public class Field
    {
        //owner == null means empty field
        public Player owner { get; private set; }

        public Field(Player owner = null)
        {
            this.owner = owner;
        }

        public bool IsEmpty()
        {
            return owner == null;
        }
    }
}

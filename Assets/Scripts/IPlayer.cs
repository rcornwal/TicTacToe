namespace TicTacToe
{
    public interface IPlayer
    {
        int ID { get; }
        void MakeMove();
    }
}
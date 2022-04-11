namespace RobotController.Api.Contracts
{
    public class MovingCommandContract
    {
        public Start Start { get; set; }
        public List<Commmand> Commmands { get; set; }

    }

    public class Start
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    public class Commmand
    {
        public string Direction { get; set; }
        public int Steps { get; set; }
    }

}

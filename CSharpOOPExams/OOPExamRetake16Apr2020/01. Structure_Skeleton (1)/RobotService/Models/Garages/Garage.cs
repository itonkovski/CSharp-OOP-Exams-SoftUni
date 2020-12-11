namespace RobotService.Models.Garages
{
    using System;
    using System.Collections.Generic;
    using RobotService.Models.Garages.Contracts;
    using RobotService.Models.Robots.Contracts;

    public class Garage : IGarage
    {
        private const int Capacity = 10;
        private readonly Dictionary<string, IRobot> robots;

        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots => throw new NotImplementedException();

        public void Manufacture(IRobot robot)
        {
            throw new NotImplementedException();
        }

        public void Sell(string robotName, string ownerName)
        {
            throw new NotImplementedException();
        }
    }
}

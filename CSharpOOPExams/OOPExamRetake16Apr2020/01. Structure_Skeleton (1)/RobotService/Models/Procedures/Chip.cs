namespace RobotService.Models.Procedures
{
    using System;
    using RobotService.Models.Robots.Contracts;
    using RobotService.Utilities.Messages;

    public class Chip : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            // TODO

            if (robot.IsChipped)
            {
                string msg = string.Format(ExceptionMessages.AlreadyChipped, robot.Name);
                throw new ArgumentException(msg);
            }


            robot.ProcedureTime -= procedureTime;
            robot.Happiness -= 5;
            robot.IsChipped = true;
            this.Robots.Add(robot);
        }
    }
}

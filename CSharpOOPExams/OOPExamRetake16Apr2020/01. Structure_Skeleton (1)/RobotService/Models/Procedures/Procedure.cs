namespace RobotService.Models.Procedures
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using RobotService.Models.Procedures.Contracts;
    using RobotService.Models.Robots.Contracts;
    using RobotService.Utilities.Messages;

    public abstract class Procedure : IProcedure
    {
        protected Procedure()
        {
            this.Robots = new List<IRobot>();
        }

        protected IList<IRobot> Robots { get; }

        public string History()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine(this.GetType().Name);

            foreach (var robot in this.Robots)
            {
                sb
                    .AppendLine(robot.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public virtual void DoService(IRobot robot, int procedureTime)
        {
            robot.ProcedureTime -= procedureTime;

            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }
        }
    }
}

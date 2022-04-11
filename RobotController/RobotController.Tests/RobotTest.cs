using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotController.Api;
using RobotController.Api.Contracts;
using RobotController.Api.Helper;
using RobotController.Common;
using RobotController.Simulator;
using System.Collections.Generic;

namespace RobotController.Tests
{
    [TestClass]
    public class RobotTest
    {
        [TestMethod]
        public void Test_RobotCreated()
        {
            //arrange
            MovingCommandContract movingCommandContract = new MovingCommandContract()
            {
                Start = new Start()
                {
                    x = 0,
                    y = 0,
                },
                Commmands = new List<Commmand>()
                {
                    new Commmand()
                    {
                        Direction = "E",
                        Steps = 2,
                    }
                }
            };
            CommandFactory commandFactory = new CommandFactory();
            CommandString commandSet = commandFactory.CreateCommand(movingCommandContract, 100);

            //act
            Robot robot = new Robot(commandSet, null);

            //assert
            Assert.IsNotNull(robot);
        }

        [TestMethod]
        public void Test_Robot_Clean_Result()
        {
            MovingCommandContract movingCommandContract = new MovingCommandContract()
            {
                Start = new Start()
                {
                    x = 2,
                    y = 2,
                },
                Commmands = new List<Commmand>()
                {
                    new Commmand()
                    {
                        Direction = "E",
                        Steps = 2,
                    },
                    new Commmand()
                    {
                        Direction = "W",
                        Steps = 2,
                    }

                }
            };

            CommandFactory commandFactory = new CommandFactory();
            CommandString commandSet = commandFactory.CreateCommand(movingCommandContract, 100);

            //act
            Robot robot = new Robot(commandSet, new SimpleReporter());

            //assert
            robot.ExecuteCommands();
            int result = robot.PrintReport();
            Assert.AreEqual(3, result);


        }


        [TestMethod]
        public void Test_Robot_Not_More_Than_200()
        {
            MovingCommandContract movingCommandContract = new MovingCommandContract()
            {
                Start = new Start()
                {
                    x = 2,
                    y = 2,
                },
                Commmands = new List<Commmand>()
                {
                    new Commmand()
                    {
                        Direction = "E",
                        Steps = 300,
                    }
                }
            };

            CommandFactory commandFactory = new CommandFactory();
            CommandString commandSet = commandFactory.CreateCommand(movingCommandContract, 300);

            //act
            Robot robot = new Robot(commandSet, new SimpleReporter());

            //assert
            robot.ExecuteCommands();
            int result = robot.PrintReport();
            Assert.AreEqual(0, result);


        }

    }
}
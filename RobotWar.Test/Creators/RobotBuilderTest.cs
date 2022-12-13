using RobotWars.Application.Creators;
using RobotWars.Application.Entity;
using RobotWars.Application.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWar.Test.Creators
{
    public class RobotBuilderTest
    {
        private readonly IRobotBuilder _robotBuilder;
        private readonly IRobot _robot;
        private readonly IArena _arena;

        public RobotBuilderTest()
        {
            _robot = new Robot();
            _robotBuilder = new RobotBuilder(_robot);
            _arena = new Arena();
        }


        [Theory]

        [InlineData(5, 5, true)]
        [InlineData(10, 10, true)]
        [InlineData(15, 5, true)]
        [InlineData(0, 0, true)]
        [InlineData(-5, -5, false)]
        [InlineData(0, 5, true)]
        [InlineData(-5, 0, false)]
        [InlineData(0, -5, false)]
        public void CreateRobot_IsValid_IsValidPosition(int width, int height, bool expectedresult)
        {
            Assert.Equal(expectedresult, _robotBuilder.IsValidDirection(width, height));
        }

        [Theory]

        [InlineData(5, 5, true)]
        [InlineData(10, 5, true)]
        [InlineData(10, 15, false)]
        [InlineData(10, 10, true)]
        [InlineData(11, 10, false)]
        [InlineData(5, 11, false)]


        public void CreateRobot_IsValid_IsPlacedInArena(int width, int height, bool expectedresult)
        {
            _arena.width = 10;
            _arena.height = 10;
            Assert.Equal(expectedresult, _robotBuilder.EnterInArena(width, height, _arena));
        }

        [Fact]
        public void CreateRobot_Check_InvalidObject_ThrowsArgumentException()
        {
            IArena arena = null;
            Direction direction = Direction.N;

            Assert.Throws<NullReferenceException>(() => _robotBuilder.Create(10, 20, arena, direction));
        }

        [Theory]

        [InlineData(-1, -2)]
        [InlineData(-1, -1)]
        [InlineData(0, -1)]

        public void CreateRobot_Check_InvalidParameter_ThrowsArgumentException(int width, int height)
        {
            _arena.width = 10;
            _arena.height = 10;
            Direction direction = Direction.N;
            Assert.Throws<ArgumentException>(() => _robotBuilder.Create(width, height, _arena, direction));
        }

        [Theory]

        [InlineData(15, 10)]
        [InlineData(10, 15)]
        [InlineData(11, 11)]

        public void CreateRobot_Check_InvalidPosition_ThrowsArgumentException(int width, int height)
        {
            _arena.width = 10;
            _arena.height = 10;
            Direction direction = Direction.N;
            Assert.Throws<ArgumentException>(() => _robotBuilder.Create(width, height, _arena, direction));
        }

        public void CreateRobot_Check_Operation_Move()
        {
            // Still going on with this method
        }

        public void CreateRobot_Check_Operation_Rotate()
        {
            // Still going on with this method
        }




    }
}

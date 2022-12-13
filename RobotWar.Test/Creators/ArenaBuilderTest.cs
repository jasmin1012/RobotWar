using RobotWars.Application.Creators;
using RobotWars.Application.Entity;


namespace RobotWar.Test.Creators
{
    public class ArenaBuilderTest
    {
        private readonly IArenaBuilder _arenaBuilder;
        private readonly IArena _arena;
        public ArenaBuilderTest()
        {
            _arena = new Arena();
            _arenaBuilder = new ArenaBuilder(_arena);
        }


        [Theory]

        [InlineData(5, 5, true)]
        [InlineData(10, 10, true)]
        [InlineData(15, 5, true)]
        [InlineData(-5, -5, false)]
        [InlineData(0, 5, false)]
        [InlineData(5, 0, false)]
        [InlineData(0, 0, false)]
        public void CreateArena_IsValid_ValidateArena(int width, int height, bool expectedresult)
        {
            Assert.Equal(expectedresult, _arenaBuilder.ValidateArena(width, height));
        }

        [Theory]
        [InlineData(-5, -5)]
        [InlineData(0, 5)]
        [InlineData(5, 0)]
        [InlineData(0, 0)]
        public void CreateArena_Check_InvalidParameter_ThrowsArgumentException(int width, int height)
    => Assert.Throws<ArgumentException>(() => _arenaBuilder.CreateArena(width, height));

        [Theory]
        [InlineData(5, 5)]
        [InlineData(6, 10)]
        [InlineData(7, 7)]

        public void CreateArena_Check_Object_NotNull(int width, int height)
        {

            var actualArena = _arenaBuilder.CreateArena(width, height);
            Assert.NotNull(actualArena);
        }

        [Theory]
        [InlineData(5, 5)]
        [InlineData(7, 9)]
        [InlineData(7, 10)]
        public void CreateArena_Comapre_Objects_Equals(int width, int height)
        {
            IArena arena = new Arena();
            arena.width = width;
            arena.height = height;

            var actualArena = _arenaBuilder.CreateArena(width, height);
            Equals(arena, actualArena);

        }
    }
}

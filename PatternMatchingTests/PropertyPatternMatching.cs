using System;

namespace Playground
{
    public class IdAndAgeObject {
        public int Id { get; set; }
        public int Age { get; set; }
        public void Deconstruct(out int x, out int y) => (x, y) = (Id, Age);
    }


    public class PropertyPatternMatching
    {
        [Fact]
        public void TypePattern()
        {
            var testObject = new IdAndAgeObject() { Id = 144, Age = 12 };
            Assert.True(testObject is { Id: 144 });
            Assert.True(testObject is { Id: >= 100 });
            Assert.True(testObject is { Id: <= 200 });
            Assert.True(testObject is { Id: 200 } or { Age: 12 });
        }
    }

    public class PositionalPatternMatching
    {
        [Fact]
        public void TypePattern()
        {
            var testObject = new IdAndAgeObject() { Id = 144, Age = 12 };
            Assert.True(testObject is (144, 12));
        }
    }

    public class ListPatternMatching
    {
        [Fact]
        public void TypePattern()
        {
            var testObject = new List<int>() { 1,2,4,8,16 };
            Assert.True(testObject is [1,2,4,_,_]);
        }
    }
    public class SwitchPatternMatching
    {
        [Fact]
        public void TypePattern()
        {
            var a = 2;
            Assert.True(a switch
            {
                1 => false,
                _ => true
            });

            a = 1;
            Assert.False(a switch
            {
                1 => false,
                _ => true
            });
        }
    }
}


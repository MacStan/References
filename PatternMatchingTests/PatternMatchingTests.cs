namespace Playground
{
    public class TestClassOne { 
        public int Id { get; set; }
    }
    public class PatternMatchingTests
    {
        [Fact]
        public void TypePattern()
        {
            object x = 1;
            Assert.False(x is TestClassOne);
            Assert.False(x is null);
            x = null;
            Assert.True(x is null);
        }

        [Fact]
        public void DeclarationPattern()
        {
            object testObject = new TestClassOne() { Id = 14 };
            if (testObject is TestClassOne obj) {
                Assert.Equal(14, obj.Id);
            }
        }

        [Fact]
        public void ConstantPattern()
        {
            var testObject = new TestClassOne() { Id = 14 };
            
            Assert.True(testObject.Id is 14);
        }

        [Fact]
        public void DeclarationVsVarPattern()
        {
            object testObject = null;
            Assert.True(testObject is var a);
            Assert.False(testObject is object b);

            object testObject2 = new TestClassOne() { Id = 14 };
            Assert.True(testObject2 is var c && c != null && ((TestClassOne)c).Id == 14);
            Assert.True(testObject2 is TestClassOne d && d.Id == 14);
        }
    }
}
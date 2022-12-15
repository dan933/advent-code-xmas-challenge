namespace ElvesDaySevenTests
{
    public class ValidationServiceTests
    {
        [Theory]
        [InlineData("14848514 b.txt")]
        [InlineData("8504156 c.dat")]
        [InlineData("29116 f")]
        public void ShouldReturnIsFileTrue(string input)
        {
            ValidationService validationService = new ValidationService();

            var result = ValidationService.IsFile(input);

            Assert.True(result);
        }

        [Theory]
        [InlineData("dir a")]
        [InlineData("$ cd a")]
        [InlineData("$ ls")]
        public void ShouldReturnIsFileFalse(string input)
        {

            ValidationService validationService = new ValidationService();

            var result = ValidationService.IsFile(input);

            Assert.False(result);
        }

        [Theory]
        [InlineData("$ ls")]
        public void ShouldReturnIsListTrue(string input)
        {

            ValidationService validationService = new ValidationService();

            var result = ValidationService.IsList(input);

            Assert.True(result);
        }

        [Theory]
        [InlineData("dir a")]
        [InlineData("$ cd a")]
        public void ShouldReturnIsListFalse(string input)
        {

            ValidationService validationService = new ValidationService();

            var result = ValidationService.IsList(input);

            Assert.False(result);
        }

        [Theory]
        [InlineData("dir a")]
        [InlineData("dir z")]
        public void ShouldReturnIsDirectoryTrue(string input)
        {

            ValidationService validationService = new ValidationService();

            var result = ValidationService.IsDir(input);

            Assert.True(result);
        }

        [Theory]
        [InlineData("1234 a")]
        [InlineData("$ cd a")]
        public void ShouldReturnIsDirectoryFalse(string input)
        {

            ValidationService validationService = new ValidationService();

            var result = ValidationService.IsDir(input);

            Assert.False(result);
        }

        [Theory]
        [InlineData("$ cd a")]
        [InlineData("$ cd absd_11")]
        [InlineData("$ cd 1223.22")]
        public void ShouldReturnIsDirectoryForwardTrue(string input)
        {

            ValidationService validationService = new ValidationService();

            var result = ValidationService.IsCDForward(input);

            Assert.True(result);
        }

        [Theory]
        [InlineData("1112 cd.file")]
        [InlineData("acd absd_11")]
        [InlineData("$ cd_f.file")]
        public void ShouldReturnIsDirectoryForwardFalse(string input)
        {

            ValidationService validationService = new ValidationService();

            var result = ValidationService.IsCDForward(input);

            Assert.False(result);
        }

        [Theory]
        [InlineData("$ cd ..")]
        public void ShouldReturnIsDirectoryBackwardTrue(string input)
        {

            ValidationService validationService = new ValidationService();

            var result = ValidationService.IsCDBackward(input);

            Assert.True(result);
        }

        [Theory]
        [InlineData("$ cd absd_11")]
        [InlineData("dir z")]
        [InlineData("8504156 c.dat")]
        public void ShouldReturnIsDirectoryBackwardFalse(string input)
        {

            ValidationService validationService = new ValidationService();

            var result = ValidationService.IsCDBackward(input);

            Assert.False(result);
        }
    }
}
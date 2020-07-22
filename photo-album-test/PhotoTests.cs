using FluentAssertions;
using photo_album;
using Xunit;

namespace photo_album_test
{
    public class PhotoTests
    {
        [Fact]
        public void GivenPhotoWithTitleAndId_WhenToString_ThenOutputIsFriendly()
        {
            var photo = new Photo("My Photo", 42);

            photo.ToString().Should().Be("[42] My Photo");
        }

        [Fact]
        public void GivenPhotoWithNullTitle_WhenToString_ThenOutputIsMissingTitle()
        {
            var photo = new Photo(null, 123);

            photo.ToString().Should().Be("[123] ");
        }
    }
}
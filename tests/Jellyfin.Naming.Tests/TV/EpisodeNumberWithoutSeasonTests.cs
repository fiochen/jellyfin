using Emby.Naming.Common;
using Emby.Naming.TV;
using Xunit;

namespace Jellyfin.Naming.Tests.TV
{
    public class EpisodeNumberWithoutSeasonTests
    {
        private readonly EpisodeResolver _resolver = new EpisodeResolver(new NamingOptions());

        [Theory]
        [InlineData(8, "The Simpsons/The Simpsons.S25E08.Steal this episode.mp4")]
        [InlineData(2, "The Simpsons/The Simpsons - 02 - Ep Name.avi")]
        [InlineData(2, "The Simpsons/02.avi")]
        [InlineData(2, "The Simpsons/02 - Ep Name.avi")]
        [InlineData(2, "The Simpsons/02-Ep Name.avi")]
        [InlineData(2, "The Simpsons/02.EpName.avi")]
        [InlineData(2, "The Simpsons/The Simpsons - 02.avi")]
        [InlineData(2, "The Simpsons/The Simpsons - 02 Ep Name.avi")]
        [InlineData(7, "GJ Club (2013)/GJ Club - 07.mkv")]
        [InlineData(17, "Case Closed (1996-2007)/Case Closed - 317.mkv")]
        [InlineData(3, "fool/[foo] seriesname 03 1080p.mkv")]
        [InlineData(3, "fool/[foo] seriesname 03 [HEVC-10bit].mkv")]
        [InlineData(3, "fool/[foo] seriesname 03 [Ma10p-720p].mkv")]
        [InlineData(3, "fool/[foo] seriesname 03 [Hi10p-1080i].mkv")]
        [InlineData(3, "fool/[foo] seriesname 03 [HDR-4k].mkv")]
        [InlineData(3, "fool/[foo] seriesname 03.mkv")]
        [InlineData(3, "fool/[foo] seriesname Volume 4 [S4E03v2].mkv")]
        [InlineData(1, "fool/[foo] seriesname 第01話.mkv")]
        // TODO: [InlineData(2, @"The Simpsons/The Simpsons 5 - 02 - Ep Name.avi")]
        // TODO: [InlineData(2, @"The Simpsons/The Simpsons 5 - 02 Ep Name.avi")]
        // TODO: [InlineData(7, @"Seinfeld/Seinfeld 0807 The Checks.avi")]
        // This is not supported anymore after removing the episode number 365+ hack from EpisodePathParser
        // TODO: [InlineData(13, @"Case Closed (1996-2007)/Case Closed - 13.mkv")]
        public void GetEpisodeNumberFromFileTest(int episodeNumber, string path)
        {
            var result = _resolver.Resolve(path, false);

            Assert.Equal(episodeNumber, result?.EpisodeNumber);
        }
    }
}

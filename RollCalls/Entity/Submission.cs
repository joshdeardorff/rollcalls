#nullable enable

namespace RollCalls.Entity
{
    public class Submission
    {
        public Submission() { }
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? YouTubeLink { get; set; }

        public string? SpotifyName { get; set; }

        public TimeOnly SpotifyStartTime { get; set; }

        public int LightingId { get; set; } = 0;

        public int Microphones { get; set; } = 1;

        public string? Description { get; set; }

        public int Iteration { get; set; } = 0;
    }
}

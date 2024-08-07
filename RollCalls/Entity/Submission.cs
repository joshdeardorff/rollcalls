#nullable enable

using System.ComponentModel.DataAnnotations;

namespace RollCalls.Entity
{
    public class Submission
    {
        public Submission() { }

        public Submission(int id, string name)
        {
            Id = id;
            Name = name;
            Position = id;
        }
        public int Id { get; set; }

        public int? Position { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? YouTubeLink { get; set; }

        public string? SpotifyName { get; set; }

        public TimeOnly? SpotifyStartTime { get; set; } = null;

        public int LightingId { get; set; } = 0;

        public bool Microphones { get; set; } = false;

        public string? Description { get; set; }

        public int Iteration { get; set; } = 0;
    }
}

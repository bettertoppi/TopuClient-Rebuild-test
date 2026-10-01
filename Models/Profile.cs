namespace TopuClient.Models
{
    public class Profile
    {
        public string Name { get; set; } = "Default Profile";
        public string VersionId { get; set; } = "1.20.1";
        public string LoaderType { get; set; } = "Vanilla"; // Vanilla, Forge, Fabric, NeoForge, Quilt
        public string LoaderVersion { get; set; } = string.Empty;
        public int RamMb { get; set; } = 4096;
        public string Resolution { get; set; } = "1280x720";
    }
}

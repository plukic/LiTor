using System.Threading.Tasks;

namespace System.IO
{
    /// <summary>
    /// Extension methods for <see cref="Stream"/> classes
    /// </summary>
    public static class StreamExtensions
    {
        public static byte[] GetAllBytes(this Stream stream)
        {
            using var memoryStream = new MemoryStream();
            stream.Position = 0;
            stream.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }

        /// <summary>
        /// Interesting: https://stackoverflow.com/a/45462089
        /// </summary>
        public static async Task<byte[]> GetAllBytesAsync(this Stream stream)
        {
            using var memoryStream = new MemoryStream();
            stream.Position = 0;
            await stream.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
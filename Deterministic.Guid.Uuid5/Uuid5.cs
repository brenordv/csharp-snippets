using System.Security.Cryptography;
using System.Text;

namespace Deterministic.Guid.Uuid5;

public static class Uuid5
{
    /// <summary>
    /// Generates a new GUID based on the provided arguments using MD5 hashing.
    /// </summary>
    /// <remarks>This is a deterministic Guid, so the same inputs will result in the same UUID values.</remarks>
    /// <param name="args">An array of objects to be used as input for generating the GUID. 
    /// At least one argument must be provided.</param>
    /// <returns>A new <see cref="System.Guid"/> generated from the MD5 hash of the input arguments.</returns>
    /// <exception cref="ArgumentException">Thrown when no arguments are provided.</exception>
    /// <example>
    /// <code>
    /// var guid = Uuid5.NewGuid("example", 123, true);
    /// </code>
    /// </example>
    public static System.Guid NewGuid(params object[] args)
    {
        if (args.Length == 0)
            throw new ArgumentException("At least one argument must be provided.");

        var hash = MD5.HashData(Encoding.UTF8.GetBytes(string.Join("-", args)));
        return new System.Guid(hash);
    }
}
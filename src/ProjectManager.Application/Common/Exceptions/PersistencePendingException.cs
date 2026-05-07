namespace TaskForge.Application.Common.Exceptions;

/// <summary>
/// Thrown when persistence is not wired yet (before EF scaffold / repository implementation).
/// </summary>
public sealed class PersistencePendingException : Exception
{
    public PersistencePendingException(string message)
        : base(message)
    {
    }
}

namespace TaskManagerApi.Middleware
{
    public interface ISecurityHeadersPolicy
    {
        IDictionary<string, string> SetHeaders { get; }
        ISet<string> RemoveHeaders { get; }
    }
}

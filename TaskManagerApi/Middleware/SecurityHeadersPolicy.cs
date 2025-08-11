
namespace TaskManagerApi.Middleware
{
    public class SecurityHeadersPolicy : ISecurityHeadersPolicy
    {
        public IDictionary<string, string> SetHeaders { get; private set; }

        public ISet<string> RemoveHeaders { get; private set; }

        public SecurityHeadersPolicy()
        {
            SetHeaders = new Dictionary<string, string>();
            RemoveHeaders = new HashSet<string>();
        }
    }
}

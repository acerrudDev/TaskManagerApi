namespace TaskManagerApi.Middleware
{
    public static class SecurityHeadersExtensions
    {
        public static IServiceCollection AddSecurityHeaders(this IServiceCollection services)
        {
            var policy = new SecurityHeadersPolicy();

            // Security Headers
            policy.SetHeaders["X-Content-Type-Options"] = "nosniff";
            policy.SetHeaders["X-Frame-Options"] = "DENY";
            policy.SetHeaders["X-XSS-Protection"] = "1; mode=block";
            policy.SetHeaders["Referrer-Policy"] = "no-referrer";
            policy.SetHeaders["Content-Security-Policy"] = "default-src 'self';";

            // Remove unnecesary headers
            policy.RemoveHeaders.Add("Server");

            services.AddSingleton<ISecurityHeadersPolicy>(policy);
            return services;
        }

        public static IApplicationBuilder UseSecurityHeaders(this IApplicationBuilder app)
        {
            var policy = app.ApplicationServices.GetRequiredService<ISecurityHeadersPolicy>();
            return app.UseMiddleware<SecurityHeadersMiddleware>(policy);
        }
    }
}

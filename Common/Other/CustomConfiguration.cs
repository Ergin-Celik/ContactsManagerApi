using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class CustomConfiguration
    {
        public DatabaseConfiguration Database { get; set; }
        public SwaggerConfiguration Swagger { get; set; }
        public JwtTokenConfiguration JwtToken { get; set; }
    }

    public class DatabaseConfiguration
    {
        public string ConnectionString { get; set; }
    }

    public class SwaggerConfiguration 
    {
        public string EndpointUrl { get; set; }
        public string EndpointName { get; set; }
        public string XmlDocumentationFilePath { get; set; }
    }

    public class JwtTokenConfiguration
    {
        public string SecretKey { get; set; }
    }
}

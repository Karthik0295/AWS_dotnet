using Amazon;
using Amazon.Runtime;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Secrets_Manager.Controllers
{
    [ApiController]
    [Route("aws/")]
    public class AWSController : ControllerBase
    {

        private readonly ILogger<AWSController> _logger;
        private readonly IAmazonSecretsManager _amazonSecretsManager;
    
        public AWSController(ILogger<AWSController> logger)
        {
            _logger = logger;

            var accessKey = Environment.GetEnvironmentVariable("AccessKey");
            var secretKey = Environment.GetEnvironmentVariable("SecretKey");
            var region = Environment.GetEnvironmentVariable("Region");

            var awsCredentials = new BasicAWSCredentials(accessKey, secretKey);
            var awsRegion = RegionEndpoint.GetBySystemName(region);

            _amazonSecretsManager = new AmazonSecretsManagerClient(awsCredentials, awsRegion);
        }

        [HttpGet("secretName")]
        public async Task<IActionResult> GetSecrets(string secretName)
        {
            try
            {
                string SecrectName = secretName;
                GetSecretValueRequest request = new GetSecretValueRequest
                {
                    SecretId = secretName,
                };

                GetSecretValueResponse response = await _amazonSecretsManager.GetSecretValueAsync(request);
                string configJson = response.SecretString;
                SecretConfig secretConfig = JsonConvert.DeserializeObject<SecretConfig>(configJson);

                return Ok(new { Secret = secretConfig });
            }
            catch (AmazonSecretsManagerException ex) when (ex.ErrorCode == "ResourceNotFoundException")
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get secret for application ", ex);
            }
        }

        [HttpPost("secretName")]
        public async Task<IActionResult> PostSecret([FromBody] SecretConfig secretConfig, string secretName)
        {
            try
            {
                string serializedSecretConfig = JsonConvert.SerializeObject(secretConfig);

                CreateSecretRequest request = new CreateSecretRequest
                {
                    Name = secretName,
                    SecretString = serializedSecretConfig
                };

                CreateSecretResponse response = await _amazonSecretsManager.CreateSecretAsync(request);

                return Ok(new { SecretId = response.ARN });
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create secret for application ", ex);
            }
        }

        public class SecretConfig
        {
            public string Connection_String { get; set; }
            public string Client_Secret_Key { get; set; }
            public string Client_Access_Key { get; set; }
        }
    }
}

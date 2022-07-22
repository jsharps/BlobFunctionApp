global using Azure.Security.KeyVault.Secrets;
global using Microsoft.Azure.Services.AppAuthentication;
using Azure.Identity;

namespace Service
{
    public class Class1
    {
        public  Task GetSecretValue(string keyName)
        {
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();
            var keyVaultClient = new SecretClient(vaultUri: new Uri(Environment.GetEnvironmentVariable("KeyVault")), credential: new DefaultAzureCredential());

            KeyVaultSecret secret =  keyVaultClient.GetSecret(keyName);
 
            Console.WriteLine(secret);
               
            return Task.CompletedTask;
        }
    }
}
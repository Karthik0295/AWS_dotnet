<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
</head>
<body>
  <h1>AWS .NET Integration</h1>


  <p>This branch contains a sample ASP.NET Core application that demonstrates integration with AWS Secrets Manager for storing and retrieving secrets.</p>

  <p>This Repository contains a sample ASP.NET Core application that demonstrates integration with AWS Services.</p>


  <h2>Prerequisites</h2>
  <p>Before running the application, ensure that you have the following prerequisites installed and configured:</p>
  <ul>
    <li><a href="https://repost.aws/knowledge-center/create-and-activate-aws-account"><strong>Create AWS Account</strong></a></li>
    <li>Install Nuget Packages:
      <ul>
        <li>.NET Core SDK (version 3.1 or later)</li>
        <li>AWS SDK for .NET (installed via NuGet package)</li>

      </ul>
    </li>
  </ul>

  <h2>Setup</h2>
  <ol>
    <li><strong>Clone this repository to your local machine:</strong><br><code>git clone https://github.com/Karthik0295/AWS_dotnet.git</code></li>

    <li><strong>Navigate to the project directory:</strong><br><code>cd Secrets_Manager</code></li>
    <li><strong>Open the env file and configure your AWS credentials:</strong><br><pre>AccessKey=<br>SecretKey=<br>Region=</pre></li>

  </ol>

  <h2>Usage</h2>
  <p><strong>Get Secret</strong>:<br>To retrieve a secret from AWS Secrets Manager, send a GET request to the following endpoint:<br><code>GET /secret/{secretName}</code><br>Replace <code>{secretName}</code> with the name of the secret stored in AWS Secrets Manager.</p>

  <p><strong>Post Secret</strong>:<br>To save a secret to AWS Secrets Manager, send a POST request with the secret data in the request body to the following endpoint:<br><code>POST /secret/{secretName}</code><br>Replace <code>{secretName}</code> with the desired name for the secret.</p>

  <h2>Running the Application</h2>

  </ol>


  <h2>Running the Application</h2>
  <p>Change directory: <code>cd Secrets_Manager</code></p>

  <p>To run the application, use the following command:<br><code>dotnet run</code><br>The application will start listening on the configured port (by default, port 5000). You can now access the endpoints described above.</p>

  <h2>Contributing</h2>
  <p>Contributions are welcome! Feel free to submit issues or pull requests if you encounter any problems or have suggestions for improvements.</p>


</body>
</html>

# HashingService README

## Overview
The `HashingService` is a C# service designed to hash user details such as name, date of birth, and contact information using the TrustElevateSDK. This README provides a comprehensive guide on how to implement, use, and test this service.

## Project Structure

### Controllers
- **HashingController.cs**: API controller that handles HTTP requests.

### Services
- **IHashingService.cs**: Interface defining the hashing service contract.
- **HashingService.cs**: Implementation of the hashing service.

### Models
- **UserDetailsDto.cs**: Data Transfer Object (DTO) for user details input.
- **ReturnUserHashDetailDto.cs**: DTO for hashed user details output.

## Implementation Details

1. **Installing the NuGet Package**:
   - Use NuGet Package Manager or .NET CLI to install the TrustElevateSDK package:
     ```
     dotnet add package TrustElevateSDK
     ```

2. **Setting Up the Project**:
   - Create a new C# project in your preferred IDE (e.g., Visual Studio, Visual Studio Code).
   - Ensure the project targets a compatible version of the .NET framework or .NET Core.

3. **Creating Service Interface**:
   - Define the interface for the hashing service (e.g., `IHashingService.cs`).
   - Declare the method signature for hashing user details.

4. **Implementing the Service**:
   - Create a class to implement the hashing service interface (e.g., `HashingService.cs`).
   - Implement the method to hash user details using TrustElevateSDK.

5. **Initializing the TrustElevateSDK**:
   - Import the necessary namespaces from TrustElevateSDK.
   - Use TrustElevateSDK methods to hash user details as required by the business logic.

6. **Creating DTOs**:
   - Define Data Transfer Objects (DTOs) to represent user details and hashed results.
   - DTOs should mirror the structure of the data being processed.

7. **Configuring Controllers**:
   - Create API controllers to handle HTTP requests (e.g., `HashingController.cs`).
   - Inject the hashing service into the controller constructor.

8. **Implementing Controller Actions**:
   - Define action methods in the controller to handle specific HTTP requests (e.g., POST requests to `/api/hashing/hash`).
   - Use the hashing service to process user input and return hashed results.

9. **Testing the Service**:
   - Write unit tests to verify the functionality of the hashing service and controllers.
   - Test scenarios should cover typical use cases and edge cases to ensure robustness.

10. **Documenting the Project**:
    - Write a comprehensive README.md file to explain project structure, implementation details, usage instructions, and testing guidelines.
    - Include explanations of each component, their roles, and how they interact within the project.
    - Provide examples and code snippets where necessary to aid understanding.


### Step-by-Step Explanation of the Hashing Service

1. **Set the Consent Date**

   ```csharp
   var consentDate = DateTime.UtcNow;

- This line sets the current date and time in Coordinated Universal Time (UTC) as the consent date. It's crucial to record when the user consented to the processing of their data.

2. **Initialize the G1TokenBuilder**

    ```csharp
    var builder = new G1TokenBuilder(defaultIntlCode)
        .SetName(userDetailsDto.Name)
        .SetDateOfBirth(userDetailsDto.DateOfBirth)
        .AddContacts(userDetailsDto.Contact)
        .AddConsent("Zonk", consentDate);

   .SetName(userDetailsDto.Name): Sets the user's name.
   .SetDateOfBirth(userDetailsDto.DateOfBirth): Sets the user's date of birth.
   .AddContacts(userDetailsDto.Contact): Adds the user's contact information.
   .AddConsent("Zonk", consentDate): Adds consent with the subject "Zonk" and the consent date recorded earlier.

3. **Build the Token**

   ```csharp
    var tokens = builder.Build();

- This line generates G1 tokens containing hashed representations of the user's details. These tokens are essential for securely representing the user's data.

4. **Extract the first Token**

    ```csharp
    var firstToken = tokens.FirstOrDefault();

- This line retrieves the first token from the list of generated tokens. It will be used to extract the hashed user details.

5. **Extract the Hashed Name**

    ```csharp
    var hashedName = firstToken?.G1Token.FirstOrDefault()?.Hash;

- This line extracts the hash value of the user's name from the first token. It ensures that the user's name is securely represented in hashed form.

6. **Extract the Hash DateOfBirth

    ```csharp
    var hashedDateOfBirth = tokens.FirstOrDefault()?.G1Token.ElementAtOrDefault(1)?.Hash;

- This line extracts the hash value of the user's name from the first token. It ensures that the user's name is securely represented in hashed form.

7. **Extract the Hashed Contact**

    ```csharp
    var hashedContact = firstToken?.Hash;

- This line extracts the hash value of the user's contact information from the first token. It securely represents the user's contact information in hashed form.
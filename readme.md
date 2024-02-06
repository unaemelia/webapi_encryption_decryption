# Encryption Decryption API

## Description

This project is an ASP.NET Web API that provides two endpoints for encrypting and decrypting messages using the Caesar Cipher algorithm. The API exposes endpoints for encryption and decryption operations and is designed to be used programmatically.

## Features

- **Encryption Endpoint:** `/encrypt/{message}/{shift}`
  - Encrypts the provided message using the Caesar Cipher algorithm with the specified shift value.
- **Decryption Endpoint:** `/decrypt`
  - Decrypts the previously encrypted message using the stored shift value.

## Usage

To encrypt a message, make a `GET` request to the `/encrypt/{message}/{shift}` endpoint, replacing `{message}` with the message to be encrypted and `{shift}` with the desired shift value (numeric value). The encrypted message will be returned in Base64 format.

Example:
```cs
/encrypt/Hello/3
```
Response:
```cs
Encrypted message: S2hvb3I=
```


To decrypt a message, make a `GET` request to the `/decrypt` endpoint. The previously encrypted message will be decrypted using the stored shift value.

Example:
```cs
/decrypt
```
Response:
```cs
Decrypted message: Hello
```

## Running Tests

This project includes unit tests written using xUnit. The tests ensure the correctness of the encryption and decryption algorithms.

To run the unit tests locally, follow these steps:
1. Clone the repository.
2. Navigate to the `UnitTests` directory.
3. Run the following command:
```cs
dotnet test
```

## Continuous Integration

The project is integrated with GitHub Actions to automatically run the unit tests on each push to the repository. Additionally, it is connected to AWS Elastic Beanstalk for deployment.

### Unit Tests Workflow

The `UnitTest.yml` workflow file defines a workflow that runs unit tests on each push to the repository, excluding changes made to the `main` branch.

### AWS Deployment Workflow

The `Aws.yml` workflow file defines a workflow that builds and deploys the application to AWS Elastic Beanstalk on each push to the `main` branch.

## Setup

To set up the project locally, follow these steps:
1. Clone the repository.
2. Navigate to the project directory.
3. Ensure you have the .NET SDK installed.
4. Run the following command to restore dependencies and build the project:
```cs
dotnet restore
dotnet build
```

## CI/CD Process

See FigJam sketch of the backend and frontend process of the application [here](https://www.figma.com/file/ppNXI9vhOHJKsCHsWZI4zG/CI%2FCD-Individuell-examination?type=whiteboard&node-id=0%3A1&t=e3v6MMYWw2Xap5ja-1).

## Individual Project CI/CI

Made by:
- Una
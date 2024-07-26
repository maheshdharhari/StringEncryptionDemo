# StringEncryptionDemo

StringEncryptionDemo is a simple .NET console application designed to demonstrate the process of encrypting and decrypting strings using the `PasswordDeriveBytes` class. This project serves as an educational example for developers interested in learning basic cryptographic operations in .NET.

## Features

- **Encryption**: Securely encrypts a plain text string using a password and a randomly generated salt.
- **Decryption**: Decrypts an encrypted string back to its original plain text using the same password and salt.
- **Key Derivation**: Utilizes `PasswordDeriveBytes` to derive cryptographic keys from a password and salt.
- **AES Encryption**: Employs the Advanced Encryption Standard (AES) for robust and secure encryption.

## How It Works

### Encryption Process

1. A random salt is generated for each encryption operation.
2. `PasswordDeriveBytes` is used to derive a key and IV from the password and salt.
3. The plain text is encrypted using the AES algorithm and the derived key and IV.
4. The salt and encrypted data are combined and encoded in base64 for easy storage and transmission.

### Decryption Process

1. The salt is extracted from the beginning of the encrypted data.
2. `PasswordDeriveBytes` is used again to derive the same key and IV from the password and salt.
3. The AES algorithm is used to decrypt the data back to its original plain text.

## Usage

### Input

- A plain text string to be encrypted.
- A password to derive the cryptographic key.

### Output

- The encrypted text displayed in the console.
- The decrypted text displayed in the console to verify successful encryption and decryption.

## Code Overview

- **Program.cs**: Contains the main method that demonstrates the encryption and decryption process. It also includes the `EncryptString` and `DecryptString` methods that handle the cryptographic operations.

## Requirements

- .NET Core SDK or .NET Framework SDK
- Visual Studio or any other .NET-compatible IDE

## Getting Started

1. Clone the repository or download the project files.
2. Open the project in Visual Studio.
3. Build and run the project to see the encryption and decryption process in action.

```bash
# Clone the repository
git clone https://github.com/maheshdharhari/StringEncryptionDemo.git

# Navigate to the project directory
cd StringEncryptionDemo

# Open the project in Visual Studio and run
```

## Conclusion

This console application serves as a practical example for developers to understand and implement encryption and decryption using `PasswordDeriveBytes` in .NET. It highlights the importance of using strong passwords and secure key derivation methods to protect sensitive information. For modern applications, consider transitioning to `Rfc2898DeriveBytes` for improved security.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE.txt) file for details.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request with your changes.

## Acknowledgements

- Thanks to the .NET community for their continuous support and contributions.

## Contact

If you have any questions, feel free to reach out to [contact@maheshyadav.com.np](mailto:contact@maheshyadav.com.np).

---

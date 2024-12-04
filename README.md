# CUDA C# Environment Test

## Prerequisites

1. **NVIDIA Software Requirements:**
   - NVIDIA CUDA Toolkit 12.6.3
   - NVIDIA Studio Driver 566.14 or later
   - Visual Studio 2022 (Professional or Community)

2. **Hardware Requirements:**
   - CUDA-capable GPU (Tested with 2x NVIDIA GeForce GTX 1080 Ti in SLI)
   - Compatible CPU and OS (Windows 11 Enterprise 23H2 or later)

## Project Setup

1. **Create a new C# Console Application**
   ```bash
   dotnet new console -n CSharpLearning
   cd CSharpLearning
   ```

2. **Add ManagedCuda Package**
   ```bash
   dotnet add package ManagedCuda-12
   ```

3. **Project Configuration**
   The project requires unsafe blocks for direct memory operations and the ManagedCuda-12 package for CUDA bindings.

## Features

The test program performs the following checks:

1. **Driver Version Check**
   - Retrieves and displays the installed CUDA driver version
   - Verifies CUDA runtime compatibility

2. **Device Enumeration**
   - Counts available CUDA-capable devices
   - Supports multi-GPU systems

3. **Device Information**
   - Device Name: GPU model identification
   - Compute Capability: CUDA architecture version
   - Total Memory: Available VRAM
   - Clock Rate: GPU core frequency

## Future Enhancements

Planned additional tests for:
- cuTENSOR
- NCCL
- cuDNN
- cuSPARSLT 

## Contributing

### Development Approach

We follow a feature-based development approach where each CUDA library test is developed and validated independently. This allows for focused testing and easier contribution management.

### Current Feature Implementation Status

| Library    | Version   | Status      | Issue Link |
|------------|-----------|-------------|------------|
| cuTENSOR   | 2.0.2.1   | Planned     | #2         |
| NCCL       | 2.23.4    | Planned     | #3         |
| cuDNN      | 9.5.1     | Planned     | #4         |
| cuSPARSLT  | 0.6.3     | Planned     | #5         |

### How to Contribute

1. **Choose a Feature**
   - Check the [Issues](../../issues) page
   - Look for issues labeled `feature` or `help wanted`
   - Comment on the issue you'd like to work on

2. **Fork and Clone**
   ```bash
   # Fork the repository on GitHub, then:
   git clone https://github.com/YOUR-USERNAME/CudaEnvironmentTester.git
   cd CudaEnvironmentTester
   ```

3. **Create a Feature Branch**
   ```bash
   # Branch naming convention: feature/library-name-test
   git checkout -b feature/library-name-test
   ```

4. **Development Guidelines**
   - Each test implementation should:
     - Verify library version
     - Include basic initialization tests
     - Include error handling
     - Include documentation
     - Follow existing code style

5. **Testing**
   - Ensure all tests pass locally
   - Verify with different CUDA configurations if possible
   - Document any specific requirements or dependencies

6. **Submit Your Contribution**
   - Push your changes to your fork
   - Create a Pull Request (PR)
   - Link the PR to the relevant issue
   - Await review and address any feedback

### Pull Request Requirements

- Clear description of changes
- Links to relevant issue(s)
- Passing tests
- Updated documentation
- No merge conflicts with the main branch

### Code Style Guidelines

- Follow C# naming conventions
- Include XML documentation comments
- Add meaningful console output for test results
- Handle exceptions appropriately
- Include cleanup code in disposal blocks

### Getting Help

- Comment on the relevant issue
- Check existing documentation
- Contact maintainers through issue comments

### License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

Please ensure you give credit to KDTix Open when using or sharing this code, as per the MIT License requirements.

## Project Structure

```
CudaEnvironmentTester/
├── Program.cs                      # Main program and CUDA environment test
├── LibraryTests/                   # Library-specific test implementations
│   ├── ICudaLibraryTest.cs        # Test interface
│   ├── Templates/                  # Shared test templates
│   │   └── CudaLibraryTestTemplate.cs
│   └── CudnnTest.cs               # cuDNN implementation example
```

## Test Output Example

```
CUDA Environment Test Suite
==========================

Number of CUDA devices: 2

Device 0: NVIDIA GeForce GTX 1080 Ti
Compute Capability: 6.1
Total Memory: 11263 MB
Clock Rate: 1607 MHz

Device 1: NVIDIA GeForce GTX 1080 Ti
Compute Capability: 6.1
Total Memory: 11263 MB
Clock Rate: 1607 MHz

CUDA environment test completed successfully!

Testing cuDNN v9.5.1:
----------------------------------------
Initializing cuDNN...
Verifying cuDNN version...
Running cuDNN tests...
Cleaning up cuDNN resources...
```

## Implementation Guide

### Creating a New Library Test

1. Create a new class in the `LibraryTests` folder:
   ```csharp
   public class YourLibraryTest : CudaLibraryTestTemplate
   {
       public override string LibraryName => "YourLibrary";
       public override string LibraryVersion => "X.Y.Z";

       protected override void Initialize()
       {
           Console.WriteLine("Initializing YourLibrary...");
           // Your initialization code
       }

       protected override void VerifyVersion()
       {
           Console.WriteLine("Verifying YourLibrary version...");
           // Your version verification code
       }

       protected override void ExecuteTests()
       {
           Console.WriteLine("Running YourLibrary tests...");
           // Your test implementation
       }

       protected override void Cleanup()
       {
           Console.WriteLine("Cleaning up YourLibrary resources...");
           // Your cleanup code
       }
   }
   ```

2. The test will be automatically discovered and run by the main program.

### Test Implementation Requirements

Each library test should:
1. Inherit from `CudaLibraryTestTemplate` (current version: 1.0.0)
2. Provide library name and version information
3. Implement all required test methods:
   - `Initialize()`: Setup resources and connections
   - `VerifyVersion()`: Confirm correct library version
   - `ExecuteTests()`: Run actual library tests
   - `Cleanup()`: Release all resources

The template version will be displayed in the test output:
```
Testing [LibraryName] v[Version]:
----------------------------------------
Using template version: 1.0.0
Initializing [LibraryName]...
Verifying [LibraryName] version...
Running [LibraryName] tests...
Cleaning up [LibraryName] resources...
```

## Current Implementation Status

| Library    | Version   | Status      | Implementation | Issue Link |
|------------|-----------|-------------|----------------|------------|
| CUDA Core  | 12.6.3    | ✅ Complete | Program.cs    | -          |
| Template   | 1.0.0     | ✅ Complete | CudnnTest.cs  | #1         |
| cuDNN      | 9.5.1     | 🔄 Planned  | -             | Upcoming   |
| cuTENSOR   | 2.0.2.1   | 🔄 Planned  | -             | Upcoming   |
| NCCL       | 2.23.4    | 🔄 Planned  | -             | Upcoming   |
| cuSPARSLT  | 0.6.3     | 🔄 Planned  | -             | Upcoming   |
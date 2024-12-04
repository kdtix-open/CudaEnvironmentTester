# Usage Guide

This guide explains how to use the CUDA Environment Tester effectively.

## Table of Contents
- [Basic Usage](#basic-usage)
- [Command Line Options](#command-line-options)
- [Test Output](#test-output)
- [Using with CI/CD](#using-with-cicd)
- [Advanced Usage](#advanced-usage)

## Basic Usage

### Running All Tests
```bash
dotnet run
```

### Running Specific Library Tests
```bash
# Future Implementation
dotnet run --library cudnn
dotnet run --library cutensor
```

## Test Output

### Understanding Test Results
The tester provides detailed output in this format:

```
CUDA Environment Test Suite
==========================

# Basic CUDA Environment
Number of CUDA devices: 2
Device 0: NVIDIA GeForce GTX 1080 Ti
Compute Capability: 6.1
Total Memory: 11263 MB
Clock Rate: 1607 MHz

# Library Tests
Testing cuDNN v9.5.1:
----------------------------------------
Using template version: 1.0.0
Initializing cuDNN...
Verifying cuDNN version...
Running cuDNN tests...
Cleaning up cuDNN resources...
```

### Exit Codes
- `0`: All tests passed
- `1`: Environment setup failed
- `2`: One or more library tests failed
- `3`: Invalid arguments or configuration

## Using with CI/CD

### GitHub Actions Example
```yaml
name: CUDA Tests
on: [push, pull_request]

jobs:
  test:
    runs-on: windows-latest
    steps:
      - uses: actions/checkout@v2
      - name: Setup .NET
        uses: actions/setup-dotnet@v1
        with:
          dotnet-version: '9.0.x'
      - name: Run Tests
        run: dotnet run
```

### Azure Pipelines Example
```yaml
trigger:
  - main

pool:
  vmImage: 'windows-latest'

steps:
- task: UseDotNet@2
  inputs:
    version: '9.0.x'
- script: dotnet run
  displayName: 'Run CUDA Tests'
```

## Advanced Usage

### Environment Variables
```bash
# Set specific CUDA device
set CUDA_VISIBLE_DEVICES=0
dotnet run

# Enable verbose output
set CUDA_TEST_VERBOSE=1
dotnet run
```

### Test Configuration
Future releases will support a configuration file:
```json
{
  "libraries": {
    "cudnn": {
      "enabled": true,
      "version": "9.5.1"
    },
    "cutensor": {
      "enabled": false
    }
  }
}
```

## Best Practices

1. **Regular Testing**
   - Run tests after driver updates
   - Test before deploying CUDA applications
   - Verify after system changes

2. **CI/CD Integration**
   - Include in deployment pipelines
   - Set up automated testing
   - Monitor test results

3. **Error Handling**
   - Check exit codes
   - Review full test output
   - Save logs for troubleshooting

## See Also
- [Installation Guide](installation.md)
- [Implementation Guide](implementation.md)
- [Test Output Examples](test-output.md) 
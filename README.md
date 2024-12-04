# CUDA C# Environment Test

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

> A comprehensive testing framework for CUDA libraries in C#

## Overview

Test suite for verifying CUDA library installations and functionality in C# environments. Supports multiple NVIDIA CUDA libraries through a template-based testing framework.

## Quick Links
- [Installation Guide](docs/installation.md)
- [Usage Guide](docs/usage.md)
- [Implementation Guide](docs/implementation.md)
- [Contributing Guide](docs/contributing.md)
- [Test Output Examples](docs/test-output.md)

## Prerequisites

### Software Requirements
- NVIDIA CUDA Toolkit 12.6.3
- NVIDIA Studio Driver 566.14 or later
- Visual Studio 2022 (Professional or Community)
- .NET 9.0 SDK

### Hardware Requirements
- CUDA-capable GPU
- Compatible CPU and OS (Windows 11 Enterprise 23H2 or later)

## Quick Start

```bash
git clone https://github.com/kdtix-open/CudaEnvironmentTester.git
cd CudaEnvironmentTester
dotnet restore
dotnet run
```

## Project Structure

```
CudaEnvironmentTester/
├── Program.cs                      # Main program and CUDA environment test
├── LibraryTests/                   # Library-specific test implementations
│   ├── ICudaLibraryTest.cs        # Test interface
│   ├── Templates/                  # Shared test templates
│   │   └── CudaLibraryTestTemplate.cs
│   └── CudnnTest.cs               # cuDNN implementation example
└── docs/                          # Detailed documentation
```

## Current Status

| Library    | Version   | Status      | Implementation | Issue Link |
|------------|-----------|-------------|----------------|------------|
| CUDA Core  | 12.6.3    | ✅ Complete | Program.cs     | -          |
| Test Template | -      | ✅ Complete | CudnnTest.cs  | #1         |
| cuDNN      | 9.5.1     | 🔄 Planned  | -             | Upcoming   |
| cuTENSOR   | 2.0.2.1   | 🔄 Planned  | -             | Upcoming   |
| NCCL       | 2.23.4    | 🔄 Planned  | -             | Upcoming   |
| cuSPARSLT  | 0.6.3     | 🔄 Planned  | -             | Upcoming   |

# Roadmap

- [x] Core CUDA environment testing
- [x] Test template system
- [ ] cuDNN implementation
- [ ] cuTENSOR implementation
- [ ] NCCL implementation
- [ ] cuSPARSLT implementation
## License

MIT License - see [LICENSE](LICENSE)

## Acknowledgments

- KDTix Open for project support
- NVIDIA for CUDA toolkit and libraries
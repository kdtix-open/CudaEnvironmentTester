# Installation Guide

This guide will help you set up the CUDA Environment Tester on your system.

## Table of Contents
- [Prerequisites](#prerequisites)
- [NVIDIA Software Installation](#nvidia-software-installation)
- [Project Setup](#project-setup)
- [Verification](#verification)
- [Troubleshooting](#troubleshooting)

## Prerequisites

### Hardware Requirements
- CUDA-capable NVIDIA GPU
- Minimum 8GB system RAM (16GB recommended)
- x86-64 compatible processor

### Software Requirements
- Windows 11 Enterprise 23H2 or later
- .NET 9.0 SDK
- Visual Studio 2022 (Professional or Community)
- Git (for cloning repository)

## NVIDIA Software Installation

1. **NVIDIA Display Driver**
   - Download [NVIDIA Studio Driver 566.14 or later](https://www.nvidia.com/download/index.aspx)
   - Run installer and follow prompts
   - Restart system after installation

2. **CUDA Toolkit**
   - Download [CUDA Toolkit 12.6.3](https://developer.nvidia.com/cuda-downloads)
   - Choose your operating system and architecture
   - Follow installation wizard
   - Add CUDA paths to system environment variables:
     ```
     PATH += C:\Program Files\NVIDIA GPU Computing Toolkit\CUDA\v12.6\bin
     PATH += C:\Program Files\NVIDIA GPU Computing Toolkit\CUDA\v12.6\libnvvp
     ```

3. **Additional CUDA Libraries** (Optional)
   - cuTENSOR 2.0.2.1
   - NCCL 2.23.4
   - cuDNN 9.5.1
   - cuSPARSLT 0.6.3

## Project Setup

1. **Clone Repository**
   ```bash
   git clone https://github.com/kdtix-open/CudaEnvironmentTester.git
   cd CudaEnvironmentTester
   ```

2. **Restore Dependencies**
   ```bash
   dotnet restore
   ```

3. **Build Project**
   ```bash
   dotnet build
   ```

## Verification

1. **Run Basic Test**
   ```bash
   dotnet run
   ```

2. **Expected Output**
   ```
   CUDA Environment Test Suite
   ==========================

   Number of CUDA devices: X
   ... device information ...
   ```

3. **Verify CUDA Installation**
   ```bash
   nvcc --version
   ```
   Should show CUDA version 12.6.3

## Troubleshooting

### Common Issues

1. **CUDA Not Found**
   - Verify environment variables are set correctly
   - Reinstall CUDA Toolkit
   - Check system compatibility

2. **Build Errors**
   - Ensure .NET 9.0 SDK is installed
   - Clean solution and rebuild
   - Check for missing dependencies

3. **Runtime Errors**
   - Update NVIDIA drivers
   - Verify GPU compatibility
   - Check Windows Event Viewer for errors

### Getting Help

If you encounter issues:
1. Check the [Issues](https://github.com/kdtix-open/CudaEnvironmentTester/issues) page
2. Search for similar problems
3. Create a new issue with:
   - System specifications
   - Error messages
   - Steps to reproduce

## Next Steps

After successful installation:
- Review the [Usage Guide](usage.md)
- Check [Implementation Guide](implementation.md) for adding tests
- See [Contributing Guide](contributing.md) for development

## Support

For additional support:
- Create an [Issue](https://github.com/kdtix-open/CudaEnvironmentTester/issues)
- Check [Documentation](../README.md) 
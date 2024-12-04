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
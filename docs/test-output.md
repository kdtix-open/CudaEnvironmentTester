# Test Output Examples

This guide provides examples of test outputs and how to interpret them.

## Table of Contents
- [Successful Test Output](#successful-test-output)
- [Error Scenarios](#error-scenarios)
- [Warning Examples](#warning-examples)
- [Performance Indicators](#performance-indicators)
- [Troubleshooting Guide](#troubleshooting-guide)

## Successful Test Output

### Basic CUDA Environment Test
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
```

### Library Test Success
```
Testing cuDNN v9.5.1:
----------------------------------------
Using template version: 1.0.0
Initializing cuDNN...
Verifying cuDNN version...
Running cuDNN tests...
Cleaning up cuDNN resources...
```

## Error Scenarios

### CUDA Device Not Found
```
CUDA Environment Test Suite
==========================

Error: No CUDA devices found
Ensure NVIDIA drivers are installed and a compatible GPU is present.
```

### Version Mismatch
```
Testing cuDNN v9.5.1:
----------------------------------------
Using template version: 1.0.0
Initializing cuDNN...
Error: Version mismatch
Expected: 9.5.1
Found: 9.4.0
```

### Resource Initialization Failure
```
Testing cuTENSOR v2.0.2.1:
----------------------------------------
Using template version: 1.0.0
Error: Failed to initialize cuTENSOR
Status: OUT_OF_MEMORY
Available GPU memory: 1024 MB
Required memory: 2048 MB
```

## Warning Examples

### Performance Warnings
```
Testing NCCL v2.23.4:
----------------------------------------
Warning: Single GPU detected, multi-GPU tests will be skipped
Warning: Running in compatibility mode - reduced performance
```

### Resource Warnings
```
Testing cuSPARSLT v0.6.3:
----------------------------------------
Warning: Limited GPU memory available
Warning: Some tests may be scaled down
Available memory: 2048 MB
Recommended: 4096 MB
```

## Performance Indicators

### Memory Usage
```
Memory Statistics:
- Total GPU Memory: 11263 MB
- Used Memory: 3584 MB
- Free Memory: 7679 MB
- Peak Usage: 4096 MB
```

### Timing Information
```
Test Timing:
- Initialization: 123ms
- Version Check: 5ms
- Core Tests: 456ms
- Cleanup: 34ms
Total Time: 618ms
```

## Troubleshooting Guide

### Common Error Messages

1. **CUDA_ERROR_NOT_INITIALIZED**
   ```
   Error: CUDA driver version is insufficient for runtime version
   Solution: Update NVIDIA drivers
   ```

2. **OUT_OF_MEMORY**
   ```
   Error: Insufficient GPU memory
   Available: 1024 MB
   Required: 2048 MB
   Solution: Free GPU resources or use smaller test sets
   ```

3. **Version Incompatibility**
   ```
   Error: Library version mismatch
   Expected: X.Y.Z
   Found: A.B.C
   Solution: Install correct library version
   ```

4. **CUDA_ERROR_NO_DEVICE**
   ```
   Error: No CUDA device found
   Check: 
   - GPU physically connected
   - Power management settings
   - NVIDIA drivers installed
   Solution: Verify hardware and driver installation
   ```

5. **CUDA_ERROR_INVALID_DEVICE**
   ```
   Error: Invalid device ordinal
   Requested: 2
   Available: 1
   Solution: Use device index within available range
   ```

6. **Library Load Failure**
   ```
   Error: Failed to load library
   Library: libcudnn.so.9
   Details: DllNotFoundException
   Solution: Verify library installation path and dependencies
   ```

7. **Resource Exhaustion**
   ```
   Error: Resource allocation failed
   Type: CUDA Memory
   Details:
   - Requested: 4GB
   - Available: 2GB
   - System Load: High
   Solution: 
   - Close other GPU applications
   - Reduce test batch size
   - Check for memory leaks
   ```

8. **Driver/Runtime Mismatch**
   ```
   Error: CUDA driver/runtime version mismatch
   Driver: 12.6
   Runtime: 12.7
   Solution: Align CUDA toolkit and driver versions
   ```

### System State Diagnostics
```
System Diagnostics:
- GPU Temperature: 83°C (Warning: High)
- Power State: P2 (Performance limited)
- Memory Clock: 810 MHz
- Graphics Clock: 1350 MHz
- PCIe Generation: Gen3 x8 (Expected: x16)
```

### Recovery Steps

1. **Driver Issues**
   ```
   1. Clean uninstall drivers:
      Display Driver Uninstaller (DDU)
   2. Reboot in safe mode
   3. Install latest drivers
   4. Verify installation:
      nvidia-smi
   ```

2. **Memory Problems**
   ```
   1. Check memory fragmentation:
      nvidia-smi -q
   2. Reset GPU state:
      nvidia-smi --gpu-reset
   3. Monitor memory:
      nvidia-smi dmon
   ```

3. **Library Conflicts**
   ```
   1. Check library versions:
      ldconfig -p | grep cuda
   2. Verify paths:
      echo $LD_LIBRARY_PATH
   3. Update library cache:
      ldconfig
   ```

### Performance Troubleshooting

```
Performance Analysis:
1. Baseline Performance
   - Expected: 1000 ops/sec
   - Actual: 750 ops/sec
   
2. Bottleneck Analysis
   - PCIe Bandwidth: 8 GB/s (Expected: 16 GB/s)
   - Memory Transfer: 60% of time
   - Computation: 40% of time

3. Recommendations
   - Check PCIe slot configuration
   - Optimize memory transfers
   - Consider batch size adjustments
```

### Environment Validation
```
Environment Check:
✓ CUDA Driver: 12.6.3
✓ CUDA Runtime: 12.6.3
✗ cuDNN: Not found in PATH
✓ GPU Memory: Sufficient
✗ Temperature: Warning
✓ Power State: Optimal

Action Items:
1. Add cuDNN to system PATH
2. Improve cooling solution
```

## See Also
- [Usage Guide](usage.md)
- [Implementation Guide](implementation.md)
- [Contributing Guide](contributing.md) 
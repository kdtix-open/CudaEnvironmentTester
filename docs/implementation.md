# Implementation Guide

This guide explains how to implement new CUDA library tests using our template system.

## Table of Contents
- [Template Overview](#template-overview)
- [Implementation Steps](#implementation-steps)
- [Best Practices](#best-practices)
- [Example Implementation](#example-implementation)
- [Testing Guidelines](#testing-guidelines)

## Template Overview

### Template Version: 1.0.0
The `CudaLibraryTestTemplate` provides a standardized way to implement CUDA library tests:

```csharp
public abstract class CudaLibraryTestTemplate : ICudaLibraryTest
{
    public virtual string TemplateVersion => "1.0.0";
    public abstract string LibraryName { get; }
    public abstract string LibraryVersion { get; }

    protected abstract void Initialize();
    protected abstract void VerifyVersion();
    protected abstract void ExecuteTests();
    protected abstract void Cleanup();
}
```

## Implementation Steps

1. **Create New Test Class**
   ```csharp
   public class YourLibraryTest : CudaLibraryTestTemplate
   {
       public override string LibraryName => "YourLibrary";
       public override string LibraryVersion => "X.Y.Z";
       
       protected override void Initialize()
       {
           // Implementation
       }
       
       // Other required methods...
   }
   ```

2. **Required Method Implementations**
   - `Initialize()`: Resource setup and library initialization
   - `VerifyVersion()`: Version compatibility checks
   - `ExecuteTests()`: Core functionality tests
   - `Cleanup()`: Resource cleanup and disposal

3. **Error Handling**
   ```csharp
   protected override void ExecuteTests()
   {
       try
       {
           // Your test code
       }
       catch (Exception ex)
       {
           Console.WriteLine($"Test failed: {ex.Message}");
           throw;
       }
   }
   ```

## Best Practices

### 1. Documentation
```csharp
/// <summary>
/// Test implementation for YourLibrary
/// </summary>
/// <remarks>
/// Requires YourLibrary version X.Y.Z
/// See README.md for implementation details
/// </remarks>
public class YourLibraryTest : CudaLibraryTestTemplate
{
    // Implementation
}
```

### 2. Resource Management
```csharp
private IntPtr _handle;

protected override void Initialize()
{
    try
    {
        // Initialize resources
        _handle = // ... initialization
    }
    catch
    {
        if (_handle != IntPtr.Zero)
        {
            // Cleanup
        }
        throw;
    }
}
```

### 3. Version Verification
```csharp
protected override void VerifyVersion()
{
    var currentVersion = // Get library version
    var expectedVersion = new Version(LibraryVersion);
    
    if (currentVersion < expectedVersion)
    {
        throw new Exception($"Version mismatch. Expected: {expectedVersion}, Found: {currentVersion}");
    }
}
```

## Example Implementation

Here's a complete example using cuDNN:

```csharp
using ManagedCuda.CudaDNN;

public class CudnnTest : CudaLibraryTestTemplate
{
    private CudnnContext? _context;

    public override string LibraryName => "cuDNN";
    public override string LibraryVersion => "9.5.1";

    protected override void Initialize()
    {
        _context = new CudnnContext();
    }

    protected override void VerifyVersion()
    {
        var version = _context?.GetVersion() ?? throw new Exception("Context not initialized");
        Console.WriteLine($"cuDNN Version: {version}");
    }

    protected override void ExecuteTests()
    {
        // Basic tensor operations test
        using var tensor = new TensorDescriptor();
        tensor.Set(CudnnDataType.Double, 4, new[] { 2, 3, 4, 5 });
        Console.WriteLine("Tensor test passed");
    }

    protected override void Cleanup()
    {
        _context?.Dispose();
    }
}
```

## Example Implementations

### 1. cuDNN Example

```csharp
using ManagedCuda.CudaDNN;

public class CudnnTest : CudaLibraryTestTemplate
{
    private CudnnContext? _context;

    public override string LibraryName => "cuDNN";
    public override string LibraryVersion => "9.5.1";

    protected override void Initialize()
    {
        _context = new CudnnContext();
    }

    protected override void VerifyVersion()
    {
        var version = _context?.GetVersion() ?? throw new Exception("Context not initialized");
        Console.WriteLine($"cuDNN Version: {version}");
    }

    protected override void ExecuteTests()
    {
        // Basic tensor operations test
        using var tensor = new TensorDescriptor();
        tensor.Set(CudnnDataType.Double, 4, new[] { 2, 3, 4, 5 });
        Console.WriteLine("Tensor test passed");
    }

    protected override void Cleanup()
    {
        _context?.Dispose();
    }
}
```

### 2. cuTENSOR Example

```csharp
using ManagedCuda.CuTensor;

public class CutensorTest : CudaLibraryTestTemplate
{
    private CutensorContext? _context;
    private CUdeviceptr? _devicePtr;

    public override string LibraryName => "cuTENSOR";
    public override string LibraryVersion => "2.0.2.1";

    protected override void Initialize()
    {
        _context = new CutensorContext();
        // Allocate device memory
        _devicePtr = new CUdeviceptr();
    }

    protected override void VerifyVersion()
    {
        var version = _context?.GetVersion() ?? throw new Exception("Context not initialized");
        if (version < 2021)
        {
            throw new Exception($"Unsupported cuTENSOR version: {version}");
        }
    }

    protected override void ExecuteTests()
    {
        // Matrix multiplication test
        using var handle = new CutensorHandle();
        // Test implementation
        Console.WriteLine("Matrix multiplication test passed");
    }

    protected override void Cleanup()
    {
        _devicePtr?.Dispose();
        _context?.Dispose();
    }
}
```

### 3. NCCL Example

```csharp
using ManagedCuda.NCCL;

public class NcclTest : CudaLibraryTestTemplate
{
    private NcclComm? _comm;
    private int _rank;
    private int _size;

    public override string LibraryName => "NCCL";
    public override string LibraryVersion => "2.23.4";

    protected override void Initialize()
    {
        _rank = 0;
        _size = 1;
        _comm = new NcclComm(_rank, _size);
    }

    protected override void VerifyVersion()
    {
        var version = NcclComm.GetVersion();
        Console.WriteLine($"NCCL Version: {version}");
    }

    protected override void ExecuteTests()
    {
        // Test all-reduce operation
        using var stream = new CudaStream();
        // Implementation
        Console.WriteLine("All-reduce test passed");
    }

    protected override void Cleanup()
    {
        _comm?.Dispose();
    }
}
```

### 4. cuSPARSLT Example

```csharp
public class CusparsltTest : CudaLibraryTestTemplate
{
    private IntPtr _handle;
    private CudaContext? _context;

    public override string LibraryName => "cuSPARSLT";
    public override string LibraryVersion => "0.6.3";

    protected override void Initialize()
    {
        _context = new CudaContext();
        // Initialize handle
        CusparsltStatus status = CusparsltCreate(out _handle);
        if (status != CusparsltStatus.Success)
        {
            throw new Exception($"Failed to create cuSPARSLT handle: {status}");
        }
    }

    protected override void VerifyVersion()
    {
        int version = 0;
        CusparsltGetVersion(_handle, ref version);
        Console.WriteLine($"cuSPARSLT Version: {version}");
    }

    protected override void ExecuteTests()
    {
        // Sparse matrix operations test
        using var matA = new CusparsltMatDescr();
        // Implementation
        Console.WriteLine("Sparse matrix test passed");
    }

    protected override void Cleanup()
    {
        if (_handle != IntPtr.Zero)
        {
            CusparsltDestroy(_handle);
        }
        _context?.Dispose();
    }
}
```

## Testing Guidelines

1. **Test Categories**
   - Initialization tests
   - Version compatibility
   - Basic functionality
   - Error conditions
   - Resource cleanup

2. **Test Coverage**
   - Verify successful initialization
   - Check version compatibility
   - Test basic operations
   - Verify error handling
   - Ensure proper cleanup

3. **Output Format**
   ```
   Testing [LibraryName] v[Version]:
   ----------------------------------------
   Using template version: 1.0.0
   Initializing...
   Verifying version...
   Running tests...
   Cleaning up...
   ```

## See Also
- [Usage Guide](usage.md)
- [Contributing Guide](contributing.md)
- [Test Output Examples](test-output.md) 
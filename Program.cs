using ManagedCuda;
using CudaEnvironmentTester.LibraryTests;
using System.Reflection;

/// <summary>
/// Main program for CUDA Environment Testing Suite
/// </summary>
/// <remarks>
/// This program provides a framework for testing CUDA and related libraries.
/// See README.md for complete documentation and contribution guidelines.
/// 
/// TODO: Future Enhancements
/// - Add command line arguments for selective testing (#6)
/// - Add detailed test reporting and logging (#7)
/// - Add parallel test execution for performance (#8)
/// </remarks>
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("CUDA Environment Test Suite");
        Console.WriteLine("==========================\n");
        
        try
        {
            // Core CUDA Environment Test
            TestCudaEnvironment();

            // Discover and Run Library Tests
            RunLibraryTests();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError during tests: {ex.Message}");
        }
    }

    /// <summary>
    /// Tests the basic CUDA environment and displays device information
    /// </summary>
    /// <remarks>
    /// Verifies CUDA installation and provides detailed GPU information.
    /// See README.md "Test Output Example" section for expected output format.
    /// 
    /// TODO: Future Enhancements
    /// - Add CUDA driver version check (#9)
    /// - Add memory bandwidth tests (#10)
    /// - Add multi-GPU communication test (#11)
    /// </remarks>
    static void TestCudaEnvironment()
    {
        // Get number of CUDA devices
        int deviceCount = CudaContext.GetDeviceCount();
        Console.WriteLine($"Number of CUDA devices: {deviceCount}");

        // Print information for each device
        for (int i = 0; i < deviceCount; i++)
        {
            using (var device = new CudaContext(i))
            {
                var attributes = device.GetDeviceInfo();
                Console.WriteLine($"\nDevice {i}: {attributes.DeviceName}");
                Console.WriteLine($"Compute Capability: {attributes.ComputeCapability.Major}.{attributes.ComputeCapability.Minor}");
                Console.WriteLine($"Total Memory: {attributes.TotalGlobalMemory / (1024 * 1024)} MB");
                Console.WriteLine($"Clock Rate: {attributes.ClockRate / 1000} MHz");
            }
        }

        Console.WriteLine("\nCUDA environment test completed successfully!");
    }

    /// <summary>
    /// Discovers and executes all implemented library tests
    /// </summary>
    /// <remarks>
    /// Uses reflection to find and run all concrete implementations of ICudaLibraryTest.
    /// See README.md "Implementation Guide" section for adding new tests.
    /// 
    /// TODO: Future Enhancements
    /// - Add test categories and filtering (#12)
    /// - Add test result collection and reporting (#13)
    /// - Add concurrent test execution option (#14)
    /// </remarks>
    static void RunLibraryTests()
    {
        var testClasses = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => 
                t.GetInterfaces().Contains(typeof(ICudaLibraryTest)) && 
                !t.IsAbstract)
            .OrderBy(t => t.Name);

        foreach (var testClass in testClasses)
        {
            try
            {
                if (Activator.CreateInstance(testClass) is ICudaLibraryTest test)
                {
                    Console.WriteLine($"\nTesting {test.LibraryName} v{test.LibraryVersion}:");
                    Console.WriteLine(new string('-', 40));
                    test.RunTest();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error running {testClass.Name}: {ex.Message}");
            }
        }
    }
}
